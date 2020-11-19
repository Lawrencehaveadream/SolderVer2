using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace CommonRs
{

    /// <summary>
    /// 两位浮点型数据
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class PointF2 
    {
        public float X { get; set; }
        public float Y { get; set; }
    }

    /// <summary>
    /// 拍照位置数据
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class PointFB : ICloneable
    {
        public float X { get; set; }
        public float Y { get; set; }
        public bool Ban { get; set; }
        public PointFB()
        {
            X = 0;
            Y = 0;
            Ban = false;
        }
        object ICloneable.Clone()
        {
            PointFB wP = new PointFB();
            
            wP.X = this.X;
            wP.Y = this.Y;
            wP.Ban = this.Ban;
            return wP;

        }
        public PointFB Clone()
        {
            return (PointFB)((ICloneable)this).Clone();
        }


    }
    
    /// <summary>
    /// 三位浮点型数据
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class PointF3
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }
    /// <summary>
    /// 四位浮点型数据
    /// </summary>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public class PointF4
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float R { get; set; }



        public PointF4 Clone()
        {
            PointF4 p = new PointF4();
            p.X = this.X;
            p.Y = this.Y;
            p.Z = this.Z;
            p.R = this.R;

            return p;
        }
    }

    [Serializable]
    public class PointFEXc
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float R { get; set; }
    }

    /// <summary>
    /// 视觉给出来的结果点数据类型
    /// </summary>
    [Serializable]
    public class PointFCCD
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float R { get; set; }
        public bool result { get; set; }
    }
}
