using HzControl.Logic;
using HZZH.Logic.Data;
using HZZH.Logic.LogicMission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.Logic.LogicMain
{
    public class LogicMainDef : LogicTask
    {
        public LogicMainDef() : base("Main")
        {
            
        }
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    TaskManager.Default.FindTask("皮带流程").Start();
                    LG.ImmediateStepNext(2);
                    break;
                case 2:
                    if (TaskManager.Default.FindTask("皮带流程").Status)
                    {
                        TaskManager.Default.FindTask("左打磨平台").Start();
                        TaskManager.Default.FindTask("右打磨平台").Start();
                        TaskManager.Default.FindTask("右焊锡平台").Start();
                        TaskManager.Default.FindTask("左焊锡平台").Start();
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3:
                    if (
                           TaskManager.Default.FindTask("左打磨平台").Status
                        && TaskManager.Default.FindTask("右打磨平台").Status
                        && TaskManager.Default.FindTask("右焊锡平台").Status
                        && TaskManager.Default.FindTask("左焊锡平台").Status
                        )
                    {
                        LG.ImmediateStepNext(0xef);
                    }
                    break;
                case 0xef:
                    if (TaskManager.Default.FSM.MODE == 1 && LG.Delay(2000))
                    {
                        LG.ImmediateStepNext(1);
                    }
                    else
                    {
                        LG.End();
                        TaskManager.Default.FSM.Change(FSMStaDef.STOP);
                    }
                    break;
            }
        }
    }
}
