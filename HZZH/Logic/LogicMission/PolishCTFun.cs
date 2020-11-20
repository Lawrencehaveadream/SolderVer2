using CommonRs;
using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using ProVisionEbd.Logic;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static HZZH.Logic.LogicMission.PolishFunCT;

namespace HZZH.Logic.LogicMission
{
    public class PolishCTFun : LogicTask
    {
        public PolishCTFun(string name) : base(name + "打磨拍照流程" )
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
        List<PolishPosData> PolishOrderList = new List<PolishPosData>();
        /// <summary>
        /// 左右平台
        /// </summary>
        private int ID { get; set; }
        /// <summary>
        /// 第几个拍照位置
        /// </summary>
        private int NUM { get; set; }

        protected override void LogicImpl()
        {
            var para = ProjectData.Instance.SaveData.PolishData[ID];
            switch (LG.Step)
            {
                case 1://RZ到拍照位
                    ProjectData.Instance.SaveData.processdata.PolishList[ID].Clear();
                    if (Axis.PolishR[ID].status ==0 && Axis.PolishZ[ID].status == 0)
                    {
                        NUM = 0;
                        Axis.PolishR[ID].MC_MoveAbs(0);
                        Axis.PolishZ[ID].MC_MoveAbs(para.SafeZ);
                        LG.ImmediateStepNext(2);
                    }
                    break;
                case 2://XY到拍照位
                    if (Axis.PolishR[ID].status == 0 && Axis.PolishZ[ID].status == 0)
                    {
                        if (ProjectData.Instance.SaveData.processdata.PolishCTPos[ID][NUM].Ban)
                        {
                            NUM++;
                            break;
                        }
                        Axis.PolishX[ID].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.PolishCTPos[ID][NUM].X);
                        Axis.PolishY[ID].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.PolishCTPos[ID][NUM].Y);
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://延时拍照
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0 && LG.Delay(para.CTDelay))
                    {
                        
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://获取相机数据
                    if (/*VisionInteraction.Instance.TriggerCamera(ID)*/true)
                    {

                        if (TaskManager.Default.FSM.MODE == 1)
                        {
                            PolishPosData _pos = new PolishPosData();
                            _pos.Pos.X = ProjectData.Instance.SaveData.processdata.PolishCTPos[ID][NUM].X;
                            _pos.Pos.Y = ProjectData.Instance.SaveData.processdata.PolishCTPos[ID][NUM].Y;
                            _pos.Pos.R = 0;
                            //_pos.Pos = IOandAxisFun.CameraToPolisherPos(ID, _pos.Pos);
                            if (ProjectData.Instance.SaveData.processdata.Agingdataforpolish == null)
                            {
                                ProjectData.Instance.SaveData.processdata.Agingdataforpolish = new PolishDef();
                            }
                            _pos.Pos = IOandAxisFun.CameraToPolisherPos(ID, _pos.Pos);
                            ProjectData.Instance.SaveData.processdata.Agingdataforpolish.Z = 20;
                            _pos.polishData = ProjectData.Instance.SaveData.processdata.Agingdataforpolish;
                            NUM++;
                            
                            ProjectData.Instance.SaveData.processdata.PolishList[ID].Add(_pos);
                            if (NUM < ProjectData.Instance.SaveData.processdata.PolishCTPos[ID].Count)
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

                            foreach (var p in VisionInteraction.Instance.WhichPolish(ID).listModel)
                            {
                                int type = p.modelindex;
                                int num = 0;
                                foreach (var item in ProjectData.Instance.SaveData.processdata.WhichPolishMedol(ID))
                                {
                                    PolishPosData _pos = new PolishPosData();
                                    _pos.Pos.X = p.ListPos[num].X + ProjectData.Instance.SaveData.processdata.PolishCTPos[ID][NUM].X;
                                    _pos.Pos.Y = p.ListPos[num].Y + ProjectData.Instance.SaveData.processdata.PolishCTPos[ID][NUM].Y;
                                    _pos.Pos.R = p.ListPos[num].R;
                                    _pos.polishData = ProjectData.Instance.SaveData.processdata.WhichPolishMedol(ID)[type].polishData[num].Clone();
                                    _pos.Pos = IOandAxisFun.CameraToPolisherPos(ID, _pos.Pos);
                                    num++;
                                    PolishOrderList.Add(_pos);//增加到list里
                                }
                            }
                            foreach (PolishPosData data in PolishOrderList.OrderBy(a => a.Pos.X).ThenBy(a => a.Pos.Y))//对list里的点进行排序
                            {
                                ProjectData.Instance.SaveData.processdata.PolishList[ID].Add(data);//把排列好的点写进打磨list里
                            }

                            if (NUM < ProjectData.Instance.SaveData.processdata.PolishCTPos[ID].Count)
                            {
                                LG.ImmediateStepNext(2);//还有打磨拍照点继续打磨i拍照
                            }
                            else
                            {
                                NUM = 0;
                                LG.ImmediateStepNext(5);
                            }
                        }
                    }
                    break;
                case 5://判断打磨列表里的数据
                    if (ProjectData.Instance.SaveData.processdata.PolishList[ID].Count() > 0)
                    {
                        LG.ImmediateStepNext(0xef);
                    }
                    else if (TaskManager.Default.FSM.MODE == 1)
                    {
                        LG.ImmediateStepNext(0xef);
                    }
                    else
                    {
                        string mes = ID.ToString() + "平台没有打磨点";
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
