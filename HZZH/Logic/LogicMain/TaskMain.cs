using HzControl.Logic;
using HZZH.Logic.LogicMission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMain
{
    public class TaskMain
    {
        public TaskMain()
        {
            Init();
        }
        public static LogicMainDef LogicMain { get; set; } = new LogicMainDef();
        public static ResetLogicDef ResetLogic { get; set; } = new ResetLogicDef();
        public static LogicLoopRun LogicLoop { get; set; } = new LogicLoopRun();
        /// <summary>
        /// 传送带
        /// </summary>
        public static BeltFeedFun Belt { get; set; } = new BeltFeedFun();
        /// <summary>
        /// 左侧打磨平台
        /// </summary>
        public static PolishPlatform LPolishPlatform { get; set; } = new PolishPlatform("左");
        /// <summary>
        /// 右侧打磨平台
        /// </summary>
        public static PolishPlatform RPolishPlatform { get; set; } = new PolishPlatform("右");
        /// <summary>
        /// 左上锡平台
        /// </summary>
        public static SolderPlatform LSolderPlatform { get; set; } = new SolderPlatform("左");
        /// <summary>
        /// 右上锡平台
        /// </summary>
        public static SolderPlatform RSolderPlatform { get; set; } = new SolderPlatform("右");
        /// <summary>
        /// 翻转平台
        /// </summary>
        public static ReverseFun Reverse { get; set; } = new ReverseFun();



        public static XYZRMove LPolishXYZR { get; set; } = new XYZRMove("左打磨");
        public static XYZRMove RPolishXYZR { get; set; } = new XYZRMove("右打磨");
        public static XYZRMove LSolderXYZR { get; set; } = new XYZRMove("左焊锡");
        public static XYZRMove RSolderXYZR { get; set; } = new XYZRMove("右焊锡");
        public  void Init()
        {
            TaskManager.Default.FSM.ChangeState += FSM_ChangeState;
            TaskManager.Default.Add(LogicMain);
            TaskManager.Default.Add(ResetLogic);
            TaskManager.Default.Add(LogicLoop);
            TaskManager.Default.Add(Belt);
            TaskManager.Default.Add(LPolishPlatform);
            TaskManager.Default.Add(RPolishPlatform);
            TaskManager.Default.Add(LSolderPlatform);
            TaskManager.Default.Add(RSolderPlatform);
            TaskManager.Default.Add(Reverse);
            TaskManager.Default.Add(LPolishXYZR);
            TaskManager.Default.Add(RPolishXYZR);
            TaskManager.Default.Add(LSolderXYZR);
            TaskManager.Default.Add(RSolderXYZR);
        }

        private static void FSM_ChangeState(object sender, FSMChangeEventArgs e)
        {
            //
            if (e.State.ID == FSMStaDef.RUN)
            {
                LogicMain.Start();
            }
            // 复位逻辑卷运行
            if (e.State.ID == FSMStaDef.RESET)
            {
                ResetLogic.Start();
            }
            // 点击停止，部分逻辑可能不能停止，需要继续运行
            if (e.State.ID == FSMStaDef.STOP)
            {
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                    if (item.Name != "")
                    {
                        item.Stop();
                    }
                }
            }
            // 急停，所有的逻辑全部停止
            if (e.State.ID == FSMStaDef.SCRAM || e.State.ID == FSMStaDef.ERROR)
            {
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                    item.Stop();
                }
            }
            if (e.State.ID == FSMStaDef.ALARM)
            {
                foreach (var item in TaskManager.Default.LogicTasks)
                {
                    if (item.Name != "")
                    {
                        item.Stop();
                    }
                }
            }
        }
    }
}
