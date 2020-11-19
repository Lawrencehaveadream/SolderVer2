using CommonRs;
using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMission
{
   public class PolishPlatform : LogicTask
    {
        private IOandAxisFun Axis;
        /// <summary>
        /// 打磨拍照流程
        /// </summary>
        public PolishCTFun PolishCT { get; set; }
        /// <summary>
        /// 打磨流程
        /// </summary>
        public PolishFun Polish { get; set; }
        /// <summary>
        /// 打磨清洗流程
        /// </summary>
        public PolishCleanFun PolishClean { get; set; }
        private Stopwatch stick1SpendTime = new Stopwatch();
        public PolishPlatform(string name) : base(name + "打磨平台" )
        {
            PolishCT = new PolishCTFun(name);
            Polish = new PolishFun(name);
            PolishClean = new PolishCleanFun(name);
            switch (name)
            {
                case "左":
                    ID = 0;
                    break;
                case "右":
                    ID = 1;
                    break;
            }
            Axis = new IOandAxisFun();
        }
        /// <summary>
        /// 平台编号
        /// </summary>
        private int ID { get; set; }
        protected override void LogicImpl()
        {
            var para = ProjectData.Instance.SaveData.PolishPlatform[ID];
            switch (LG.Step)
            {
                case 1://平台到位
                    stick1SpendTime.Restart();
                    if (Axis.PolishPlatFormIsHave[ID].value && ProjectData.Instance.SaveData.processdata.PlatformData[1].IsHave || TaskManager.Default.FSM.MODE == 1)
                    {
                        LG.ImmediateStepNext(2);
                    }
                    else
                    {
                        string mes = ID.ToString() + "平台无料";
                        MachineAlarm.SetAlarm(AlarmLevelEnum.Level2, mes);
                        LG.StepNext(2,FSMStaDef.RUN);
                    }
                    break;
                case 2://开始打磨拍照
                    if (DeviceRsDef.I_CylLocked.value || TaskManager.Default.FSM.MODE == 1)
                    {
                        stick1SpendTime.Restart();
                        PolishCT.Start();
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://开始打磨
                    if (PolishCT.Status && PolishClean.Status)
                    {
                        Polish.Start();
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://打磨结束
                    if (Polish.Status && ProjectData.Instance.SaveData.PolishData[ID].PolishNum % para.PerTtimesClean == 0 && ProjectData.Instance.SaveData.processdata.PolishList[ID].Count() > 0)
                    {
                        ProjectData.Instance.SaveData.PolishData[ID].PolishNum = 0;
                        PolishClean.Start();
                        LG.ImmediateStepNext(3);
                        para.PolishSum++;
                    }
                    else if(Polish.Status && ProjectData.Instance.SaveData.processdata.PolishList[ID].Count() > 0 )
                    {
                        LG.ImmediateStepNext(3);
                        para.PolishSum++;
                    }
                    else if(Polish.Status && ProjectData.Instance.SaveData.processdata.PolishList[ID].Count() == 0)
                    {
                        LG.ImmediateStepNext(5);
                    }
                    break;
                case 5://打磨结束RZ回零
                    if (Axis.PolishZ[ID].status == 0 && Axis.PolishR[ID].status == 0)
                    {
                        Axis.PolishZ[ID].MC_MoveAbs(para.EndPos.Z);
                        Axis.PolishR[ID].MC_MoveAbs(para.EndPos.R);
                        LG.ImmediateStepNext(6);
                    }
                    break;
                case 6://打磨结束XY回零
                    if (Axis.PolishZ[ID].status == 0 && Axis.PolishR[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveAbs(para.EndPos.X);
                        Axis.PolishY[ID].MC_MoveAbs(para.EndPos.Y);
                        if (TaskManager.Default.FSM.MODE == 1)//老化模式
                        {
                            LG.ImmediateStepNext(7);
                        }
                        else
                        {
                            LG.ImmediateStepNext(0xef);
                        }

                    }
                    break;
                case 7:
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        stick1SpendTime.Stop();
                        para.PolishSpendTime = stick1SpendTime.ElapsedMilliseconds;
                        LG.End();//老化模式下不进行平台数据的传递
                    }
                    break;
                case 0xef:
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        stick1SpendTime.Stop();
                        para.PolishSpendTime = stick1SpendTime.ElapsedMilliseconds;
                        LG.End();
                        //ProjectData.Instance.SaveData.processdata.PlatformData[ID * 4 + 1].IsPolished = true;
                    }
                    break;

            }
        }
    }

    /// <summary>
    /// 打磨平台数据
    /// </summary>
    [Serializable]
    public class PolishPlatformPara
    {
        /// <summary>
        /// 复位位置
        /// </summary>
        public PointF4 ResetPos { get; set; }
        /// <summary>
        /// 结束位置
        /// </summary>
        public PointF4 EndPos { get; set; }
        /// <summary>
        /// 每几个点去清洗
        /// </summary>
        public int PerTtimesClean { get; set; }
        /// <summary>
        /// 打磨平台使用时间
        /// </summary>
        public double PolishSpendTime { get;  set; }
        /// <summary>
        /// 打磨总数
        /// </summary>
        public int PolishSum { get; set; }
        /// <summary>
        /// 打磨头机械位置
        /// </summary>
        public PointF2 machinePolish { get; set; }
        /// <summary>
        /// 打磨头相机机械位置
        /// </summary>
        public PointF2 machinePolishcarmera { get; set; }
        public PolishPlatformPara()
        {
            machinePolish = new PointF2();
            machinePolishcarmera = new PointF2();
            ResetPos = new PointF4();
            EndPos = new PointF4();
        }
    }
}
