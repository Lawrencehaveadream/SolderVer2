using HzControl.Logic;
using HZZH.Common.Config;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
//using MyControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMission
{
    public class BeltFeedFun : LogicTask
    {
        public BeltFeedFun() : base("皮带流程")
        {

        }
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    DeviceRsDef.Q_BeltLocatedCyl.Value = false;//打开环形导轨的定位气缸
                    if (DeviceRsDef.I_CylUnLocked.value && DeviceRsDef.I_material1.value)//环形定位气缸打开状态且有零件
                    {
                        LG.ImmediateStepNext(2);
                    }
                    else
                    {
                        if (TaskManager.Default.FSM.MODE == 1)
                        {
                            LG.ImmediateStepNext(2);
                        }
                        else
                        {
                            MachineAlarm.SetAlarm(AlarmLevelEnum.Level2, "零件未放入，零件感应1未感应到物料");
                            LG.StepNextWithOut(2, FSMStaDef.ALARM);
                        }
                    }
                    break;
                case 2:
                    if (
                        LG.Delay(500)         //气缸延时200ms
                        && TaskManager.Default.FindTask("左打磨平台").Status
                        && TaskManager.Default.FindTask("右打磨平台").Status
                        && TaskManager.Default.FindTask("左焊锡平台").Status
                        && TaskManager.Default.FindTask("右焊锡平台").Status
                        )
                    {
                        DeviceRsDef.Axis_Belt.MC_MoveRel(230);//传送带向前走230mm
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4:
                    if (LG.Delay(100))//延时100
                    {
                        DeviceRsDef.Axis_Belt.MC_Stop();//传送带停止
                        LG.ImmediateStepNext(5);
                    }
                    break;
                case 5:
                    if (DeviceRsDef.Axis_Belt.status == Device.AxState.AXSTA_READY)//皮带轴停止
                    {
                        DeviceRsDef.Q_BeltLocatedCyl.Value = true;//打开皮带的定位气缸
                        LG.ImmediateStepNext(6);
                    }
                    break;
                case 6:
                    if (LG.Delay(150) && DeviceRsDef.I_CylLocked.value)//环形定位气缸已经锁定，延时150ms
                    {
                        DeviceRsDef.Q_BeltLocatedCyl.Value = false;//关闭定位气缸
                        if (TaskManager.Default.FSM.MODE == 1)//老化模式
                        {
                            LG.ImmediateStepNext(7);
                        }
                        LG.ImmediateStepNext(0xef);
                    }
                    break;
                case 7:
                    if (LG.Delay(50))
                    {
                        LG.End();//老化模式下不进行平台的数据传递
                    }
                    break;
                case 0xef:
                    if (LG.Delay(50))
                    {
                        LG.End();
                        ProjectData.Instance.SaveData.processdata.PlatformData[0].IsTined = true;//第一个工位有料
                        for (int i = ProjectData.Instance.SaveData.processdata.PlatformData.Count() - 1; i > 0; i--)//工位信息传递
                        {
                            ProjectData.Instance.SaveData.processdata.PlatformData[i].SetLastPlatformData(ProjectData.Instance.SaveData.processdata.PlatformData[i - 1]);
                        }
                    }
                    break;
            }
        }
    }
}
