using System;
using System.Collections.Generic;
using System.Linq;
using CommonRs;
using SqliteDataBase;

namespace ConfigSpace
{
    /// <summary>
    /// 配置文件统一操作类
    /// </summary>
    public class ConfigHandle : Config
    {
        #region Singleton

        static object _syncObj = new object();
        static ConfigHandle _instance;
        public static ConfigHandle Instance
        {
            get
            {
                lock (_syncObj)
                {
                    if (_instance == null)
                    { _instance = new ConfigHandle(); }
                }

                return _instance;
            }
        }

        #endregion                     

        /// <summary>
        /// 属性:系统配置
        /// </summary>1
        public ConfigSystem SystemDefine { set; get; }

        /// <summary>
        /// 属性:用户配置
        /// </summary>
        public ConfigUser UserDefine { set; get; }
        /// <summary>
        /// 属性:报警配置
        /// </summary>
        public ConfigAlarm AlarmDefine { set; get; }


        /// <summary>
        /// 加载所有配置
        /// </summary>
        public void Load()
        {
            try
            {
                #region 加载配置
                this.AlarmDefine = new ConfigAlarm();
                LoadEquipmentConfig();
                #endregion
            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件失败!\n异常描述:{0}\n时间：{1}", ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }

        public void Save()
        {
            try
            {
                #region 保存配置
                SaveEquipmentConfig();
                #endregion
            }
            catch (Exception ex)
            {
                LogWriter.WriteException(ex);
                LogWriter.WriteLog(string.Format("错误：加载配置文件失败!\n异常描述:{0}\n时间：{1}", ex.Message, System.DateTime.Now.ToString("yyyyMMddhhmmss")));
            }
        }


        #region 数据库存储

        private static string _name = "EquipmentConfig";
        //报警配置文件的相对路径
        private static string _configName = string.Format("{0}", ConfigDirectory + "\\" + _name);
        /// <summary>
        /// 系统数据
        /// </summary>
        string[] sqlSystemData = { "SystemTypes", "Data1", "Data2", "Data3", "Data4" };
        /// <summary>
        /// 系统数据类型
        /// </summary>
        string[] sqlSystemDataTyp = { "TEXT", "TEXT", "TEXT", "TEXT", "TEXT" };
        /// <summary>
        /// 系统配置数据库(包含:平台，通讯，相机,高级设置)
        /// </summary>
        public static AppSqliteConfigure SysDataManage;

        private void LoadEquipmentConfig()
        {
            var va = HzControl.Communal.Tools.Serialization.LoadFromXml(typeof(ConfigHandle), "D:\\程式\\配置文件\\配置文件", true) as ConfigHandle;
            if (va.AlarmDefine == null)
            {
                va.AlarmDefine = new ConfigAlarm();
            }
            if (va.SystemDefine == null)
            {
                va.SystemDefine = new ConfigSystem();
            }
            if (va.UserDefine == null)
            {
                va.UserDefine = new ConfigUser();
            }
            Instance.AlarmDefine = va.AlarmDefine;
            Instance.SystemDefine = va.SystemDefine;
            Instance.UserDefine = va.UserDefine;
        }
        public void SaveEquipmentConfig()
        {
            HzControl.Communal.Tools.Serialization.SaveToXml(Instance, "D:\\程式\\配置文件\\配置文件", true);
        }
        #endregion

    }
}
