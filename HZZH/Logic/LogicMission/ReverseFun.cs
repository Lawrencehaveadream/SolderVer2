using CommonRs;
using HzControl.Logic;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.LogicMission
{
    public class ReverseFun : LogicTask
    {
        private IOandAxisFun Axis = new IOandAxisFun();
        public ReverseFun():base("翻转")
        {
           
        }
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1://z抬高到翻转位置
                    if (DeviceRsDef.Axis_Z5.status == 0)
                    {
                        DeviceRsDef.Axis_Z5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.ReversZ);
                        LG.ImmediateStepNext(2);
                    }
                    break;
                case 2://XR到达工作的位置
                    if (DeviceRsDef.Axis_Z5.status == 0)
                    {
                        DeviceRsDef.Axis_X5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.WorkPos.X);
                        DeviceRsDef.Axis_R5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.WorkPos.R);
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://Z到达工作的位置
                    if (DeviceRsDef.Axis_X5.status == 0 && DeviceRsDef.Axis_R5.status == 0)
                    {
                        DeviceRsDef.Axis_Z5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.WorkPos.Z);
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://夹紧气缸打开
                    if (DeviceRsDef.Axis_Z5.status == 0)
                    {
                        DeviceRsDef.Q_BeforeTurnCyl.Value = true;
                        LG.ImmediateStepNext(5);
                    }
                    break;
                case 5://Z轴到翻转位置
                    if (LG.Delay(50)&& DeviceRsDef.I_BeforeTurnCylClosed.value)
                    {
                        DeviceRsDef.Axis_Z5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.ReversZ);
                        LG.ImmediateStepNext(6);
                    }
                    break;
                case 6://R轴旋转
                    if (DeviceRsDef.I_BeforeTurnCylClosed.value&& DeviceRsDef.Axis_Z5.status == 0)
                    {
                        DeviceRsDef.Axis_R5.MC_MoveSpd(1);
                        LG.ImmediateStepNext(7);
                    }
                    break;
                case 7://转到180度停止R
                    if (DeviceRsDef.I_BeforeTurnCylClosed.value && DeviceRsDef.I_TurnCyl180.value)
                    {
                        DeviceRsDef.Axis_R5.MC_Stop();
                        LG.ImmediateStepNext(8);
                    }
                    break;
                case 8://Z轴下降到工作位置
                    if (DeviceRsDef.I_BeforeTurnCylClosed.value && DeviceRsDef.I_TurnCyl180.value && DeviceRsDef.Axis_R5.status == 0)
                    {
                        DeviceRsDef.Axis_Z5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.WorkPos.Z);
                        LG.ImmediateStepNext(9);
                    }
                    break;
                case 9://夹紧气缸打开
                    if (DeviceRsDef.I_BeforeTurnCylClosed.value && DeviceRsDef.I_TurnCyl180.value && DeviceRsDef.Axis_Z5.status == 0)
                    {
                        DeviceRsDef.Q_BeforeTurnCyl.Value = false;
                        LG.ImmediateStepNext(11);
                    }
                    break;
                case 11://Z轴回到翻转位
                    if (LG.Delay(50))
                    {
                        DeviceRsDef.Axis_Z5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.ReversZ);
                        LG.ImmediateStepNext(12);
                    }
                    break;
                case 12://R轴回零度
                    if (LG.Delay(50) && DeviceRsDef.Axis_Z5.status == 0)
                    {
                        DeviceRsDef.Axis_R5.MC_MoveSpd(-1);
                        LG.ImmediateStepNext(13);
                    }
                    break;
                case 13://回零到位
                    if (DeviceRsDef.I_TurnCyl.value)
                    {
                        DeviceRsDef.Axis_R5.MC_Stop();
                        LG.ImmediateStepNext(14);
                    }
                    break;
                case 14://XZ到结束位置
                    if (DeviceRsDef.Axis_R5.status == 0)
                    {
                        DeviceRsDef.Axis_Z5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.EndPos.Z);
                        DeviceRsDef.Axis_X5.MC_MoveAbs(ProjectData.Instance.SaveData.ReverseData.EndPos.X);
                        LG.ImmediateStepNext(15);
                    }
                    break;
                case 15://结束
                    if (DeviceRsDef.Axis_X5.status == 0 && DeviceRsDef.Axis_Z5.status == 0)
                    {
                        LG.ImmediateStepNext(0xef);
                        ProjectData.Instance.SaveData.processdata.PlatformData[4].Isreversed = true;
                    }
                    break;
                case 0xef:
                    LG.End();
                    break;

















            }
        }
    }
    [Serializable]
    public class ReverseData
    {
        public PointF4 ResetPos { get; set; }
        public PointF4 EndPos { get; set; }
        public PointF4 WorkPos { get; set; }
        public float ReversZ { get; set; }
        public int ReverseSpend { get; set; }
        public ReverseData()
        {
            ResetPos = new PointF4();
            EndPos = new PointF4();
            WorkPos = new PointF4();
            ReversZ = 0;
        }
    }
}
