using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    public class LogicLoopRun : LogicLoop
    {
        private IOandAxisFun Axis { get; set; }
        public LogicLoopRun() : base("报警等循环扫描")
        {
            Axis = new IOandAxisFun();
        }
        public void ButtonEvent()
        {
            if (DeviceRsDef.I_LStart.value || DeviceRsDef.I_RStart.value )
            {
                TaskManager.Default.FSM.Change(FSMStaDef.RUN);
            }
            if (DeviceRsDef.I_LStop.value || DeviceRsDef.I_RStop.value)
            {
                TaskManager.Default.FSM.Change(FSMStaDef.STOP);
            }
            if (DeviceRsDef.I_Emergency.value)
            {
                TaskManager.Default.FSM.Change(FSMStaDef.SCRAM);
                for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                {
                    DeviceRsDef.AxisList[i].MC_Stop();
                }
            }
            if (DeviceRsDef.I_LReset.value || DeviceRsDef.I_RReset.value)
            {
                TaskManager.Default.FSM.Change(FSMStaDef.RESET);
            }
            if (Axis.F_Trig(DeviceRsDef.I_Emergency.value))
            {
                TaskManager.Default.FSM.Change(FSMStaDef.INIT);
            }
        }
        protected override void LogicImpl()
        {
            //报警等级为2
            if (MachineAlarm.AlarmLever == AlarmLevelEnum.Level2)
            {
                this.Manager.FSM.Change(FSMStaDef.ALARM);
            }
            else if (MachineAlarm.AlarmLever > AlarmLevelEnum.Level2)
            {
                this.Manager.FSM.Change(FSMStaDef.ERROR);
            }

            for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
            {
                if (DeviceRsDef.AxisList[i].status == Device.AxState.AXSTA_ERRSTOP)
                {
                    string alarmMessage = DeviceRsDef.AxisList[i].errMesg;
                    MachineAlarm.SetAlarm(AlarmLevelEnum.Level3, alarmMessage);
                }
            }
            ButtonEvent();
        }
    }
}
