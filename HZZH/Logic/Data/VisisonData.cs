using CCWin.SkinControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HZZH.Logic.Data
{
    public class DataForLogic
    {
        public VisisonData SolderLeft = new VisisonData();
        public VisisonData SolderRight = new VisisonData();
        public VisisonData PolishLeft = new VisisonData();
        public VisisonData PolishRight = new VisisonData();
    }
     public class VisisonData
    {
        /// <summary>
        /// 模板个数
        /// </summary>
        public int ModelNum { get; set; }
        public List<Model>  model { get; set; }
        public VisisonData()
        {
            model = new List<Model>();
        }
        /// <summary>
        /// 执行触发，完成后会被置位成false
        /// </summary>
        public bool Trig;
        /// <summary>
        /// 错误码，不为0表示有错误
        /// </summary>
        public int Error;
        /// <summary>
        /// 匹配的点的结果
        /// </summary>
        public VisisonData Result;
        /// <summary>
        /// 拍照触发
        /// </summary>
        public void TrigRun()
        {
            if (Trig == false)
            {
                Error = 0;
                Result = new VisisonData();
            }
            Trig = true;
        }
        /// <summary>
        /// 触发完成
        /// </summary>
        /// <returns></returns>
        public bool TrigComplete()
        {
            return !Trig;
        }
        
    }
    /// <summary>
    /// 模板的点的机械坐标
    /// </summary>
   public class pointPos
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float R { get; set; }
        public pointPos()
        {
            X = 0;
            Y = 0;
            R = 0;
        }
    }
    /// <summary>
    /// 像素点坐标
    /// </summary>
   public class pixel
    {
        public float X { get; set; }
        public float Y { get; set; }
        public pixel()
        {
            X = 0;
            Y = 0;
        }

    }
    /// <summary>
    /// 模板
    /// </summary>
   public class Model
    {
        /// <summary>
        /// 模板的点的个数
        /// </summary>
        public int Num { get; set; }
        /// <summary>
        /// 点的机械位置列表
        /// </summary>
        public List<pointPos>  Pos { get; set; }
        /// <summary>
        /// 像素坐标
        /// </summary>
        public List<pixel> pixelsPos { get; set; }
        /// <summary>
        /// 模板的编号
        /// </summary>
        public int modelindex { get; set; }
        public Model()
        {
            Pos = new List<pointPos>();
            pixelsPos = new List<pixel>();
        }
    }
}
