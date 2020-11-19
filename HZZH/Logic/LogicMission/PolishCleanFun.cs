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
   public class PolishCleanFun : LogicTask
    {
        private IOandAxisFun Axis { get; set; }
        private int ID { get; set; }
        public PolishCleanFun(string name) : base(name + "打磨清洗模块")
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
            Axis = new IOandAxisFun();
        }
        /// <summary>
        /// 打磨次数
        /// </summary>
        private int times;
        protected override void LogicImpl()
        {
           var para = ProjectData.Instance.SaveData.PolishCleanData;
            switch (LG.Step)
            {
                case 1://RZ抬起
                    times = 0;
                    if (Axis.PolishR[ID].status == 0 && Axis.PolishZ[ID].status == 0)
                    {
                        Axis.PolishR[ID].MC_MoveAbs(0);
                        Axis.PolishZ[ID].MC_MoveAbs(para[ID].SafeZ);//Z抬起到安全位置
                        LG.ImmediateStepNext(2);
                    }
                    break;
                case 2://XY到清洗位
                    if (Axis.PolishR[ID].status == 0 && Axis.PolishZ[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveAbs(para[ID].CleanPos.X);
                        Axis.PolishY[ID].MC_MoveAbs(para[ID].CleanPos.Y);
                        LG.ImmediateStepNext(3);
                    }
                    break;
                case 3://RZ到清洗位
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishR[ID].MC_MoveAbs(para[ID].CleanPos.R);
                        Axis.PolishZ[ID].MC_MoveAbs(para[ID].CleanPos.Z);
                        LG.ImmediateStepNext(4);
                    }
                    break;
                case 4://选择模式
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        Axis.Polishvalve[ID].ON();
                        switch (para[ID].Mode)
                        {
                            case 1://一字左右
                                LG.ImmediateStepNext(5);
                                break;
                            case 2://二字左右
                                LG.ImmediateStepNext(6);
                                break;
                        }
                    }
                    break;
                #region 一字左右
                case 5:
                    Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, para[ID].range);
                    LG.ImmediateStepNext(51);
                    break;
                case 51:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, -2 * para[ID].range);
                        LG.ImmediateStepNext(52);
                    }
                    break;
                case 52:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, para[ID].range);
                        LG.ImmediateStepNext(53);
                    }
                    break;
                case 53:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        times++;
                        if (para[ID].CleanTimes <= times)//打磨次数足够 
                        {
                            LG.ImmediateStepNext(7);
                            times = 0;
                        }
                        else
                        {
                            LG.ImmediateStepNext(5);//打磨次数不够，继续打磨
                            
                        }
                    }
                    break;

                #endregion
                #region 二字左右
                case 6:
                    Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, para[ID].range);
                    LG.ImmediateStepNext(61);
                    break;
                case 61:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, -2 * para[ID].range);
                        LG.ImmediateStepNext(62);
                    }
                    break;
                case 62:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, para[ID].range);
                        LG.ImmediateStepNext(63);
                    }
                    break;
                case 63:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, para[ID].range);
                        Axis.PolishY[ID].MC_MoveRel(para[ID].CleanSpeed, para[ID].interval);
                        LG.ImmediateStepNext(64);
                    }
                    
                    break;
                case 64:
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, -2 * para[ID].range);
                        LG.ImmediateStepNext(65);
                    }
                    break;
                case 65:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveRel(para[ID].CleanSpeed, para[ID].range);
                        LG.ImmediateStepNext(66);
                    }
                    break;
                case 66:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        times++;
                        if (para[ID].CleanTimes <= times)
                        {
                            times = 0;
                            LG.ImmediateStepNext(7);
                        }
                        else
                        {
                            LG.ImmediateStepNext(6);
                        }
                    }
                    break;
                #endregion
                case 7:
                    if (Axis.PolishX[ID].status == 0)
                    {
                        Axis.PolishR[ID].MC_MoveAbs(para[ID].CleanEndPos.R);
                        Axis.PolishZ[ID].MC_MoveAbs(para[ID].CleanEndPos.Z);
                        LG.ImmediateStepNext(8);
                    }
                    break;
                case 8:
                    if (Axis.PolishR[ID].status == 0 && Axis.PolishZ[ID].status == 0)
                    {
                        Axis.PolishX[ID].MC_MoveAbs(para[ID].CleanEndPos.X);
                        Axis.PolishY[ID].MC_MoveAbs(para[ID].CleanEndPos.Y);
                        LG.ImmediateStepNext(0xef);
                    }
                    break;
                case 0xef:
                    if (Axis.PolishX[ID].status == 0 && Axis.PolishY[ID].status == 0)
                    {
                        LG.End();
                    }
                    break;
            }
        }
    }
    
}
