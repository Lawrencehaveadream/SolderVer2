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
   public class XYZRMove : LogicTask
    {
        private IOandAxisFun Axis { get; set; } = new IOandAxisFun();
        private int ID { get; set; }
        public XYZRMove(string name) : base(name + "轴移动流程")
        {
            switch (name)
            {
                case "左打磨":
                    ID = 0;
                    break;
                case "右打磨":
                    ID = 1;
                    break;
                case "左焊锡":
                    ID = 2;
                    break;
                case "右焊锡":
                    ID = 3;
                    break;
            }

        }
        
        protected override void LogicImpl()
        {
            switch (LG.Step)
            {
                case 1:
                    if (ID<=1)
                    {
                        Axis.PolishZ[ID].MC_MoveAbs(ProjectData.Instance.SaveData.PolishData[ID].SafeZ);
                        LG.ImmediateStepNext(2);
                    }
                    else if(ID > 1)
                    {
                        Axis.SolderZ[ID - 2].MC_MoveAbs(ProjectData.Instance.SaveData.SolderData[ID-2].SafeZ);
                        LG.ImmediateStepNext(2);
                    }
                    break;
                case 2:
                    if (ID <= 1 && Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0 &&  Axis.PolishZ[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.LocatedPointPos.X);
                        Axis.PolishY[ID].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y);
                        LG.ImmediateStepNext(3);
                    }
                    else if (ID > 1 && Axis.SolderX[ID - 2].status == 0 && Axis.SolderY[ID - 2].status == 0 &&  Axis.SolderZ[ID - 2].status == 0)
                    {
                        Axis.SolderX[ID - 2].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.LocatedPointPos.X);
                        Axis.SolderY[ID - 2].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y);
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3:
                    if (ID <= 1 && Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0  )
                    {
                        Axis.PolishR[ID].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.LocatedPointPos.R);
                        Axis.PolishZ[ID].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z);
                        LG.ImmediateStepNext(4);
                    }
                    else if ( ID > 1 && Axis.SolderX[ID - 2].status == 0 && Axis.SolderY[ID - 2].status == 0 )
                    {
                        Axis.SolderR[ID - 2].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.LocatedPointPos.R);
                        Axis.SolderZ[ID - 2].MC_MoveAbs(ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z);
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4:
                    if (ID <= 1 && Axis.PolishR[ID].status == 0 && Axis.PolishZ[ID].status == 0)
                    {
                        LG.End();
                    }
                    else if (ID > 1 && Axis.SolderR[ID - 2].status == 0 && Axis.SolderZ[ID - 2].status == 0)
                    {
                        LG.End();
                    }
                    break;
            }
        }
    }
}
