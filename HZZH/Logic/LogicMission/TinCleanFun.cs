using CommonRs;
using Device;
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
   public class TinCleanFun : LogicTask
    {
        public TinCleanFun(string name): base(name + "焊锡清洗模块")
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
        }
        private IOandAxisFun Axis = new IOandAxisFun();
        private int ID { get; set; }
        protected override void LogicImpl()
        {
            var para = ProjectData.Instance.SaveData.SolderCleanData[ID];
            switch (LG.Step)
            {
                case 1://RZ抬起
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status ==0)
                    {
                        Axis.SolderR[ID].MC_MoveAbs(0);
                        Axis.SolderZ[ID].MC_MoveAbs(0);
                        LG.ImmediateStepNext(2);
                    }
                    break;
                case 2://XY到清洗位
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.SolderX[ID].MC_MoveAbs(para.CleanPos.X);
                        Axis.SolderY[ID].MC_MoveAbs(para.CleanPos.Y);
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://RZ到清洗位
                    if (Axis.SolderX[ID].status == 0 && Axis.SolderY[ID].status == 0)
                    {
                        Axis.SolderR[ID].MC_MoveAbs(para.CleanPos.R);
                        Axis.SolderZ[ID].MC_MoveAbs(para.CleanPos.Z);
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://打开吹气电磁阀
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        Axis.Soldervalve[ID].ON();
                        LG.ImmediateStepNext(5);
                    }
                    break;
                case 5://吹气清洗时间
                    if (LG.Delay(para.CleanTime))
                    {
                        Axis.Soldervalve[ID].OFF();
                        LG.ImmediateStepNext(6);
                    }
                    break;
                case 6:
                    Axis.SolderR[ID].MC_MoveAbs(0);
                    Axis.SolderZ[ID].MC_MoveAbs(0);
                    LG.ImmediateStepNext(7);
                    break;
                case 7:
                    if (Axis.SolderR[ID].status == 0 && Axis.SolderZ[ID].status == 0)
                    {
                        LG.ImmediateStepNext(0xef);
                    }
                    break;
                case 0xef:
                    LG.End();
                    break;
            }
        }
    }
    
}
