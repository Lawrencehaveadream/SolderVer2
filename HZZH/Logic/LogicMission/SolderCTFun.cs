using CommonRs;
using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using ProVisionEbd.Logic;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static HZZH.Logic.LogicMission.PolishFunCT;

namespace HZZH.Logic.LogicMission
{
   public class SolderCTFun : LogicTask
    {
        public SolderCTFun(string name) : base(name + "上锡拍照流程")
        {
            switch (name.ToString())
            {
                case "左":
                    ID = 0;
                    break;
                case "右":
                    ID = 1;
                    break;
            }
        }
        private IOandAxisFun Axis { get; set; } = new IOandAxisFun();
        List<PointFB>[] pS = new List<PointFB>[2] { new List<PointFB>(), new List<PointFB>() };
        List<SolderPosData> SolderOrderList = new List<SolderPosData>();
        private int ID { get; set; }
        /// <summary>
        /// 第几个拍照位置
        /// </summary>
        private int NUM { get; set; }
        protected override void LogicImpl()
        {
            var ProcessData = ProjectData.Instance.SaveData.processdata;
            switch (LG.Step)
            {
                case 1://RZ到位
                    ProcessData.SolderList[ID].Clear();
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        NUM = 0;
                        Axis.SolderR[ID].MC_MoveAbs(0);
                        Axis.SolderZ[ID].MC_MoveAbs(ProjectData.Instance.SaveData.SolderData[ID].SafeZ);
                        LG.ImmediateStepNext(2);
                    }
                    break;
                case 2://XY到位
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.SolderX[ID].MC_MoveAbs(ProcessData.SolderCTPos[ID][NUM].X);
                        Axis.SolderY[ID].MC_MoveAbs(ProcessData.SolderCTPos[ID][NUM].Y);
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://拍照
                    if (Axis.SolderX[ID].status == 0 && Axis.SolderY[ID].status == 0 && LG.Delay(ProjectData.Instance.SaveData.SolderData[ID].CTDelay))
                    {
                        
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://获取相机数据
                    if (/*VisionProject.Instance.visionApi.TrigComplete()||*/ TaskManager.Default.FSM.MODE == 1)
                    {
                        if (TaskManager.Default.FSM.MODE == 1)
                        {
                            SolderPosData _pos = new SolderPosData();
                            _pos.Pos.X = ProjectData.Instance.SaveData.processdata.SolderCTPos[ID][NUM].X;
                            _pos.Pos.Y = ProjectData.Instance.SaveData.processdata.SolderCTPos[ID][NUM].Y;
                            _pos.Pos.R = 0;
                            if (ProjectData.Instance.SaveData.processdata.Agingdataforsolder == null)
                            {
                                ProjectData.Instance.SaveData.processdata.Agingdataforsolder = new SolderDef();
                            }
                            ProjectData.Instance.SaveData.processdata.Agingdataforsolder.Z = 25;
                            _pos.SolderData = ProjectData.Instance.SaveData.processdata.Agingdataforsolder;
                            ProcessData.SolderList[ID].Add(_pos);//增加到list里
                            NUM++;
                            if (NUM < ProjectData.Instance.SaveData.processdata.SolderCTPos[ID].Count)
                            {
                                LG.ImmediateStepNext(2);//还有打磨拍照点继续打磨i拍照
                            }
                            else
                            {
                                NUM = 0;
                                LG.ImmediateStepNext(5);
                            }
                        }
                        else if (true)
                        {
                            foreach (var p in VisionInteraction.Instance.WhichSolder(ID).model)
                            {
                                int type = p.modelindex;
                                int num = 0;
                                foreach (var item in ProjectData.Instance.SaveData.processdata.WhichSolderMedol(ID))
                                {

                                    float Tx = 0;
                                    float Ty = 0;
                                    float Tr = 0;

                                    float x = 0;
                                    float y = 0;
                                    float cAng = (float)(p.Pos[num].R * Math.PI / 180);
                                    if (ProjectData.Instance.SaveData.SolderPlatform[ID].UseR)//使用旋转中心
                                    {
                                        x = p.ModelPos.X + ProjectData.Instance.SaveData.processdata.SolderCTPos[ID][NUM].X;
                                        y = p.ModelPos.Y + ProjectData.Instance.SaveData.processdata.SolderCTPos[ID][NUM].Y;
                                        
                                        IOandAxisFun.Transorm(ID , x, y,  x + p.Pos[num].X, y + p.Pos[num].Y, cAng, out Tx, out Ty);
                                    }
                                    else
                                    {
                                        Tx= p.Pos[num].X + ProjectData.Instance.SaveData.processdata.SolderCTPos[ID][NUM].X;
                                        Ty = p.Pos[num].Y + ProjectData.Instance.SaveData.processdata.SolderCTPos[ID][NUM].Y;
                                        Tr = 0;
                                    }
                                    SolderPosData _pos = new SolderPosData();
                                    SolderPosData cpos = new SolderPosData();
                                    _pos.Pos.X = Tx;
                                    _pos.Pos.Y = Ty;
                                    _pos.Pos.R = Tr;
                                    cpos.Pos = IOandAxisFun.CameraToSolderPos(ID, _pos.Pos);
                                    cpos.SolderData = ProjectData.Instance.SaveData.processdata.WhichSolderMedol(ID)[type].solderdata[num].Clone();
                                    num++;
                                    SolderOrderList.Add(cpos);//增加到list里
                                }
                            }
                            foreach (SolderPosData data in SolderOrderList.OrderBy(a => a.Pos.X).ThenBy(a => a.Pos.Y))//排序
                            {
                                ProcessData.SolderList[ID].Add(data);//加到上锡位置
                            }
                            NUM++;
                            if (ProcessData.SolderCTPos[ID].Count() > NUM)
                            {
                                LG.ImmediateStepNext(2);//去下一个拍照位置
                            }
                            else
                            {
                                LG.ImmediateStepNext(5);
                            }
                        }
                    }
                    break;
                case 5://判断上锡列表里的数据
                    if (ProcessData.SolderList[ID].Count() > 0)
                    {
                        LG.ImmediateStepNext(0xef);
                    }
                    else if (TaskManager.Default.FSM.MODE == 1)
                    {
                        LG.ImmediateStepNext(0xef);
                    }
                    else
                    {
                        string mes = ID.ToString() + "平台无上锡点";
                        MachineAlarm.SetAlarm(AlarmLevelEnum.Level2, mes);
                        LG.StepNext(0xef,FSMStaDef.RUN);
                    }
                    break;
                case 0xef://结束
                    LG.End();
                    break;

            }
        }
    }
}
