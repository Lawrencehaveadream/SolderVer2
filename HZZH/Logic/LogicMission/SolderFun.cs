using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMission
{
    public class SolderFun : LogicTask
    {
        public SolderFun(string name) : base(name + "上锡流程")
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
        /// <summary>
        /// 平台ID
        /// </summary>
        private int ID { get; set; }
        private IOandAxisFun Axis = new IOandAxisFun();
        protected override void LogicImpl()
        {
            var ProcessData = ProjectData.Instance.SaveData.processdata;
            switch (LG.Step)
            {
                case 1://上锡列表里是否有上锡点
                    if (ProcessData.SolderList[ID].Count() > 0)
                    {
                        LG.ImmediateStepNext(2);
                    }
                    else if( TaskManager.Default.FSM.MODE == 1)
                    {
                        LG.ImmediateStepNext(0xef);
                    }
                    else
                    {
                        string mes = ID.ToString() + "平台无焊锡点";
                        MachineAlarm.SetAlarm(AlarmLevelEnum.Level2, mes);
                        LG.StepNext(0xef, FSMStaDef.RUN);
                    }
                    break;
                case 2://RZ抬高
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.SolderR[ID].MC_MoveAbs(0);
                        Axis.SolderZ[ID].MC_MoveAbs(ProjectData.Instance.SaveData.SolderData[ID].SafeZ);
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://XY到第一个上锡点位
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.SolderX[ID].MC_MoveAbs(ProcessData.SolderList[ID][0].Pos.X);
                        Axis.SolderY[ID].MC_MoveAbs(ProcessData.SolderList[ID][0].Pos.Y);
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://第一段送锡
                    if (Axis.SolderX[ID].status == 0 && Axis.SolderY[ID].status == 0)
                    {
                        Axis.SolderS[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.FrontSpeed, ProcessData.SolderList[ID][0].SolderData.FrontLen);
                        Axis.SolderS[ID + 1].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.FrontSpeed, ProcessData.SolderList[ID][0].SolderData.FrontLen);
                        LG.ImmediateStepNext(5);
                    }
                    break;
                case 5://第一段退锡
                    if (Axis.SolderS[ID].status == 0)
                    {
                        Axis.SolderS[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.BsckSpeed, ProcessData.SolderList[ID][0].SolderData.BackLen);
                        Axis.SolderS[ID + 1].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.BsckSpeed, ProcessData.SolderList[ID][0].SolderData.BackLen);
                        LG.ImmediateStepNext(6);
                    }
                    break;
                case 6://RZ到上锡点位
                    if (Axis.SolderS[ID].status == 0)
                    {
                        Axis.SolderR[ID].MC_MoveAbs(ProcessData.SolderList[ID][0].Pos.R);
                        Axis.SolderZ[ID].MC_MoveAbs(ProcessData.SolderList[ID][0].SolderData.Z);
                        LG.ImmediateStepNext(7);
                    }
                    break;
                case 7://第二段送锡
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status == 0 )
                    {
                        Axis.SolderS[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.FrontSpeed2, ProcessData.SolderList[ID][0].SolderData.FrontLen2);
                        Axis.SolderS[ID + 1].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.FrontSpeed2, ProcessData.SolderList[ID][0].SolderData.FrontLen2);
                        LG.ImmediateStepNext(8);
                    }
                    break;
                case 8://第二段退锡
                    if (Axis.SolderS[ID].status == 0)
                    {
                        Axis.SolderS[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.BsckSpeed2, ProcessData.SolderList[ID][0].SolderData.BackLen2);
                        Axis.SolderS[ID + 1].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.BsckSpeed2, ProcessData.SolderList[ID][0].SolderData.BackLen2);
                        LG.ImmediateStepNext(9);
                    }
                    break;
                case 9://第三段送锡
                    if (Axis.SolderS[ID].status == 0)
                    {
                        Axis.SolderS[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.FrontSpeed3, ProcessData.SolderList[ID][0].SolderData.FrontLen3);
                        Axis.SolderS[ID + 1].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.FrontSpeed3, ProcessData.SolderList[ID][0].SolderData.FrontLen3);
                        LG.ImmediateStepNext(10);
                    }
                    break;
                case 10://第三段退锡
                    if (Axis.SolderS[ID].status == 0)
                    {
                        Axis.SolderS[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.BsckSpeed3, ProcessData.SolderList[ID][0].SolderData.BackLen3);
                        Axis.SolderS[ID + 1].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.BsckSpeed3, ProcessData.SolderList[ID][0].SolderData.BackLen3);
                        LG.ImmediateStepNext(11);
                    }
                    break;
                case 11://判断是否开启抖动及抖动的模式
                    if (Axis.SolderS[ID].status == 0 && LG.Delay(1000))
                    {
                        if (ProcessData.SolderList[ID][0].SolderData.Shake)
                        {
                            //开启抖动
                            switch (ProcessData.SolderList[ID][0].SolderData.mode)
                            {
                                //case 0:
                                //    LG.StepNext(12, FSMStaDef.RUN);//上下
                                //    break;
                                case 1:
                                    LG.ImmediateStepNext(13);//左右
                                    break;
                                case 2:
                                    LG.ImmediateStepNext(14);//前后
                                    break;
                            }
                        }
                        else
                        {
                            //不开启抖动
                            LG.ImmediateStepNext(15);
                        }
                    }
                    break;
                #region 左右
                case 13:
                    Axis.SolderX[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.speed, ProcessData.SolderList[ID][0].SolderData.interval);
                    Axis.SolderZ[ID].MC_MoveRel(-ProcessData.SolderList[ID][0].SolderData.height/3.0f);
                    LG.ImmediateStepNext(131);
                    break;
                case 131:
                    if (Axis.SolderX[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.SolderX[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.speed, -2 * ProcessData.SolderList[ID][0].SolderData.interval);
                        Axis.SolderZ[ID].MC_MoveRel(-ProcessData.SolderList[ID][0].SolderData.height / 3.0f);
                        LG.ImmediateStepNext(132);
                    }
                   
                    break;
                case 132:
                    if (Axis.SolderX[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.SolderX[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.speed, ProcessData.SolderList[ID][0].SolderData.interval);
                        Axis.SolderZ[ID].MC_MoveRel(-ProcessData.SolderList[ID][0].SolderData.height / 3.0f);
                        LG.ImmediateStepNext(15);
                    }
                    break;
                #endregion
                #region 前后
                case 14:
                    Axis.SolderY[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.speed, ProcessData.SolderList[ID][0].SolderData.interval);
                    Axis.SolderZ[ID].MC_MoveRel(-ProcessData.SolderList[ID][0].SolderData.height / 3.0f);
                    LG.ImmediateStepNext(141);
                    break;
                case 141:
                    if (Axis.SolderY[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.SolderY[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.speed, -2 * ProcessData.SolderList[ID][0].SolderData.interval);
                        Axis.SolderZ[ID].MC_MoveRel(-ProcessData.SolderList[ID][0].SolderData.height / 3.0f);
                        LG.ImmediateStepNext(142);
                    }
                   
                    break;
                case 142:
                    if (Axis.SolderY[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.SolderY[ID].MC_MoveRel(ProcessData.SolderList[ID][0].SolderData.speed, ProcessData.SolderList[ID][0].SolderData.interval);
                        Axis.SolderZ[ID].MC_MoveRel(-ProcessData.SolderList[ID][0].SolderData.height / 3.0f);
                        LG.ImmediateStepNext(15);
                    }
                    break;
                #endregion
                case 15://Z抬起到设定高度
                    if (Axis.SolderY[ID].status == 0 && Axis.SolderZ[ID].status == 0 && LG.Delay(ProjectData.Instance.SaveData.SolderPlatform[ID].TimeforTin))
                    {
                        Axis.SolderZ[ID].MC_MoveRel(100, ProcessData.SolderList[ID][0].SolderData.LiftHeight);
                        LG.ImmediateStepNext(16);
                    }
                    break;
                case 16://移除第一个点
                    if ( Axis.SolderZ[ID].status == 0)
                    {
                        ProjectData.Instance.SaveData.SolderData[ID].SolderNum++;
                        ProcessData.SolderList[ID].RemoveAt(0);
                        ProjectData.Instance.Product.ProductCount();
                        LG.ImmediateStepNext(0xef);
                    }
                    break;
                case 0xef:
                    LG.End();
                    break;
            }
        }
    }
}
