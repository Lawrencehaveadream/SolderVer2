using CommonRs;
using HzControl.Communal.Tools;
using HZZH.Logic.LogicMain;
using HZZH.Logic.LogicMission;
using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serialization = HzControl.Communal.Tools.Serialization;

namespace HZZH.Logic.Data
{
    /// <summary>
    /// 保存的数据
    /// </summary>
    #region 工程保存数据
    [Serializable]
    public class ProjectSaveDataDef   //保存数据
    {
        public ProcessDataDef processdata { get; set; }

        public List<PolishPlatformPara>  PolishPlatform { get; set; }
        public List<SolderPlatformPara>  SolderPlatform { get; set; }
        public List<PolishCleanData> PolishCleanData { get; set; }
        public List<PolishData> PolishData { get; set; }
        public List<SolderData> SolderData { get; set; }
        public List<TinCleanData> SolderCleanData { get; set; }

        public ReverseData ReverseData { get; set; }

        public ProjectSaveDataDef()
        {
            processdata = new ProcessDataDef();
            PolishPlatform = new List<PolishPlatformPara> {new PolishPlatformPara (),new PolishPlatformPara () };
            SolderPlatform = new List<SolderPlatformPara> { new SolderPlatformPara(), new SolderPlatformPara() };
            PolishCleanData = new List<PolishCleanData> { new Data.PolishCleanData(),new PolishCleanData () };
            PolishData = new List<PolishData> { new Data.PolishData (),new Data.PolishData ()};
            SolderData = new List<SolderData> { new Data.SolderData() ,new Data.SolderData ()};
            SolderCleanData = new List<TinCleanData> { new TinCleanData (),new TinCleanData ()};
            ReverseData = new ReverseData();
        }
    }
    #endregion

    #region 工程保存数据方式，不允许修改
    [Serializable]
    public class ProjectData  //整个逻辑参数
    {
        #region 把当前类静态化
        static object _syncObj = new object();
        static ProjectData _projectData;
        public static ProjectData Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (_projectData == null)
                    {
                        _projectData = new ProjectData();
                    }
                }
                return _projectData;
            }
        }
        #endregion

        //工程数据
        public ProjectSaveDataDef SaveData { get; set; }
        //产量数据
        public ProductStatistics Product { get; set; }

        public ProjectData()
        {
            this.SaveData = new ProjectSaveDataDef();
            this.Product = new ProductStatistics();
        }
        /// <summary>
        /// 新建工程
        /// </summary>
        public void CreatProject()
        {
            try
            {
                this.SaveData = new ProjectSaveDataDef();
                this.Product = new ProductStatistics();
            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件失败!\n异常描述:{0}\n时间：{1}", ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }
        /// <summary>
        /// 加载工程
        /// </summary>
        public void OpenProject(string path)
        {
            try
            {
                string name = Path.GetFileName(path);
                string fileName = path + "\\" + name + ".pro";

                ProjectData data = (ProjectData)CreateProject.OpenProject(typeof(ProjectData), fileName);
                this.SaveData = data.SaveData;
                if (data.Product == null)
                {
                    this.Product = new ProductStatistics();
                }
                else
                {
                    this.Product = data.Product;
                }
            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件失败!\n异常描述:{0}\n时间：{1}", ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }
        /// <summary>
        /// 保存工程
        /// </summary>
        public void SaveProject(string path)
        {
            CreateProject.SaveProject(this, path);
        }
    }
    #endregion

    public class LogicStatus  //整个逻辑参数
    {
        #region 把当前类静态化
        static object _syncObj = new object();
        static LogicStatus _projectData;
        public static LogicStatus Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (_projectData == null)
                    {
                        _projectData = new LogicStatus();
                    }
                }
                return _projectData;
            }
        }
        #endregion
        //工程数据
        public TaskMain Logic { get; set; }
        public LogicStatus()
        {
            this.Logic = new TaskMain();
        }
    }
}
