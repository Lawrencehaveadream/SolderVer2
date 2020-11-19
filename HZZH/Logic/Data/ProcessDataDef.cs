using CommonRs;
using HZZH.Logic.LogicMission;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using static HZZH.Logic.LogicMission.PolishFunCT;

namespace HZZH.Logic.Data
{
    [Serializable]
    public class ProcessDataDef
    {
        public PointF4 LocatedPointPos { get; set; }
        /// <summary>
        /// 平台数据
        /// </summary>
        public List<PlatformData>  PlatformData { get; set;}
        /// <summary>
        /// 工作点
        /// </summary>
        public List<SolderPosData>[] SolderList = new List<SolderPosData>[] { new List<SolderPosData>(), new List<SolderPosData>() };
        public List<PolishPosData>[] PolishList = new List<PolishPosData>[] { new List<PolishPosData>(), new List<PolishPosData>() };
        
        public List<PointFB>[] PolishCTPos = new List<PointFB>[] { new List<PointFB>(), new List<PointFB>() };
        public List<PointFB>[] SolderCTPos = new List<PointFB>[] { new List<PointFB>(), new List<PointFB>() };
        /// <summary>
        /// 左打磨模板
        /// </summary>
        public List<PolishModel> LPolishModel { get; set; }
        /// <summary>
        /// 右打磨模板
        /// </summary>
        public List<PolishModel> RPolishModel { get; set; }
        /// <summary>
        /// 左上锡模板
        /// </summary>
        public List<SolderModel> LSolderModel { get; set; }
        /// <summary>
        /// 
        /// 右上锡模板
        /// </summary>
        public List<SolderModel> RSolderModel { get; set; } 
        public PolishDef Agingdataforpolish { get; set; } 
        public SolderDef Agingdataforsolder { get; set; } 
        public ProcessDataDef()
        {
            PlatformData = new List<PlatformData>();
            for (int i = 0; i < 8; i++)
            {
                PlatformData.Add(new PlatformData ());
            }
            LocatedPointPos = new PointF4();
            
            Agingdataforpolish = new PolishDef();
            Agingdataforsolder = new SolderDef();

            LPolishModel = new List<PolishModel>();
            RPolishModel = new List<PolishModel>();
            LSolderModel = new List<SolderModel>();
            RSolderModel = new List<SolderModel>();
        }
        /// <summary>
        /// 打磨模选择
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<PolishModel> WhichPolishMedol(int id)
        {
            if (id == 0)
            {
                return LPolishModel;
            }
            else
            {
                return RPolishModel;
            }
        }
        /// <summary>
        /// 上锡模板选择
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<SolderModel> WhichSolderMedol(int id)
        {
            if (id == 0)
            {
                return LSolderModel;
            }
            else
            {
                return RSolderModel;
            }
        }
    }
}
