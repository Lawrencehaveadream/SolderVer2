using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    public class ResetLogicDef : LogicTask
    {
        private IOandAxisFun Axis;
        public ResetLogicDef() : base("整机复位")
        {
            Axis = new IOandAxisFun();
        }

        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    for (int i = 0; i < 60; i++)
                    {
                        //板卡输出去使能
                        DeviceRsDef.MotionCard.MotionFun.OutputOFF(i);
                        DeviceRsDef.MotionCard1.MotionFun.OutputOFF(i);

                    }
                    for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)//轴停止
                    {
                        DeviceRsDef.AxisList[i].MC_Stop();
                    }
                    MachineAlarm.ClearAlarm();//清除报警
                    LG.ImmediateStepNext(10);
                    break;
                case 10:
                    if (LG.Delay(2000))
                    {
                        //ZR轴回零
                        DeviceRsDef.Axis_Z1.MC_Home();
                        DeviceRsDef.Axis_Z2.MC_Home();
                        DeviceRsDef.Axis_Z3.MC_Home();
                        DeviceRsDef.Axis_Z4.MC_Home();
                        //DeviceRsDef.Axis_Z5.MC_Home();

                        DeviceRsDef.Axis_R1.MC_Home();
                        DeviceRsDef.Axis_R2.MC_Home();
                        DeviceRsDef.Axis_R3.MC_Home();
                        DeviceRsDef.Axis_R4.MC_Home();
                        LG.ImmediateStepNext(2);
                    }
                    break;
                case 2:
                    if (Axis.allaixsarrive())
                    {
                        DeviceRsDef.Axis_X1.MC_Home();
                        DeviceRsDef.Axis_X2.MC_Home();
                        DeviceRsDef.Axis_X3.MC_Home();
                        DeviceRsDef.Axis_X4.MC_Home();
                        //DeviceRsDef.Axis_X5.MC_Home();

                        DeviceRsDef.Axis_Y1.MC_Home();
                        DeviceRsDef.Axis_Y2.MC_Home();
                        DeviceRsDef.Axis_Y3.MC_Home();
                        DeviceRsDef.Axis_Y4.MC_Home();


                        //DeviceRsDef.Axis_R5.MC_Home();
                        //DeviceRsDef.Axis_X5.MC_Home();
                        //DeviceRsDef.Axis_Belt.MC_Home();
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3:
                    if (Axis.allaixsarrive())
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Axis.PolishX[i].MC_MoveAbs(ProjectData.Instance.SaveData.PolishPlatform[i].ResetPos.X);
                            Axis.PolishY[i].MC_MoveAbs(ProjectData.Instance.SaveData.PolishPlatform[i].ResetPos.Y);
                            Axis.PolishZ[i].MC_MoveAbs(ProjectData.Instance.SaveData.PolishPlatform[i].ResetPos.Z);
                            Axis.PolishR[i].MC_MoveAbs(ProjectData.Instance.SaveData.PolishPlatform[i].ResetPos.R);
                        }
                        for (int i = 0; i < 2; i++)
                        {
                            Axis.SolderX[i].MC_MoveAbs(ProjectData.Instance.SaveData.SolderPlatform[i].ResetPos.X);
                            Axis.SolderY[i].MC_MoveAbs(ProjectData.Instance.SaveData.SolderPlatform[i].ResetPos.Y);
                            Axis.SolderZ[i].MC_MoveAbs(ProjectData.Instance.SaveData.SolderPlatform[i].ResetPos.Z);
                            Axis.SolderR[i].MC_MoveAbs(ProjectData.Instance.SaveData.SolderPlatform[i].ResetPos.R);
                        }

                        LG.ImmediateStepNext(0xef);
                    }
                    break;
                case 0xef:
                    if (Axis.allaixsarrive())
                    {
                        LG.End();
                        TaskManager.Default.FSM.Change(FSMStaDef.STOP);
                    }
                    break;
            }
        }
    }
}
