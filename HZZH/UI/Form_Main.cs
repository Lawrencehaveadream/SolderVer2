using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using CommonRs;
using ConfigSpace;
using MyControl;
using HZZH.Common.Config;
using System.Threading;
using HZZH.Logic.Commmon;

using HZZH.UI.DerivedControl;



using System.Runtime.InteropServices;
using System.Timers;
using LicenseManagement;
using ApiClass;
using HZZH;
using HzControl.Communal.Control;
using HZZH.Logic.UI;
using HZZH.UI;
using HzControl.Logic;
using HZZH.Logic.LogicMission;
using HZZH.Logic.Data;
using Timer = System.Timers.Timer;
using System.Diagnostics;

namespace UI
{
    public partial class FormMain : Form
	{
        public FormMain()
		{
            
            try
            {                
                InitializeComponent();
                StartUpdate.SendStartMsg("应用程序启动 请稍等>>>");
                ConfigSpace.ConfigHandle.Instance.Load();
                InitializeControl(); 
                StartUpdate.SendStartMsg("正在进入系统>>>");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {

				timer1.Interval = 200;
                timer1.Enabled = true;
            }
		}

       

        #region 用户

        public static User CurrentUser = new User();
        private void btnload()
        {
            frm_Stick.tabControl1.Enabled = false;
            frm_Stick.toolStrip1.Enabled = false;
        }
        private void btnlog()
        {
            toolStripButton1.Enabled = toolStripButton3.Enabled =
            日志Bt.Enabled= toolStripButton6.Enabled =toolStripButton11.Enabled = toolStripButton16.Enabled = 
           修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled
            = 用户管理ToolStripMenuItem.Enabled = true;
            登录ToolStripMenuItem.Enabled = false;
        }
        private void 登录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserLogin frm = new UserLogin();
            if (DialogResult.OK == frm.ShowDialog())
            {
                UserMgrLogos(frm.GetCurrentUser());
                userInfo.GetUserList(frm.GetCurrentUser());
            }
        }
        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripButton7.Text != "厂家")
            {
                MessageBox.Show("您当前没有权限进行修改密码操作", "提示");
                return;
            }
            ChangeUserPwd frm_ChangePwd = new ChangeUserPwd();
            frm_ChangePwd.SetUser(CurrentUser);
            if (DialogResult.OK == frm_ChangePwd.ShowDialog(this))
            {
                CurrentUser = frm_ChangePwd.GetCurrentUser();
            }
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButton7.Text = "用户";
            UserMgrIntialize();
            btnload();
        }
        private void UserMgrIntialize()
        {
            修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled =
            用户管理ToolStripMenuItem.Enabled = false;

            登录ToolStripMenuItem.Enabled = true;

            CurrentUser = null;
            //tsslbl_loginUserMsg.Text = "";
        }
        private void UserMgrLogos(User user1)
        {
            try
            {
                if (user1.Type != "")
                {
                   
                    CurrentUser = user1;
                    
                    
                    switch (user1.Type)
                    {
                        case "0": 
                            btnlog();
                            toolStripButton7.Text = "操作员";
                            frm_Stick.toolStrip1.Enabled = true;
                            frm_Stick.tabControl1.Enabled = true;
                            frm_Stick.toolStripButton2.Enabled = false;
                            frm_Stick.toolStripDropDownButton1.Enabled = false;
                            frm_Stick.toolStripSplitButton1.Enabled = false;
                            frm_Stick.toolStripButton4.Enabled = false;
                            frm_Stick.toolStripButton5.Enabled = false;
                            frm_Stick.toolStripButton6.Enabled = false;
                            frm_Stick.toolStripButton7.Enabled = false;

                            break;
                        case "1":  
                            btnlog();
                            toolStripButton7.Text = "工程师";
                            frm_Stick.toolStrip1.Enabled = true;
                            frm_Stick.tabControl1.Enabled = true;
                            frm_Stick.toolStripButton2.Enabled = false;
                            frm_Stick.toolStripDropDownButton1.Enabled = true;
                            frm_Stick.toolStripSplitButton1.Enabled = true;
                            frm_Stick.toolStripButton4.Enabled = true;
                            frm_Stick.toolStripButton5.Enabled = true;
                            frm_Stick.toolStripButton6.Enabled = true;
                            frm_Stick.toolStripButton7.Enabled = true;
                            break;
                        case "2":
                            btnlog();
                            toolStripButton7.Text = "厂家";
                            frm_Stick.toolStrip1.Enabled = true;
                            frm_Stick.tabControl1.Enabled = true;
                            frm_Stick.toolStripButton2.Enabled = true;
                            frm_Stick.toolStripDropDownButton1.Enabled = true;
                            frm_Stick.toolStripSplitButton1.Enabled = true;
                            frm_Stick.toolStripButton4.Enabled = true;
                            frm_Stick.toolStripButton5.Enabled = true;
                            frm_Stick.toolStripButton6.Enabled = true;
                            frm_Stick.toolStripButton7.Enabled = true;
                            break;
                        case "3":                     
                            break;
                        default:
                            break;
                    }


                    修改密码ToolStripMenuItem.Enabled = 退出ToolStripMenuItem.Enabled = true;

                    登录ToolStripMenuItem.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        #endregion

        #region 菜单
        private void toolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton toolbtn = sender as ToolStripButton;            
            if (toolbtn.Tag != null)
            {
                switch (toolbtn.Tag.ToString())
                {
                    case "日志":
                        //skinTabControl1.SelectedTab = 日志Tag;
                        frmLog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                        frmLog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                        //frmLog.Size = this.panel6.Size;
                        //frmLog.Parent = this.panel6;//指定子窗体显示的容器
                        frmLog.Dock = DockStyle.Fill;
                        frmLog.Loadshow();
                        frmLog.Show();
                        frmLog.Activate();
                        break;
                    case "退出":
                        if (MessageBox.Show("是否退出软件", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                        {
                            //ConfigSpace.ConfigHandle.Instance.Save();
                            Application.Exit();
                            this.Close();
                            Process p = Process.GetCurrentProcess();
                            if (p != null)
                            {
                                p.Kill();
                            }
                        }
                        else
                        {
                            return;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        #endregion 

        #region  窗体事件

        private void Form_SubMain_Load(object sender, EventArgs e)
        {
            try
            {
                if (ConfigHandle.Instance.SystemDefine == null)
                {
                    ConfigHandle.Instance.SystemDefine = new ConfigSystem();
                }
                if (ConfigHandle.Instance.SystemDefine.ProjectDirectory != null && ConfigHandle.Instance.SystemDefine.ProjectDirectory != "")
                {
                    OpenProject(ConfigHandle.Instance.SystemDefine.ProjectDirectory);

                    btnload();

                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
#if DEBUG
                ChcekLicense();
#endif
            }
            
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {          

        }
        #endregion

        #region 常用事件

        private void DataBingdings()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show("数据绑定有问题 " + ex.ToString());
            }

        }
        private UserInfo userInfo;
        private FormLog frmLog;
        private Frm_Runing frm_Stick;

      
        public void InitializeControl()
        {
            StartUpdate.SendStartMsg("初始化控件");
            frmLog = new FormLog();
            userInfo = new UserInfo();
            frm_Stick = new Frm_Runing();
           
            
            frm_Stick.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            frm_Stick.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            frm_Stick.Size = this.panel1.Size;
            frm_Stick.Parent = this.panel1;//指定子窗体显示的容器
            frm_Stick.Dock = DockStyle.Fill;
            frm_Stick.Show();
            frm_Stick.Activate();
            StartUpdate.SendStartMsg("控件初始化完成");
            
            frm_Stick.data.DataBanding();
            frm_Stick.clean.databanding();
            frm_Stick.frm_Machine.Binding();
            StartUpdate.SendStartMsg("数据绑定完成");
        }
        #endregion
        #region 启动停止
        private TimerClass Timer = new TimerClass();
        private void btn_FsmControl_Click(object sender, EventArgs e)
        {
            ToolStripButton toolbtn = sender as ToolStripButton;
            if (toolbtn.Tag != null)
            {
                
                switch (toolbtn.Tag.ToString())
                {
                    case "FsmStart":
                        TaskManager.Default.FSM.Change(FSMStaDef.RUN);
                        DeviceRsDef.Q_GreenLed.ON();
                        DeviceRsDef.Q_RedLed.OFF();
                        DeviceRsDef.Q_YellowLed.OFF();
						ProVisionEbd.Device.CameraManager.Instance.UpdateProcessParameter();
                        ProVisionEbd.Device.CameraManager.Instance.Start();
                        break;
                    case "FsmPause":

                        break;
                    case "FsmStop":
                        TaskManager.Default.FSM.Change(FSMStaDef.STOP);
                        DeviceRsDef.Q_GreenLed.OFF();
                        DeviceRsDef.Q_RedLed.OFF();
                        DeviceRsDef.Q_YellowLed.ON();
						ProVisionEbd.Device.CameraManager.Instance.Stop();
                        break;
                    case "FsmReset":
                        AlarmClear();
                        foreach (var item in TaskManager.Default.LogicTasks)
                        {
                            item.Stop();
                            item.Reset();
                        }
                        TaskManager.Default.FSM.Change(FSMStaDef.RESET);
                        DeviceRsDef.Q_YellowLed.Value = Timer.Blink(true, 1000, 1000);
                        DeviceRsDef.Q_GreenLed.OFF();
                        DeviceRsDef.Q_RedLed.OFF();
						ProVisionEbd.Device.CameraManager.Instance.Stop();
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region 工程调度

        /// <summary>
        /// 工单文件存储的路径
        /// </summary>
        string pathRoad = null;

        /// <summary>
        /// 打开文件
        /// </summary>
        public void btn_PrjFileOpen()
        {
            VistaFolderBrowserDialog vistaFolder = new VistaFolderBrowserDialog();
            vistaFolder.SelectedPath = "D:\\程式\\";
            if (vistaFolder.ShowDialog() == DialogResult.OK)
            {
                OpenProject(vistaFolder.SelectedPath);               

                //toolStripButton_Click(主页Bt, null);
            }
        }
        /// <summary>
        /// 打开工程
        /// </summary>
        /// <param name="path"></param>
        private void OpenProject(string path)
        {
            try
            {
                pathRoad = path;
                {
                    //视觉
                    ProVisionEbd.Config.CfgManager.Instance.StrRoutineDir = pathRoad;
                    ProVisionEbd.Config.CfgManager.Instance.Load_Template();
                    frm_Stick.model.InitMatch();               
				 }
                //if (ConfigHandle.Instance.SystemDefine == null)
                //{
                //    ConfigHandle.Instance.SystemDefine = new ConfigSystem();
                //}
                ConfigHandle.Instance.SystemDefine.ProjectDirectory = path;
                ProjectData.Instance.OpenProject(path);
                toolStripButton1.Text = pathRoad.Substring(pathRoad.LastIndexOf('\\'));
                frm_Stick.data.DataBanding();
                frm_Stick.clean.databanding();
                if (ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine == null )
                {
                    ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine = new TeachingMechinePra();

                }
                if (ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine == null)
                {
                    ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine = new TeachingMechinePra();

                }
                frm_Stick.frm_Machine.Binding(); 
                frm_Stick.posmachine.databanding();

             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        /// <summary>
        /// 新建文件
        /// </summary>
        public void btn_PrjFileNew()
        {
            GC.Collect();
            Frm_NewProject frm = new Frm_NewProject();
            DialogResult result = frm.ShowDialog(this);
            if (result == DialogResult.Cancel)
            {
                if (frm.bln_IsOk)
                {
                    string FilePath = "D:\\程式\\" + frm.str_proName;
                    if (IsValidFileName(frm.str_proName) == false || string.IsNullOrEmpty(frm.str_proName))
                    {
                        MessageBox.Show("名称不合法");
                        return;
                    }
                    if (Directory.Exists(FilePath))
                    {
                        //提示消息，如果确认，删除文件夹
                        if (MessageBox.Show(this, "已存在同名项目，您确定要覆盖该项目？", ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.Yes)
                            return;

                        Directory.Delete(FilePath, true);
                        this.pathRoad = FilePath;
                    }
                    else
                    {
                        Directory.CreateDirectory(FilePath);
                        this.pathRoad = FilePath;
                        
                    }
                    ProjectData.Instance.CreatProject();
                    frm_Stick.data.DataBanding();
                    frm_Stick.clean.databanding();
                    frm_Stick.frm_Machine.Binding();
                    frm_Stick.posmachine.databanding();
                }
            }
        }
        /// <summary>
        /// 检查文件名是否合法.文字名中不能包含字符\/:*?"<>|
        /// </summary>
        /// <param name="fileName">文件名,不包含路径</param>
        /// <returns></returns>
        private bool IsValidFileName(string fileName)
        {
            bool isValid = true;
            string errChar = "\\/:*?\"<>|";  //
            if (string.IsNullOrEmpty(fileName))
            {
                isValid = false;
            }
            else
            {
                for (int i = 0; i < errChar.Length; i++)
                {
                    if (fileName.Contains(errChar[i].ToString()))
                    {
                        isValid = false;
                        break;
                    }
                }
            }
            return isValid;
        }
        
        /// <summary>
        /// 保存文件
        /// </summary>
        public void btn_PrjFileSave()
        {
            try
            {
                //ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Length1 = Rectangle2s.Length1;
                //ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Length2 = Rectangle2s.Length2;
                //ProjectData.Instance.SaveData.StickData.TrayData.rectangle2[0].Phi = Rectangle2s.Phi;


                if (pathRoad != null)
                {
                    ProjectData.Instance.SaveProject(pathRoad);
                  
                    MessageBox.Show("保存成功");
                    return;
                }
                VistaFolderBrowserDialog vistaFolder = new VistaFolderBrowserDialog();
                vistaFolder.SelectedPath = "D:\\程式\\";
                if (vistaFolder.ShowDialog() == DialogResult.OK)
                {
                    pathRoad = vistaFolder.SelectedPath;
                    string fileName = Path.GetFileName(pathRoad);
                    ConfigHandle.Instance.SystemDefine.ProjectDirectory = pathRoad;
                    ProjectData.Instance.SaveProject(pathRoad);
                    toolStripButton1.Text = pathRoad.Substring(pathRoad.LastIndexOf('\\'));                   
                }
                MessageBox.Show("保存成功");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败" + ex.ToString());
            }
        }
        /// <summary>
        /// 文件另存为
        /// </summary>
        public void btn_PrjFileSaveAs()
        {
            VistaFolderBrowserDialog SaveAs = new VistaFolderBrowserDialog();
            SaveAs.SelectedPath = "D:\\程式\\";
            if (SaveAs.ShowDialog() == DialogResult.OK)
            {
                //ProjectData.Instance.SaveProject(SaveAs.SelectedPath);
                //VisionProject.Instance.SaveTool(Path.Combine(SaveAs.SelectedPath, Path.GetFileNameWithoutExtension(SaveAs.SelectedPath)) + ".Vision");
            }
        }

        #endregion

        #region 定时器

        private int cnt = 0;
        private bool[,] b_statusError = new bool[20, 32];
        bool ShownForm = false;
        int count = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //控制器状态
            if (DeviceRsDef.MotionCard.netSucceed)
            {
                toolStripLabel1.Text = "卡1：ON" + "(" + DeviceRsDef.MotionCard.ScanfTime.ToString() + "ms" + ")";
                toolStripLabel1.BackColor = SystemColors.Control;
            }
            else
            {
                MachineAlarm.SetAlarm(AlarmLevelEnum.Level3, "控制器1掉线");
                for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                {
                    DeviceRsDef.AxisList[i].MC_Stop();
                }
                toolStripLabel1.Text = "卡1：OFF";
                toolStripLabel1.BackColor = Color.Red;
            }
            if (DeviceRsDef.MotionCard1.netSucceed)
            {
                toolStripLabel2.Text = "卡2：ON" + "(" + DeviceRsDef.MotionCard1.ScanfTime.ToString() + "ms" + ")";
                toolStripLabel2.BackColor = SystemColors.Control;
            }
            else
            {
                MachineAlarm.SetAlarm(AlarmLevelEnum.Level3, "控制器2掉线");
                for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
                {
                    DeviceRsDef.AxisList[i].MC_Stop();
                }
                toolStripLabel2.Text = "卡2：OFF";
                toolStripLabel2.BackColor = Color.Red;
            }

            //tlssll_CameraUp.Text = VisionProject.Instance.Camera[0].Connected ? "上相机：ONLine" : "上相机：OFFLine";
            //tlssll_CameraUp.BackColor = VisionProject.Instance.Camera[0].Connected ? SystemColors.Control : Color.Red;

            //tlssll_CameraDown.Text = VisionProject.Instance.Camera[1].Connected ? "下相机：ONLine" : "下相机：OFFLine";
            //tlssll_CameraDown.BackColor = VisionProject.Instance.Camera[1].Connected ? SystemColors.Control : Color.Red;
            
        }
        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AlarmClear();
        }
        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            AlarmClear();
            TaskManager.Default.FSM.Change(FSMStaDef.STOP);
        }
        private void AlarmClear()
        {

            Thread.Sleep(50);
            ConfigHandle.Instance.AlarmDefine.ClearAlarmMessage(b_statusError);
            MachineAlarm.ClearAlarm();
            for (int i = 0; i < DeviceRsDef.AxisList.Count; i++)
            {
                DeviceRsDef.AxisList[i].MC_AlarmReset();
            }
            frm_Stick.Clear();
        }
        #endregion

        #region 内存回收
        [DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize")]
        public static extern int SetProcessWorkingSetSize(IntPtr process, int minSize, int maxSize);
        /// <summary>
        /// 释放内存
        /// </summary>
        public static void ClearMemory()
        {
            GC.Collect();
            //GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                FormMain.SetProcessWorkingSetSize(System.Diagnostics.Process.GetCurrentProcess().Handle, -1, -1);
            }
        }
        #endregion
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStrip1.Focus();
            DeviceRsDef.MotionCard.MotionFun.MotionData.AxisConfigPara.Save(DeviceRsDef.MotionCard.port.ToString());
            DeviceRsDef.MotionCard1.MotionFun.MotionData.AxisConfigPara.Save(DeviceRsDef.MotionCard1.port.ToString());
            btn_PrjFileSave();
            ProVisionEbd.Config.CfgManager.Instance.Save();
            ConfigSpace.ConfigHandle.Instance.Save();
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolStripButton7.Text != "厂家")
            {
                MessageBox.Show("您当前没有权限进行用户管理操作", "提示");
                return;
            }
            frm_Stick.tabControl1.SelectedIndex = 9;
            userInfo.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            userInfo.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            userInfo.Dock = DockStyle.Fill;
            userInfo.Size = frm_Stick.panel4.Size;
            userInfo.Parent = frm_Stick.panel4;
            userInfo.Show();
            userInfo.Activate();
        }

        private void ToolStripMenuItem打开_Click(object sender, EventArgs e)
        {
            btn_PrjFileOpen();
        }

        private void ToolStripMenuItem新建_Click(object sender, EventArgs e)
        {
            btn_PrjFileNew();
        }
    }
}
