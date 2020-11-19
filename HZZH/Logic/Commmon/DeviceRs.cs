using CommonRs;
using Device;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HZZH.Logic.Commmon
{
    public enum InIndex : int   //输入口定义
    {
        X1, X2, X3, X4, X5, X6, X7, X8, X9, X10, X11, X12, X13, X14, X15, X16, X17, X18, X19, X20, X21, X22, X23, X24, X25, X26, X27, X28, X29, X30,
        X31, X32, X33, X34, X35, X36, X37, X38, X39, X40, X41, X42, X43, X44, X45, X46, X47, X48, X49, X50, X51, X52, X53, X54, X55, X56, X57, X58, X59, X60,
    }
    public enum OutIndex : int	//输入口定义
    {
        Y1, Y2, Y3, Y4, Y5, Y6, Y7, Y8, Y9, Y10, Y11, Y12, Y13, Y14, Y15, Y16, Y17, Y18, Y19, Y20, Y21, Y22, Y23, Y24, Y25, Y26, Y27, Y28, Y29, Y30, Y31, Y32,
    }
    public static class DeviceRsDef
    {
        /// <summary>
        /// 轴列表4
        /// </summary>
        public readonly static List<AxisClass> AxisList = new List<AxisClass>();
        /// <summary>
        /// 输入列表
        /// </summary>
        public readonly static List<InputClass> InputList = new List<InputClass>();
        /// <summary>
        /// 输出列表
        /// </summary>
        public readonly static List<OutputClass> OutputList = new List<OutputClass>();

        static DeviceRsDef()
        {
            foreach (var item in typeof(DeviceRsDef).GetFields(System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public))
            {
                if (item.FieldType == typeof(AxisClass))
                {
                    AxisList.Add((AxisClass)item.GetValue(null));
                }

                if (item.FieldType == typeof(InputClass))
                {
                    InputList.Add((InputClass)item.GetValue(null));
                }

                if (item.FieldType == typeof(OutputClass))
                {
                    OutputList.Add((OutputClass)item.GetValue(null));
                }
            }

        }
        public static MotionCardDef MotionCard = new MotionCardDef("192.168.1.30", 8089);
        public static MotionCardDef MotionCard1 = new MotionCardDef("192.168.1.31", 8090);

        #region 轴定义
        public static AxisClass Axis_X1 = new AxisClass(MotionCard, 0, "焊锡X1轴");
        public static AxisClass Axis_Y1 = new AxisClass(MotionCard, 1, "焊锡Y1轴");
        public static AxisClass Axis_Z1 = new AxisClass(MotionCard, 2, "焊锡Z1轴");
        public static AxisClass Axis_R1 = new AxisClass(MotionCard1, 8, "焊锡R1轴");
        public static AxisClass Axis_S1_1 = new AxisClass(MotionCard, 4, "焊锡S1_1轴");
        public static AxisClass Axis_S1_2 = new AxisClass(MotionCard, 5, "焊锡S1_2轴");


        public static AxisClass Axis_X2 = new AxisClass(MotionCard, 6, "焊锡X2轴");
        public static AxisClass Axis_Y2 = new AxisClass(MotionCard, 7, "焊锡Y2轴");
        public static AxisClass Axis_Z2 = new AxisClass(MotionCard, 8, "焊锡Z2轴");
        public static AxisClass Axis_R2 = new AxisClass(MotionCard, 9, "焊锡R2轴");
        public static AxisClass Axis_S2_1 = new AxisClass(MotionCard, 10, "焊锡S2_1轴");
        public static AxisClass Axis_S2_2 = new AxisClass(MotionCard, 11, "焊锡S2_1轴");

        public static AxisClass Axis_X3 = new AxisClass(MotionCard, 12, "打磨1-X3轴");
        public static AxisClass Axis_Y3 = new AxisClass(MotionCard, 13, "打磨1-Y3轴");
        public static AxisClass Axis_Z3 = new AxisClass(MotionCard, 15, "打磨1-Z3轴");
        public static AxisClass Axis_R3 = new AxisClass(MotionCard, 14, "打磨1-R3轴");

        public static AxisClass Axis_X4 = new AxisClass(MotionCard1, 0, "打磨2-X4轴");
        public static AxisClass Axis_Y4 = new AxisClass(MotionCard1, 1, "打磨2-Y4轴");
        public static AxisClass Axis_Z4 = new AxisClass(MotionCard1, 2, "打磨2-Z4轴");
        public static AxisClass Axis_R4 = new AxisClass(MotionCard1, 3, "打磨2-R4轴");

        public static AxisClass Axis_X5 = new AxisClass(MotionCard1, 4, "翻转X5轴");
        public static AxisClass Axis_Z5 = new AxisClass(MotionCard1, 5, "翻转Z5轴");
        public static AxisClass Axis_R5 = new AxisClass(MotionCard1, 6, "翻转R5轴");
        public static AxisClass Axis_Belt = new AxisClass(MotionCard1, 7, "环形导轨");
        //public static AxisClass B5 = new AxisClass(MotionCard1, 8, "备用");
        //public static AxisClass B6 = new AxisClass(MotionCard1, 9, "备用");
        //public static AxisClass B7 = new AxisClass(MotionCard1, 10, "备用");
        //public static AxisClass B8 = new AxisClass(MotionCard1, 11, "备用");
        //public static AxisClass B9 = new AxisClass(MotionCard1, 12, "备用");

        #endregion

        #region 输入定义
        /// <summary>
        /// 焊锡X1原点
        /// </summary>
        public static InputClass I_LSolder_X = new InputClass(MotionCard, (int)InIndex.X1, "焊锡X1原点");
        /// <summary>
        /// 焊锡Y1原点
        /// </summary>
        public static InputClass I_LSolder_Y = new InputClass(MotionCard, (int)InIndex.X2, "焊锡Y1原点");
        /// <summary>
        /// 焊锡Z1原点
        /// </summary>
        public static InputClass I_LSolder_Z = new InputClass(MotionCard, (int)InIndex.X3, "焊锡Z1原点");
        /// <summary>
        /// 焊锡R1原点
        /// </summary>
        public static InputClass I_LSolder_R = new InputClass(MotionCard1, (int)InIndex.X1, "焊锡R1原点");
        /// <summary>
        /// 焊锡S1-1原点
        /// </summary>
        public static InputClass I_LSolder_S1 = new InputClass(MotionCard, (int)InIndex.X5, "焊锡S1-1原点");
        /// <summary>
        /// 焊锡S1-2原点
        /// </summary>
        public static InputClass I_LSolder_S2 = new InputClass(MotionCard, (int)InIndex.X6, "焊锡S1-2原点");
        /// <summary>
        /// 焊锡X2原点
        /// </summary>
        public static InputClass I_RSolder_X = new InputClass(MotionCard, (int)InIndex.X7, "焊锡X2原点");
        /// <summary>
        /// 焊锡Y2原点
        /// </summary>
        public static InputClass I_RSolder_Y = new InputClass(MotionCard, (int)InIndex.X8, "焊锡Y2原点");
        /// <summary>
        /// 焊锡Z2原点
        /// </summary>
        public static InputClass I_RSolder_Z = new InputClass(MotionCard, (int)InIndex.X9, "焊锡Z2原点");
        /// <summary>
        /// 焊锡R2原点
        /// </summary>
        public static InputClass I_RSolder_R = new InputClass(MotionCard, (int)InIndex.X10, "焊锡R2原点");
        /// <summary>
        /// 焊锡S2_1原点
        /// </summary>
        public static InputClass I_RSolder_S1 = new InputClass(MotionCard, (int)InIndex.X11, "焊锡S2_1原点");
        /// <summary>
        /// 焊锡S2_2原点
        /// </summary>
        public static InputClass I_RSolder_S2 = new InputClass(MotionCard, (int)InIndex.X12, "焊锡S2_2原点");
        /// <summary>
        /// 打磨X1原点
        /// </summary>
        public static InputClass I_LPolish_X = new InputClass(MotionCard, (int)InIndex.X13, "打磨X1原点");
        /// <summary>
        /// 打磨Y1原点
        /// </summary>
        public static InputClass I_LPolish_Y = new InputClass(MotionCard, (int)InIndex.X14, "打磨Y1原点");
        /// <summary>
        /// 打磨Z1原点
        /// </summary>
        public static InputClass I_LPolish_Z = new InputClass(MotionCard, (int)InIndex.X15, "打磨Z1原点");
        /// <summary>
        /// 打磨R1原点
        /// </summary>
        public static InputClass I_LPolish_R = new InputClass(MotionCard, (int)InIndex.X16, "打磨R1原点");
        /// <summary>
        /// 打磨X2原点
        /// </summary>
        public static InputClass I_RPolish_X = new InputClass(MotionCard1, (int)InIndex.X2, "打磨X2原点");
        /// <summary>
        /// 打磨Y2原点
        /// </summary>
        public static InputClass I_RPolish_Y = new InputClass(MotionCard1, (int)InIndex.X3, "打磨Y2原点");
        /// <summary>
        /// 打磨Z2原点
        /// </summary>
        public static InputClass I_RPolish_Z = new InputClass(MotionCard1, (int)InIndex.X4, "打磨Z2原点");
        /// <summary>
        /// 打磨R2原点
        /// </summary>
        public static InputClass I_RPolish_R = new InputClass(MotionCard1, (int)InIndex.X5, "打磨R2原点");
        /// <summary>
        /// 启动1
        /// </summary>
        public static InputClass I_LStart = new InputClass(MotionCard, (int)InIndex.X21, "启动1");
        /// <summary>
        /// 停止1
        /// </summary>
        public static InputClass I_LStop = new InputClass(MotionCard, (int)InIndex.X22, "停止1");
        /// <summary>
        /// 复位1
        /// </summary>
        public static InputClass I_LReset = new InputClass(MotionCard, (int)InIndex.X23, "复位1");
        /// <summary>
        /// 进锡1-1
        /// </summary>
        public static InputClass I_LFeedtin_1 = new InputClass(MotionCard, (int)InIndex.X24, "进锡1-1");
        /// <summary>
        /// 进锡1-2
        /// </summary>
        public static InputClass I_LFeedtin_2 = new InputClass(MotionCard, (int)InIndex.X25, "进锡1-2");
        /// <summary>
        /// 退锡1-1
        /// </summary>
        public static InputClass I_LUnFeedtin_1 = new InputClass(MotionCard, (int)InIndex.X26, "退锡1-1");
        /// <summary>
        /// 退锡1-2
        /// </summary>
        public static InputClass I_LUnFeedtin_2 = new InputClass(MotionCard, (int)InIndex.X27, "退锡1-2");
        /// <summary>
        /// 进锡1-1
        /// </summary>
        public static InputClass I_RFeedtin_1 = new InputClass(MotionCard, (int)InIndex.X28, "进锡1-1");
        /// <summary>
        /// 进锡1-2
        /// </summary>
        public static InputClass I_RFeedtin_2 = new InputClass(MotionCard, (int)InIndex.X29, "进锡1-2");
        /// <summary>
        /// 退锡1-1
        /// </summary>
        public static InputClass I_RUnFeedtin_1 = new InputClass(MotionCard, (int)InIndex.X30, "退锡1-1");
        /// <summary>
        /// 退锡1-2
        /// </summary>
        public static InputClass I_RUnFeedtin_2 = new InputClass(MotionCard, (int)InIndex.X31, "退锡1-2");
        /// <summary>
        /// 启动2
        /// </summary>
        public static InputClass I_RStart = new InputClass(MotionCard, (int)InIndex.X32, "启动2");
        /// <summary>
        /// 停止2
        /// </summary>
        public static InputClass I_RStop = new InputClass(MotionCard, (int)InIndex.X33, "停止2");
        /// <summary>
        /// 复位2
        /// </summary>
        public static InputClass I_RReset = new InputClass(MotionCard, (int)InIndex.X34, "复位2");
        /// <summary>
        /// 急停
        /// </summary>
        public static InputClass I_Emergency = new InputClass(MotionCard, (int)InIndex.X35, "急停");
        /// <summary>
        /// 送锡感应1
        /// </summary>
        public static InputClass I_LTinsensor1 = new InputClass(MotionCard, (int)InIndex.X36, "送锡感应1");
        /// <summary>
        /// 送锡开关1
        /// </summary>
        public static InputClass I_LTinswitch1 = new InputClass(MotionCard, (int)InIndex.X37, "送锡开关1");
        /// <summary>
        /// 送锡感应2
        /// </summary>
        public static InputClass I_LTinsensor2 = new InputClass(MotionCard, (int)InIndex.X38, "送锡感应2");
        /// <summary>
        /// 送锡开关2
        /// </summary>
        public static InputClass I_LTinswitch2 = new InputClass(MotionCard, (int)InIndex.X39, "送锡开关2");
        /// <summary>
        /// 送锡感应3
        /// </summary>
        public static InputClass I_RTinsensor1 = new InputClass(MotionCard, (int)InIndex.X40, "送锡感应3");
        /// <summary>
        /// 送锡开关3
        /// </summary>
        public static InputClass I_RTinswitch1 = new InputClass(MotionCard, (int)InIndex.X41, "送锡开关3");
        /// <summary>
        /// 送锡感应4
        /// </summary>
        public static InputClass I_RTinsensor2 = new InputClass(MotionCard, (int)InIndex.X42, "送锡感应4");
        /// <summary>
        /// 送锡开关4
        /// </summary>
        public static InputClass I_RTinswitch2 = new InputClass(MotionCard, (int)InIndex.X43, "送锡开关4");
        /// <summary>
        /// 环形线滑块原点信号
        /// </summary>
        public static InputClass I_Belt = new InputClass(MotionCard1, (int)InIndex.X6, "环形线滑块原点信号");
        /// <summary>
        /// 环形线定位气缸锁定定位信号
        /// </summary>
        public static InputClass I_CylLocked = new InputClass(MotionCard, (int)InIndex.X45, "环形线定位气缸锁定定位信号");
        /// <summary>
        /// 环形线定位气缸解除定位信号
        /// </summary>
        public static InputClass I_CylUnLocked = new InputClass(MotionCard, (int)InIndex.X46, "环形线定位气缸解除定位信号");
        /// <summary>
        /// 翻转夹紧气缸夹紧信号（开）
        /// </summary>
        public static InputClass I_BeforeTurnCylOpen = new InputClass(MotionCard, (int)InIndex.X47, "翻转夹紧气缸夹紧信号（开）");
        /// <summary>
        /// 翻转夹紧气缸夹紧信号（合）
        /// </summary>
        public static InputClass I_BeforeTurnCylClosed = new InputClass(MotionCard, (int)InIndex.X48, "翻转夹紧气缸夹紧信号（合）");
        /// <summary>
        /// 翻转旋转气缸信号（180度旋转信号）
        /// </summary>
        public static InputClass I_TurnCyl180 = new InputClass(MotionCard, (int)InIndex.X49, "翻转旋转气缸信号（180度旋转信号）");
        /// <summary>
        /// 翻转旋转气缸信号（原始复位信号）
        /// </summary>
        public static InputClass I_TurnCyl = new InputClass(MotionCard, (int)InIndex.X50, "翻转旋转气缸信号（原始复位信号）");
        /// <summary>
        /// 无产品异常报警（可设置启用或停用）
        /// </summary>
        public static InputClass I_NOproductalarm = new InputClass(MotionCard, (int)InIndex.X51, "无产品异常报警（可设置启用或停用）");
        /// <summary>
        /// 前夹具手动开合信号
        /// </summary>
        public static InputClass I_FrontFixture = new InputClass(MotionCard, (int)InIndex.X52, "前夹具手动开合信号");
        /// <summary>
        /// 后夹具手动开合信号
        /// </summary>
        public static InputClass I_BackFixture = new InputClass(MotionCard, (int)InIndex.X53, "后夹具手动开合信号");
        /// <summary>
        /// 前夹具开启信号
        /// </summary>
        public static InputClass I_FrontFixtureOpened = new InputClass(MotionCard, (int)InIndex.X54, "前夹具开启信号");
        /// <summary>
        /// 前夹具闭合信号
        /// </summary>
        public static InputClass I_FrontFixtureClosed = new InputClass(MotionCard, (int)InIndex.X55, "前夹具闭合信号");
        /// <summary>
        /// 后夹具开合信号
        /// </summary>
        public static InputClass I_BackFixtureOpened = new InputClass(MotionCard, (int)InIndex.X56, "后夹具开合信号");
        /// <summary>
        /// 后夹具闭合信号
        /// </summary>
        public static InputClass I_BackFixtureClosed = new InputClass(MotionCard, (int)InIndex.X57, "后夹具闭合信号");
        /// <summary>
        /// 零件1传感输入
        /// </summary>
        public static InputClass I_material1 = new InputClass(MotionCard, (int)InIndex.X58, "零件1传感输入");
        /// <summary>
        /// 零件2传感输入
        /// </summary>
        public static InputClass I_material2 = new InputClass(MotionCard, (int)InIndex.X59, "零件2传感输入");
        /// <summary>
        /// 零件3传感输入
        /// </summary>
        public static InputClass I_material3 = new InputClass(MotionCard, (int)InIndex.X60, "零件3传感输入");
        /// <summary>
        /// 零件4传感输入
        /// </summary>
        public static InputClass I_material4 = new InputClass(MotionCard1, (int)InIndex.X1, "零件4传感输入");
        /// <summary>
        /// 零件5传感输入
        /// </summary>
        public static InputClass I_material5 = new InputClass(MotionCard1, (int)InIndex.X2, "零件5传感输入");
        /// <summary>
        /// 零件6传感输入
        /// </summary>
        public static InputClass I_material6 = new InputClass(MotionCard1, (int)InIndex.X3, "零件6传感输入");
        /// <summary>
        /// 翻转X5轴原点
        /// </summary>
        public static InputClass I_X5 = new InputClass(MotionCard1, (int)InIndex.X4, "翻转X5轴原点");
        /// <summary>
        /// 翻转Z5轴原点
        /// </summary>
        public static InputClass I_Z5 = new InputClass(MotionCard1, (int)InIndex.X5, "翻转Z5轴原点");
        /// <summary>
        /// 翻转R5轴原点
        /// </summary>
        public static InputClass I_R5 = new InputClass(MotionCard1, (int)InIndex.X6, "翻转R5轴原点");
        #endregion

        #region 输出定义
        /// <summary>
        /// 焊锡1清洗电磁阀
        /// </summary>
        public static OutputClass Q_LSolderEclean = new OutputClass(MotionCard, (int)OutIndex.Y1, "焊锡1清洗电磁阀");
        /// <summary>
        /// 焊锡2清洗电磁阀
        /// </summary>
        public static OutputClass Q_RSolderEclean = new OutputClass(MotionCard, (int)OutIndex.Y2, "焊锡2清洗电磁阀");
        /// <summary>
        /// 打磨吹气电磁阀
        /// </summary>
        public static OutputClass Q_LPolishBlow = new OutputClass(MotionCard, (int)OutIndex.Y3, "打磨吹气电磁阀");
        /// <summary>
        /// 打磨继电器
        /// </summary>
        public static OutputClass Q_LPolishEle = new OutputClass(MotionCard, (int)OutIndex.Y4, "打磨继电器");
        

        /// <summary>
        /// 黄灯
        /// </summary>
        public static OutputClass Q_YellowLed = new OutputClass(MotionCard, (int)OutIndex.Y5, "黄灯");
        /// <summary>
        /// 红灯
        /// </summary>
        public static OutputClass Q_RedLed = new OutputClass(MotionCard, (int)OutIndex.Y6, "红灯");
        /// <summary>
        /// 绿灯
        /// </summary>
        public static OutputClass Q_GreenLed = new OutputClass(MotionCard, (int)OutIndex.Y7, "绿灯");
        /// <summary>
        /// 蜂鸣器
        /// </summary>
        public static OutputClass Q_Buzzer = new OutputClass(MotionCard, (int)OutIndex.Y8, "蜂鸣器");
        /// <summary>
        /// 焊锡光源1
        /// </summary>
        public static OutputClass Q_LSolderlight = new OutputClass(MotionCard, (int)OutIndex.Y9, "焊锡光源1");
        /// <summary>
        /// 焊锡光源2
        /// </summary>
        public static OutputClass Q_RSolderlight = new OutputClass(MotionCard, (int)OutIndex.Y10, "焊锡光源2");
        /// <summary>
        /// 打磨光源1
        /// </summary>
        public static OutputClass Q_LPolishlight = new OutputClass(MotionCard, (int)OutIndex.Y11, "打磨光源1");
        //public static OutputClass Q_RPolishlight = new OutputClass(MotionCard, (int)OutIndex.Y8, "蜂鸣器");
        /// <summary>
        /// 助焊剂1
        /// </summary>
        public static OutputClass Q_Flux1 = new OutputClass(MotionCard, (int)OutIndex.Y12, "助焊剂1");
        /// <summary>
        /// 助焊剂2
        /// </summary>
        public static OutputClass Q_Flux2 = new OutputClass(MotionCard, (int)OutIndex.Y13, "助焊剂2");
        /// <summary>
        /// 环形线定位气缸
        /// </summary>
        public static OutputClass Q_BeltLocatedCyl = new OutputClass(MotionCard, (int)OutIndex.Y14, "环形线定位气缸");
        /// <summary>
        /// 翻转夹紧气缸
        /// </summary>
        public static OutputClass Q_BeforeTurnCyl = new OutputClass(MotionCard, (int)OutIndex.Y15, "翻转夹紧气缸");
        /// <summary>
        /// 翻转旋转气缸
        /// </summary>
        public static OutputClass Q_TurnCyl = new OutputClass(MotionCard, (int)OutIndex.Y16, "翻转旋转气缸");
        /// <summary>
        /// 前夹具开合气缸
        /// </summary>
        public static OutputClass Q_FrontFixtureCyl = new OutputClass(MotionCard, (int)OutIndex.Y17, "前夹具开合气缸");
        /// <summary>
        /// 后夹具开合气缸
        /// </summary>
        public static OutputClass Q_BackFixtureCyl = new OutputClass(MotionCard, (int)OutIndex.Y18, "后夹具开合气缸");
        /// <summary>
        /// 打磨光源2
        /// </summary>
        public static OutputClass Q_RPolishlight = new OutputClass(MotionCard, (int)OutIndex.Y19, "打磨光源2");

        /// <summary>
        /// 打磨吹气电磁阀
        /// </summary>
        public static OutputClass Q_RPolishBlow = new OutputClass(MotionCard, (int)OutIndex.Y20, "打磨吹气电磁阀");
        /// <summary>
        /// 打磨继电器
        /// </summary>
        public static OutputClass Q_RPolishEle = new OutputClass(MotionCard, (int)OutIndex.Y21, "打磨继电器");
        /// <summary>
        /// 
        /// </summary>
        public static OutputClass Q_5 = new OutputClass(MotionCard, (int)OutIndex.Y20, "备用");
        public static OutputClass Q_6 = new OutputClass(MotionCard, (int)OutIndex.Y21, "备用");
        public static OutputClass Q_7 = new OutputClass(MotionCard, (int)OutIndex.Y22, "备用");

        public static OutputClass Q_8 = new OutputClass(MotionCard, (int)OutIndex.Y23, "备用");
        public static OutputClass Q_9 = new OutputClass(MotionCard, (int)OutIndex.Y24, "备用");
        public static OutputClass Q_10 = new OutputClass(MotionCard, (int)OutIndex.Y25, "备用");
        public static OutputClass Q_11= new OutputClass(MotionCard, (int)OutIndex.Y26, "备用");
        public static OutputClass Q_12= new OutputClass(MotionCard, (int)OutIndex.Y27, "备用");
        public static OutputClass Q_13= new OutputClass(MotionCard, (int)OutIndex.Y28, "备用");
        public static OutputClass Q_14= new OutputClass(MotionCard, (int)OutIndex.Y29, "备用");
        public static OutputClass Q_15= new OutputClass(MotionCard, (int)OutIndex.Y30, "备用");
        #endregion
    }
}
