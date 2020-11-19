using CommonRs;
using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using ProCommon.Communal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMission
{
     public class PolishFun : LogicTask
    {
        public PolishFun(string name) : base(name + "打磨流程")
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
            PolishTimes = 0;
            PointPolishtimes = 0;
        }
        private  IOandAxisFun Axis = new IOandAxisFun();
        private int PointPolishtimes;
        private int ID { get; set; }
        /// <summary>
        /// 当前打磨了多少次
        /// </summary>
        public int PolishTimes { get; set; }
        protected override void LogicImpl()
        {
            var Para = ProjectData.Instance.SaveData.PolishData[ID];
            var ProcessData = ProjectData.Instance.SaveData.processdata;
            switch (LG.Step)
            {
               case 1:  // 有打磨点
                    if (ProjectData.Instance.SaveData.processdata.PolishList[ID].Count()>0)
                    {
                        LG.ImmediateStepNext(2);
                    }
                    else if (TaskManager.Default.FSM.MODE == 1)
                    {
                        LG.ImmediateStepNext(0xef);
                    }
                    else
                    {
                        string mes = ID.ToString() + "平台无打磨点";
                        MachineAlarm.SetAlarm(AlarmLevelEnum.Level2, mes);
                        LG.StepNext(0xef, FSMStaDef.RUN);
                    }
                    break;
                case 2://ZR抬高
                    if (Axis.PolishR[ID].status == 0 && Axis.PolishZ[ID].status == 0)
                    {
                        Axis.PolishR[ID].MC_MoveAbs(0);
                        Axis.PolishZ[ID].MC_MoveAbs(Para.SafeZ);
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://到打磨点XY
                    if (Axis.PolishR[ID].status == 0 && Axis.PolishZ[ID].status == 0)
                    {
                        PointPolishtimes = 0;
                        Axis.PolishX[ID].MC_MoveAbs(ProcessData.PolishList[ID][0].Pos.X);
                        Axis.PolishY[ID].MC_MoveAbs(ProcessData.PolishList[ID][0].Pos.Y);
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://到打磨点RZ
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishR[ID].MC_MoveAbs(ProcessData.PolishList[ID][0].Pos.R);
                        Axis.PolishZ[ID].MC_MoveAbs(ProcessData.PolishList[ID][0].polishData.Z + Para.TotalReimburse);
                        LG.ImmediateStepNext(5);
                    }
                    break;
                case 5://判断打磨方式
                    if (Axis.PolishR[ID].status == 0 && Axis.PolishZ[ID].status == 0)
                    {
                        //打磨方式
                        switch (ProcessData.PolishList[ID][0].polishData.mode)
                        {
                            case 0:
                                LG.ImmediateStepNext(6);//一字前后
                                break;
                            case 1:
                                LG.ImmediateStepNext(7);//一字左右
                                break;
                            case 2:
                                LG.ImmediateStepNext(8);//二字前后
                                break;
                            case 3:
                                LG.ImmediateStepNext(9);//二字左右
                                break;
                        }
                        
                    }   
                    break;
                #region 一字前后
                case 6:
                    Axis.PolishY[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                    LG.ImmediateStepNext(61);
                    break;
                case 61:
                    if (Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishY[ID].MC_MoveRel(-2 * ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(62);
                    }
                    break;
                case 62:
                    if (Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishY[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(10);
                    }
                    break;
                #endregion
                #region 一字左右
                case 7:
                    Axis.PolishX[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                    LG.ImmediateStepNext(71);
                    break;
                case 71:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(-2 * ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(72);
                    }
                    break;
                case 72:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(10);
                    }
                    break;
                #endregion
                #region 二字前后
                case 8:
                    Axis.PolishY[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                    LG.ImmediateStepNext(81);
                    break;
                case 81:
                    if (Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishY[ID].MC_MoveRel(-2 * ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(82);
                    }
                    break;
                case 82:
                    if (Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishY[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(83);
                    }
                    break;
                case 83:
                    if (Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.PolishInterval);
                        Axis.PolishY[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(84);
                    }
                    break;
                case 84:
                    if (Axis.PolishY[ID].status == 0 && Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishY[ID].MC_MoveRel( -2 * ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(85);
                    }
                    break;
                case 85:
                    if (Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishY[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(10);
                    }
                    break;

                #endregion
                #region 二字左右
                case 9:
                    Axis.PolishX[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                    LG.ImmediateStepNext(91);
                    break;
                case 91:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(-2 * ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(92);
                    }
                    break;
                case 92:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(93);
                    }
                    break;
                case 93:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishY[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.PolishInterval);
                        Axis.PolishX[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(94);
                    }
                    break;
                case 94:
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(-2 * ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(95);
                    }
                    break;
                case 95:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(ProcessData.PolishList[ID][0].polishData.GoBackRange);
                        LG.ImmediateStepNext(10);
                    }
                    break;
                #endregion
                case 10://判断打磨次数
                    PointPolishtimes++;
                    if (ProcessData.PolishList[ID][0].polishData.GoBackTimes > PointPolishtimes && Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        LG.ImmediateStepNext(5);//打磨次数未够，再次打磨
                    }
                    else
                    {
                        PointPolishtimes = 0;
                        LG.ImmediateStepNext(11);//打磨下一个点
                    }
                    Para.SumPolishTimes++;//总的打磨次数用于更换打磨头
                    PolishTimes++;
                    if (PolishTimes >= Para.Interval)//达到打磨补偿的次数
                    {
                        PolishTimes = 0;
                        Para.TotalReimburse += Para.Reimburse;
                    }
                    break;
                case 11 ://移打磨列表里第一个点
                    if (Axis.PolishZ[ID].status == 0)
                    {
                        Para.PolishNum++; 
                        Axis.PolishZ[ID].MC_MoveAbs(ProcessData.PolishList[ID][0].polishData.LiftHeight);//抬起到设定高度
                        ProcessData.PolishList[ID].RemoveAt(0);
                        LG.ImmediateStepNext(0xef);//打磨结束
                    }
                    break;
                case 0xef:
                    if (Axis.PolishZ[ID].status == 0)
                    {
                        LG.End();
                    }
                    break;
            }
        }
     }
}
