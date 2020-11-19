using CommonRs;
using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using MyControl;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMission
{
   public class SolderPlatform : LogicTask
    {
        /// <summary>
        /// 每几个点去清洗
        /// </summary>
       
        public SolderCTFun SolderCT { get; set; }
        public SolderFun Solder { set; get; }
        public TinCleanFun SolderClean { get; set; }
        private IOandAxisFun Axis;
        private Stopwatch stick1SpendTime = new Stopwatch();
        public SolderPlatform(string name) : base(name + "焊锡平台")
        {
            SolderClean = new TinCleanFun(name);
            SolderCT = new SolderCTFun(name);
            Solder = new SolderFun(name);
            Axis = new IOandAxisFun();
            switch (name)
            {
                case "左":
                    ID = 0;
                    break;
                case "右":
                    ID = 1;
                    break;
            }
        }
        private int ID { get; set; }
        protected override void LogicImpl()
        {
            var para = ProjectData.Instance.SaveData.SolderPlatform[ID];
            switch (LG.Step)
            {
                case 1://平台到位
                    stick1SpendTime.Restart();
                    if (Axis.SolderPlatFormIsHave[ID].value && ProjectData.Instance.SaveData.processdata.PlatformData[ID * 4 + 1].IsHave
                        && ProjectData.Instance.SaveData.processdata.PlatformData[ID * 4 + 1].IsPolished || TaskManager.Default.FSM.MODE == 1)
                    {
                        LG.ImmediateStepNext(2);
                    }
                    else
                    {
                        string mes = ID.ToString() + "平台未有料或未打磨";
                        MachineAlarm.SetAlarm(AlarmLevelEnum.Level2, mes);
                        LG.StepNext(2,FSMStaDef.RUN);
                    }
                    break;
                case 2://开始上锡拍照
                    if (DeviceRsDef.I_CylLocked.value || TaskManager.Default.FSM.MODE == 1)
                    {
                        SolderCT.Start();
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://开始上锡
                    if (SolderCT.GetSta() == 0 && SolderClean.GetSta() == 0)
                    {
                        Solder.Start();
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://上锡结束是否清洗
                    if (Solder.GetSta() == 0 && ProjectData.Instance.SaveData.SolderData[ID].SolderNum % para.PerTimesClean == 0 && ProjectData.Instance.SaveData.processdata.SolderList[ID].Count() > 0)
                    {
                        ProjectData.Instance.SaveData.SolderData[ID].SolderNum = 0;
                        SolderClean.Start();
                        LG.ImmediateStepNext(3);
                        para.SolderSum++;
                    }
                    else if (Solder.GetSta() == 0 && ProjectData.Instance.SaveData.processdata.SolderList[ID].Count() > 0 )
                    {
                        LG.ImmediateStepNext(3);
                        para.SolderSum++;
                    }
                    else if (Solder.GetSta() == 0 && ProjectData.Instance.SaveData.processdata.SolderList[ID].Count() == 0)
                    {
                        SolderClean.Start();
                        LG.ImmediateStepNext(5);
                    }
                    break;
                case 5://ZR回到既定高度
                    if (Axis.SolderZ[ID].status == 0 && Axis.SolderR[ID].status == 0 && SolderClean.GetSta() == 0)
                    {
                        Axis.SolderZ[ID].MC_MoveAbs(para.EndPos.Z);
                        Axis.SolderR[ID].MC_MoveAbs(para.EndPos.R);
                        LG.ImmediateStepNext(6);
                    }
                    break;
                case 6://ZR回到既定高度
                    if (Axis.SolderZ[ID].status == 0 && Axis.SolderR[ID].status == 0)
                    {
                        Axis.SolderX[ID].MC_MoveAbs(para.EndPos.X);
                        Axis.SolderY[ID].MC_MoveAbs(para.EndPos.Y);
                        LG.ImmediateStepNext(0xef);
                    }
                    break;
                case 0xef:
                    if (Axis.SolderX[ID].status == 0 && Axis.SolderY[ID].status == 0)
                    {
                        LG.End();
                        stick1SpendTime.Stop();
                        para.SolderSpendTime = stick1SpendTime.ElapsedMilliseconds;
                        //ProjectData.Instance.SaveData.processdata.PlatformData[ID * 4 + 1].IsTined = true;
                    }
                    break;
            }
        }
    }
    /// <summary>
    /// 焊锡平台数据
    /// </summary>
    [Serializable]
    public class SolderPlatformPara
    {
        /// <summary>
        /// 焊锡等待时间
        /// </summary>
        public int TimeforTin { get; set; }
        /// <summary>
        /// 是否启用焊锡R轴补偿
        /// </summary>
        public bool UseR { get; set; }
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
        public int PerTimesClean { get; set; }
        /// <summary>
        /// 焊锡平台周期
        /// </summary>
        public double SolderSpendTime { get;  set; }
        /// <summary>
        /// 焊锡总次数
        /// </summary>
        public int SolderSum { get; set; }
        /// <summary>
        /// 焊锡头机械位置
        /// </summary>
        public PointF2 machineSolder { get; set; }
        /// <summary>
        /// 焊锡头相机位置
        /// </summary>
        public PointF2 machineSoldercamera { get; set; }
        public TeachingMechinePra teachingMechine { get; set; }
        public SolderPlatformPara()
        {
            machineSolder = new PointF2();
            machineSoldercamera = new PointF2();
            ResetPos = new PointF4();
            EndPos = new PointF4();
            teachingMechine = new TeachingMechinePra();
            UseR = false;
            PerTimesClean = 1;
        }
    }
}
