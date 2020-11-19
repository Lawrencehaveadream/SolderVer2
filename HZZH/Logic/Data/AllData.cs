using CommonRs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.Data
{
    class AllData
    {

        public AllData()
        {

        }
    }
    /// <summary>
    /// 平台运行参数
    /// </summary>
    [Serializable]
    public class PlatformData
    {
        /// <summary>
        /// 是否有物料
        /// </summary>
        public bool IsHave { get; set; }
        /// <summary>
        /// 是否已经被打磨
        /// </summary>
        public bool IsPolished { get; set; }
        /// <summary>
        /// 是否已经上锡
        /// </summary>
        public bool IsTined { get; set; }
        /// <summary>
        /// 是否已经翻转
        /// </summary>
        public bool Isreversed { get; set; }
        public PlatformData()
        {
            IsHave = false;
            IsPolished = false;
            IsTined = false;
            Isreversed = false;
        }

        public void SetLastPlatformData(PlatformData data)
        {
            IsHave = data.IsHave;
            IsPolished = data.IsPolished;
            IsTined = data.IsTined;
            Isreversed = data.Isreversed;
        }

        public PlatformData Clone()
        {
            return (PlatformData)HzControl.Communal.Tools.Serialization.CloneObj(this);
        }
    }
    /// <summary>
    /// 打磨清洗参数
    /// </summary>
    [Serializable]
   public class PolishCleanData
    {
        /// <summary>
        /// 打磨清洗安全高度
        /// </summary>
        public float SafeZ { get; set; }
        /// <summary>
        /// 每打磨多少次去清洗一次
        /// </summary>
        public int TimesSum { get; set; }
        /// <summary>
        /// 清洗模式 1:一字左右2：二字左右
        /// </summary>
        public int Mode { get; set; }
        /// <summary>
        /// 往返清洗次数
        /// </summary>
        public int CleanTimes { get; set; }
        /// <summary>
        /// 往返幅度
        /// </summary>
        public float range { get; set; }
        /// <summary>
        /// 清洗位置
        /// </summary>
        public PointF4 CleanPos { get; set; }
        /// <summary>
        /// 清洗结束之后的位置
        /// </summary>
        public PointF4 CleanEndPos { get; set; }
        /// <summary>
        /// 清洗时间
        /// </summary>
        public int CleanTime { get; set; }
        /// <summary>
        /// 清洗速度
        /// </summary>
        public int CleanSpeed { get; set; }
        /// <summary>
        /// 打磨间距
        /// </summary>
        public float interval { get; set; }
        public PolishCleanData()
        {
            TimesSum = 50;
            Mode = 1;
            CleanTimes = 1;
            range = 0.5f;
            CleanTime = 100;
            CleanPos = new PointF4();
            CleanEndPos = new PointF4();
            CleanSpeed = 100;
            interval = 0.5f;
        }
    }
    /// <summary>
    /// 打磨基本参数
    /// </summary>
    [Serializable]
    public class PolishData
    {
        /// <summary>
        /// 打磨头共打磨多少次
        /// </summary>
        public int PolishNum { get; set; }
        /// <summary>
        /// 结束停靠位
        /// </summary>
        public PointF4 EndPos { get; set; }
        /// <summary>
        /// 打磨头有效打磨次数
        /// </summary>
        public int TimesTotal { get; set; }
        /// <summary>
        /// Z轴一共补偿多少
        /// </summary>
        public float TotalReimburse { get; set; }
        /// <summary>
        /// 当前一共打磨多少次
        /// </summary>
        public int SumPolishTimes { get; set; }
        /// <summary>
        /// Z轴一次补偿数值
        /// </summary>
        public float Reimburse { get; set; }
        /// <summary>
        /// 多少次打磨后加一次打磨补偿
        /// </summary>
        public int Interval { get; set; }
        /// <summary>
        /// 打磨拍照延时
        /// </summary>
        public int CTDelay { get; set; }
        /// <summary>
        /// 安全高度
        /// </summary>
        public float SafeZ { get; set; }

        public PolishData()
        {
            TotalReimburse = 0;
            Interval = 500;
            Reimburse = 0.1f;
            TotalReimburse = 0;
            CTDelay = 25;
            SafeZ = 0;
            TimesTotal = 500;
            EndPos = new PointF4();
        }
    }
    /// <summary>
    /// 打磨点工艺参数
    /// </summary>
     [Serializable]
    public class PolishDef : ICloneable
    {
        #region
        /// <summary>
        /// 打磨方式
        /// </summary>
        [DisplayNameAttribute("打磨方式"), DescriptionAttribute("打磨方式：0：一字左右，1：二字左右， 2：一字前后， 3：二字前后")]
        public int mode { get; set; }
        /// <summary>
        /// 打磨往返次数
        /// </summary>
        [DisplayNameAttribute("打磨往返次数")]
        public int GoBackTimes { get; set; }
        /// <summary>
        /// 打磨往返速度
        /// </summary>
        [DisplayNameAttribute("打磨往返速度")]
        public float PolishSpeed { get; set; }
        /// <summary>
        /// 打磨往返幅度
        /// </summary>
        [DisplayNameAttribute("打磨往返幅度")]
        public float GoBackRange { get; set; }
        /// <summary>
        /// 二字打磨间距
        /// </summary>
        [DisplayNameAttribute("二字打磨间距")]
        public float PolishInterval { get; set; }
        /// <summary>
        /// 打磨后提起高度
        /// </summary>
        [DisplayNameAttribute("打磨后提起高度")]
        public float LiftHeight { get; set; }
        /// <summary>
        /// 此模板的Z轴高度
        /// </summary>
        [DisplayNameAttribute("Z轴高度")]
        public float Z { get; set; }
        #endregion
        public PolishDef()
        {
            Z = 5;
            mode = 0;
            GoBackTimes = 1;
            PolishSpeed = 100;
            GoBackRange = 0.1f;
            PolishInterval = 0.1f;
            LiftHeight = 10f;
        }
        object ICloneable.Clone()
        {
            PolishDef pro = new PolishDef();
            pro.mode = this.mode;
            pro.GoBackTimes = this.GoBackTimes;
            pro.PolishSpeed = this.PolishSpeed;
            pro.GoBackRange = this.GoBackRange;
            pro.PolishInterval = this.PolishInterval;
            pro.LiftHeight = this.LiftHeight;
            pro.Z = this.Z;
            return pro;
        }
        public PolishDef Clone()
        {
            return (PolishDef)((ICloneable)this).Clone();
        }
    }
    /// <summary>
    /// 打磨位置及打磨点参数
    /// </summary>
    [Serializable]
    public class PolishPosData
    {
        public PointF4  Pos { get; set; } 
        public PolishDef polishData { get; set; } 

        public PolishPosData()
        {
            Pos = new PointF4();
            polishData = new PolishDef();
        }
    }
    /// <summary>
    /// 打磨模板点和工艺参数
    /// </summary>
    [Serializable]
    public class PolishModel
    {
        public List<PolishDef> polishData { get; set; }
        public PolishModel()
        {
            polishData = new List<PolishDef>();
            
        }
    }
    /// <summary>
    /// 上锡基本参数
    /// </summary>
    [Serializable]
    public class SolderData
    {
        /// <summary>
        /// 一共焊锡多少次
        /// </summary>
        public int SolderNum { get; set; }
        /// <summary>
        /// 焊锡结束停靠位
        /// </summary>
        public PointF4 TinEndPos { get; set; }
        public float SafeZ { get; set; }
        public int CTDelay { get; set; }
        public SolderData()
        {
            TinEndPos = new PointF4();
            SafeZ = 0;
            CTDelay = 25;
        }
    }
    /// <summary>
    /// 上锡位置及上锡参数
    /// </summary>
    [Serializable]
    public class SolderPosData
    {
        public PointF4 Pos { get; set; }
        public SolderDef SolderData { get; set; }
        public bool Rinse { get; set; }

        public SolderPosData()
        {
            Pos = new PointF4();
            SolderData = new SolderDef();
            Rinse = new bool();
        }

        public override string ToString()
        {
            return Pos.ToString();
        }
    }
    /// <summary>
    /// 上锡模板点和工艺参数
    /// </summary>
    /// 
    [Serializable]
    public class SolderModel
    {
        public List<SolderDef> solderdata { get; set; }
        public SolderModel()
        {
            solderdata = new List<SolderDef>();
        }
    }
    /// <summary>
    /// 上锡工艺参数
    /// </summary>
    [Serializable]
    public class SolderDef : ICloneable
    {
        #region
        [CategoryAttribute("是否抖动"), DisplayNameAttribute("是否开启抖动")]
        public bool Shake { get; set; }
        /// <summary>
        /// 第一段送锡长度
        /// </summary>
        [CategoryAttribute("第一段"), DisplayNameAttribute("第一段送锡长度")]
        public float FrontLen { get; set; }
        /// <summary>
        /// 第一段送锡速度
        /// </summary>
        [CategoryAttribute("第一段"), DisplayNameAttribute("第一段送锡速度")]
        public float FrontSpeed { get; set; }
        /// <summary>
        /// 第一段退锡长度
        /// </summary>
        [CategoryAttribute("第一段"), DisplayNameAttribute("第一段退锡长度")]
        public float BackLen { get; set; }
        /// <summary>
        /// 第一段退锡速度
        /// </summary>
        [CategoryAttribute("第一段"), DisplayNameAttribute("第一段退锡速度")]
        public float BsckSpeed { get; set; }
        /// <summary>
        /// 第二段送锡长度
        /// </summary>
        [CategoryAttribute("第二段"), DisplayNameAttribute("第二段送锡长度")]
        public float FrontLen2 { get; set; }
        /// <summary>
        /// 第二段送锡速度
        /// </summary>
        [CategoryAttribute("第二段"), DisplayNameAttribute("第二段送锡速度")]
        public float FrontSpeed2 { get; set; }
        /// <summary>
        /// 第二段退锡长度
        /// </summary>
        [CategoryAttribute("第二段"), DisplayNameAttribute("第二段退锡长度")]
        public float BackLen2 { get; set; }
        /// <summary>
        /// 第二段退锡速度
        /// </summary>
        [CategoryAttribute("第二段"), DisplayNameAttribute("第二段退锡速度")]
        public float BsckSpeed2 { get; set; }
        /// <summary>
        /// 第三段送锡长度
        /// </summary>
        [CategoryAttribute("第三段"), DisplayNameAttribute("第三段送锡长度")]
        public float FrontLen3 { get; set; }
        /// <summary>
        /// 第三段送锡速度
        /// </summary>
        [CategoryAttribute("第三段"), DisplayNameAttribute("第三段送锡速度")]
        public float FrontSpeed3 { get; set; }
        /// <summary>
        /// 第三段退锡长度
        /// </summary>
        [CategoryAttribute("第三段"), DisplayNameAttribute("第三段退锡长度")]
        public float BackLen3 { get; set; }
        /// <summary>
        /// 第三段退锡速度
        /// </summary>
        [CategoryAttribute("第三段"), DisplayNameAttribute("第三段退锡速度")]
        public float BsckSpeed3 { get; set; }
        /// <summary>
        /// 第一段送锡延时
        /// </summary>
        [CategoryAttribute("第一段"), DisplayNameAttribute("第一段送锡延时")]
        public int SendDelay { get; set; }
        /// <summary>
        /// 第二段送锡延时
        /// </summary>
        [CategoryAttribute("第二段"), DisplayNameAttribute("第二段送锡延时")]
        public int SendDelay2 { get; set; }
        /// <summary>
        /// 第三段送锡延时
        /// </summary>
        [CategoryAttribute("第三段"), DisplayNameAttribute("第三段送锡延时")]
        public int SendDelay3 { get; set; }
        /// <summary>
        /// 抖动模式
        /// </summary>
        [DisplayNameAttribute("抖动模式"), DescriptionAttribute("抖动模式：0：上下，1：左右，2：前后")]
        public int mode { get; set; }
        /// <summary>
        /// 抖动次数
        /// </summary>
        [DisplayNameAttribute("抖动次数")]
        public int times { get; set; }
        /// <summary>
        /// 抖动幅度
        /// </summary>
        [DisplayNameAttribute("抖动幅度")]
        public float interval { get; set; }
        /// <summary>
        /// 抖动高度
        /// </summary>
        [DisplayNameAttribute("抖动高度")]
        public float height { get; set; }
        /// <summary>
        /// 抖动速度
        /// </summary>
        [DisplayNameAttribute("抖动速度")]
        public float speed { get; set; }
        /// <summary>
        /// 抖动送锡长度
        /// </summary>
        [DisplayNameAttribute("抖动送锡长度")]
        public float sendlen { get; set; }
        /// <summary>
        /// 抖动送锡速度
        /// </summary>
        [DisplayNameAttribute("抖动送锡速度")]
        public float sendSpeed { get; set; }
        /// <summary>
        /// 返回方式
        /// </summary>
        [DisplayNameAttribute("返回方式")]
        public int Backmode { get; set; }
        /// <summary>
        /// 返回高度
        /// </summary>
        [DisplayNameAttribute("返回高度")]
        public float BackHeight { get; set; }
        /// <summary>
        /// 提起高度
        /// </summary>
        [DisplayNameAttribute("提起高度")]
        public float LiftHeight { get; set; }
        /// <summary>
        /// 此模板的Z轴高度
        /// </summary>
        [DisplayNameAttribute("提起高度")]
        public float Z { get; set; }
        #endregion
        public SolderDef()
        {
            Z = 10;
            Shake = false;
            FrontLen = 0.25f;
            FrontSpeed = 100;
            BackLen = 0.25f;
            BsckSpeed = 100;

            FrontLen2 = 0.25f;
            FrontSpeed2 = 50;
            BackLen2 = 0.25f;
            BsckSpeed2 = 50;

            FrontLen3 = 0.25f;
            FrontSpeed3 = 30;
            BackLen3 = 0.25f;
            BsckSpeed3 = 30;

            SendDelay = 10;
            SendDelay2 = 10;
            SendDelay3 = 10;
            mode = 1;
            times = 3;
            interval = 0.25f;
            height = 1;
            speed = 100;
            sendlen = 1;
            sendSpeed = 100;
            Backmode = 0;
            BackHeight = 1;
            LiftHeight = 1;
        }
        /// <summary>
        /// 深度克隆类
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            SolderDef pro = new SolderDef();
            pro.FrontLen = this.FrontLen;
            pro.FrontSpeed = this.FrontSpeed;
            pro.BackLen = this.BackLen;
            pro.BsckSpeed = this.BsckSpeed;

            pro.FrontLen2 = this.FrontLen2;
            pro.FrontSpeed2 = this.FrontSpeed2;
            pro.BackLen2 = this.BackLen2;
            pro.BsckSpeed2 = this.BsckSpeed2;

            pro.FrontLen3 = this.FrontLen3;
            pro.FrontSpeed3 = this.FrontSpeed;
            pro.BackLen3 = this.BackLen3;
            pro.BsckSpeed3 = this.BsckSpeed3;

            pro.SendDelay = this.SendDelay;
            pro.SendDelay2 = this.SendDelay2;
            pro.SendDelay3 = this.SendDelay3;

            pro.mode = this.mode;
            pro.times = this.times;
            pro.interval = this.interval;
            pro.height = this.height;
            pro.speed = this.speed;
            pro.sendlen = this.sendlen;
            pro.sendSpeed = this.sendSpeed;
            pro.Backmode = this.Backmode;
            pro.BackHeight = this.BackHeight;
            pro.LiftHeight = this.LiftHeight;
            pro.Z = this.Z;
            return pro;
        }
        public SolderDef Clone()
        {
            return (SolderDef)((ICloneable)this).Clone();
        }
    }
    /// <summary>
    /// 焊锡清洗数据
    /// </summary>
    [Serializable]
   public class TinCleanData
    {

        /// <summary>
        /// 清洗位置
        /// </summary>
        public PointF4 CleanPos { get; set; }
        /// <summary>
        /// 清洗时间
        /// </summary>
        public int CleanTime { get; set; }
        /// <summary>
        /// 送锡长度
        /// </summary>
        public float PosLength { get; set; }
        /// <summary>
        /// 送锡速度
        /// </summary>
        public int PosSpeed { get; set; }
        /// <summary>
        /// 退锡长度
        /// </summary>
        public float NegLength { get; set; }
        /// <summary>
        /// 退锡速度
        /// </summary>
        public int NegSpeed { get; set; }
        public TinCleanData()
        {
            CleanPos = new PointF4();
            CleanTime = 100;
            PosLength = 10;
            PosSpeed = 75;
            NegLength = 10;
            NegSpeed = 75;
        }
    }
    #region 计算R轴旋转

    [Serializable]
    public class TeachingMechinePra                         // 用于记录机械中相机、旋转轴、焊头的各个位置
    {
        public PointF2 ZeroPostion { get; set; }             // 0度时候的坐标
        public PointF2 ReversePostion { get; set; }          // 180度时候的坐标
        public PointF2 RotatePostion { get; set; }           // 认为旋转中心会跟着轴移动,此时的旋转中心

        public PointF2 RotatePstionHXT_Size { get; set; }    // 求得焊锡头距离参考旋转中心的偏移
        public float Radius { get; set; }    // 求得焊锡头距离参考旋转中心的半径


        public PointF2 RotatePstionCameraSize { get; set; }  // 求得相机的中心到旋转中心的偏移

        public PointF2 CameraRotatePostion { get; set; }     // 在计算相机和旋转中心位置时候，相机位置参考
        public PointF4 HXT_OrgPostion { get; set; }          // 在计算焊锡头距离参考选中心时，焊锡头的位置


        public double RotatePostionStartAngle { get; set; } // 在初始机械结构中，焊头在旋转中前状态时候的初始角度，
                                                            // 为了计算焊头的点转换成相机点的一种转换方式

        public TeachingMechinePra()
        {
            ZeroPostion = new PointF2();
            ReversePostion = new PointF2();
            RotatePostion = new PointF2();
            RotatePstionCameraSize = new PointF2();
            CameraRotatePostion = new PointF2();
            HXT_OrgPostion = new PointF4();
            RotatePstionHXT_Size = new PointF2();
            RotatePostionStartAngle = 0;
            Radius = 0;
        }
    }

    #endregion

}
