using CCWin.SkinClass;
using CommonRs;
using Device;
using HzControl.Logic;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using HZZH.Logic.LogicMain;
using HZZH.Logic.LogicMission;
using HZZH.ProjectUI;
using HZZH.UI;
using HZZH.UI.DerivedControl;
using MyControl;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;
using Vision.PointLayout;
using Point = HZZH.ProjectUI.Point;

namespace HZZH.Logic.UI
{
    public partial class Frm_Runing : Form
    {
        public Frm_Runing()
        {
            try
            {
                InitializeComponent();              
                InitializeControl();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                timer1.Enabled = true;
                timer1.Interval = 200;
            }
        }    

        public Point point;
        private XYZ_Jog frm_jog;
        private InputOutput IOControl;
        private UserInfo userInfo;
        private FormLog frmLog;
        private Frm_MotorParam Frm_Machine; 
        public Frm_Machine frm_Machine;
        public model model;
        public parameter data;
        public Clean clean;
        public PosMachine posmachine;

        #region 视觉功能模块

        /// <summary>
        /// 图形结果管理器
        /// </summary>
        private ProVision.InteractiveROI.HWndCtrller _hwndCtrller0, _hwndCtrller1, _hwndCtrller2, _hwndCtrller3;
        private HalconDotNet.HObject _hoImage0, _hoImage1, _hoImage2, _hoImage3;

        /// <summary>
        /// 程式参数
        /// </summary>
        private ProVisionEbd.Config.CfgVisionParam _cfgVisionParam;
        /// <summary>
        /// 系统配置参数
        /// </summary>
        private ProVisionEbd.Config.CfgSystem _cfgSystem;

        /// <summary>
        /// 视觉模块函数入口
        /// </summary>
        private void VisionModule()
        {
            string visionErr;

            //视觉功能初始化入口
            ProVisionEbd.Logic.SystemManager.Instance.CheckSystem(true);

            //视觉功能自检OK;
            if (ProVisionEbd.Logic.SystemManager.Instance.SysChkOK)
            {
                //绑定图形管理器与对应的窗口

                if (_hwndCtrller0 == null)
                    _hwndCtrller0 = new ProVision.InteractiveROI.HWndCtrller(this.hWndcDisplay0);

                if (_hwndCtrller1 == null)
                    _hwndCtrller1 = new ProVision.InteractiveROI.HWndCtrller(this.hWndcDisplay1);

                if (_hwndCtrller2 == null)
                    _hwndCtrller2 = new ProVision.InteractiveROI.HWndCtrller(this.hWndcDisplay2);

                if (_hwndCtrller3 == null)
                    _hwndCtrller3 = new ProVision.InteractiveROI.HWndCtrller(this.hWndcDisplay3);

                if (ProVisionEbd.Device.CameraManager.Instance.Init())
                {
                    if (ProVisionEbd.Device.CameraManager.Instance.Start())
                    {
                        //注销运行(多视图)状态时的图形变量更新事件
                        ProVisionEbd.Device.CameraManager.Instance.Camera0UpdateIconicEvent -= Camera0UpdateIconic;
                        ProVisionEbd.Device.CameraManager.Instance.Camera1UpdateIconicEvent -= Camera1UpdateIconic;
                        ProVisionEbd.Device.CameraManager.Instance.Camera2UpdateIconicEvent -= Camera2UpdateIconic;
                        ProVisionEbd.Device.CameraManager.Instance.Camera3UpdateIconicEvent -= Camera3UpdateIconic;

                        //重新注册运行(多视图)状态时的图形变量更新事件
                        ProVisionEbd.Device.CameraManager.Instance.Camera0UpdateIconicEvent += Camera0UpdateIconic;
                        ProVisionEbd.Device.CameraManager.Instance.Camera1UpdateIconicEvent += Camera1UpdateIconic;
                        ProVisionEbd.Device.CameraManager.Instance.Camera2UpdateIconicEvent += Camera2UpdateIconic;
                        ProVisionEbd.Device.CameraManager.Instance.Camera3UpdateIconicEvent += Camera3UpdateIconic;


                        //相机资源初始化成功且启动成功:更新图像识别过程参数
                        _cfgSystem = ProVisionEbd.Config.CfgManager.Instance.CfgSys;
                        _cfgVisionParam = ProVisionEbd.Config.CfgManager.Instance.CfgVsPara;

                        //加载程式参数,根据程式参数设置相机
                        if (System.IO.File.Exists("这里需要给程式路径!!!"))
                        {
                            try
                            {
                                using (var fs = new System.IO.FileStream(_cfgSystem.RoutineDirectory + _cfgSystem.RoutineName + ".pro", System.IO.FileMode.Open))
                                {
                                    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                                    _cfgVisionParam = (ProVisionEbd.Config.CfgVisionParam)bf.Deserialize(fs);
                                    ProVisionEbd.Config.CfgManager.Instance.CfgVsPara = _cfgVisionParam;
                                }

                                ProVisionEbd.Device.CameraManager.Instance.SetIsClearImage(true);
                                ProVisionEbd.Device.CameraManager.Instance.UpdateProcessParameter();
                                ProVisionEbd.Device.CameraManager.Instance.SetCameraWithRunModeParam(true);
                            }
                            catch (System.Exception ex) { }
                        }
                    }
                    //视觉启动相机异常
                    else
                    {
                        visionErr = ProVisionEbd.Device.CameraManager.Instance.ErrorMessage.ToString();
                    }
                }
                //视觉初始化相机异常
                else
                {
                    visionErr = ProVisionEbd.Device.CameraManager.Instance.ErrorMessage.ToString();
                }
            }
            //视觉功能自检NG;
            else
            {
                visionErr = ProVisionEbd.Logic.SystemManager.Instance.SysChkError;
            }
        }

        /// <summary>
        /// 窗口1显示的内容
        /// [可以自定义显示的内容]
        /// </summary>
        /// <param name="appProData"></param>
        private void Camera0UpdateIconic(ProVisionEbd.Data.AppProcessData appProData)
        {
            try
            {
                if(_hwndCtrller0!=null)
                {
                    if(appProData!=null)
                    {
                        this.Invoke(new System.Windows.Forms.MethodInvoker(()=> {

                            _hwndCtrller0.ClearEntities();
                            _hwndCtrller0.ClearMessageLineList();

                            if (_hoImage0 != null
                                 && _hoImage0.IsInitialized())
                                _hoImage0.Dispose();

                            _hoImage0 = appProData.RawImage.Clone();
                            _hwndCtrller0.AddHobjEntity(_hoImage0);

                            _hwndCtrller0.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "yellow");
                            _hwndCtrller0.AddHobjEntity(appProData.InspetcRegion);
                            ProVision.Communal.MessageLine msl = new ProVision.Communal.MessageLine();

                            if (appProData.ImgProcessOK)
                            {
                                if (appProData.ImgResultOK)
                                {
                                    msl.Context = "处理结果满足要求";
                                    msl.CtxColor = "green";
                                    _hwndCtrller0.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "green");
                                }
                                else
                                {
                                    msl.Context = "处理结果不满足要求";
                                    msl.CtxColor = "red";
                                    _hwndCtrller0.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "red");
                                }
                            }
                            else
                            {
                                msl.Context = "图像处理异常";
                                msl.CtxColor = "red";
                                _hwndCtrller0.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "red");
                            }

                            _hwndCtrller0.AddMessageLine(msl);
                            _hwndCtrller0.AddHobjEntity(appProData.ResultRegion);
                            _hwndCtrller0.Repaint();
                            appProData.Dispose();

                        }));
                    }
                }
            }
            catch (HalconDotNet.HalconException hex) { }
            catch (System.Exception ex) { }
        }

        /// <summary>
        /// 窗口2显示的内容
        /// [可以自定义显示的内容] 
        /// </summary>
        /// <param name="appProData"></param>
        private void Camera1UpdateIconic(ProVisionEbd.Data.AppProcessData appProData)
        {
            try
            {
                if (_hwndCtrller1 != null)
                {
                    if (appProData != null)
                    {
                        this.Invoke(new System.Windows.Forms.MethodInvoker(() => {

                            _hwndCtrller1.ClearEntities();
                            _hwndCtrller1.ClearMessageLineList();

                            if (_hoImage1 != null
                                 && _hoImage1.IsInitialized())
                                _hoImage1.Dispose();

                            _hoImage1 = appProData.RawImage.Clone();
                            _hwndCtrller1.AddHobjEntity(_hoImage1);

                            _hwndCtrller1.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "yellow");
                            _hwndCtrller1.AddHobjEntity(appProData.InspetcRegion);
                            ProVision.Communal.MessageLine msl = new ProVision.Communal.MessageLine();

                            if (appProData.ImgProcessOK)
                            {
                                if (appProData.ImgResultOK)
                                {
                                    msl.Context = "处理结果满足要求";
                                    msl.CtxColor = "green";
                                    _hwndCtrller1.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "green");
                                }
                                else
                                {
                                    msl.Context = "处理结果不满足要求";
                                    msl.CtxColor = "red";
                                    _hwndCtrller1.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "red");
                                }
                            }
                            else
                            {
                                msl.Context = "图像处理异常";
                                msl.CtxColor = "red";
                                _hwndCtrller1.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "red");
                            }

                            _hwndCtrller1.AddMessageLine(msl);
                            _hwndCtrller1.AddHobjEntity(appProData.ResultRegion);
                            _hwndCtrller1.Repaint();
                            appProData.Dispose();

                        }));
                    }
                }
            }
            catch (HalconDotNet.HalconException hex) { }
            catch (System.Exception ex) { }
        }

        /// <summary>
        /// 窗口3显示的内容
        /// [可以自定义显示的内容]
        /// </summary>
        /// <param name="appProData"></param>
        private void Camera2UpdateIconic(ProVisionEbd.Data.AppProcessData appProData)
        {
            try
            {
                if (_hwndCtrller2 != null)
                {
                    if (appProData != null)
                    {
                        this.Invoke(new System.Windows.Forms.MethodInvoker(() => {

                            _hwndCtrller2.ClearEntities();
                            _hwndCtrller2.ClearMessageLineList();

                            if (_hoImage2 != null
                                 && _hoImage2.IsInitialized())
                                _hoImage2.Dispose();

                            _hoImage2 = appProData.RawImage.Clone();
                            _hwndCtrller2.AddHobjEntity(_hoImage2);

                            _hwndCtrller2.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "yellow");
                            _hwndCtrller2.AddHobjEntity(appProData.InspetcRegion);
                            ProVision.Communal.MessageLine msl = new ProVision.Communal.MessageLine();

                            if (appProData.ImgProcessOK)
                            {
                                if (appProData.ImgResultOK)
                                {
                                    msl.Context = "处理结果满足要求";
                                    msl.CtxColor = "green";
                                    _hwndCtrller2.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "green");
                                }
                                else
                                {
                                    msl.Context = "处理结果不满足要求";
                                    msl.CtxColor = "red";
                                    _hwndCtrller2.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "red");
                                }
                            }
                            else
                            {
                                msl.Context = "图像处理异常";
                                msl.CtxColor = "red";
                                _hwndCtrller2.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "red");
                            }

                            _hwndCtrller2.AddMessageLine(msl);
                            _hwndCtrller2.AddHobjEntity(appProData.ResultRegion);
                            _hwndCtrller2.Repaint();
                            appProData.Dispose();

                        }));
                    }
                }
            }
            catch (HalconDotNet.HalconException hex) { }
            catch (System.Exception ex) { }
        }

        /// <summary>
        /// 窗口4显示的内容
        /// [可以自定义显示的内容]
        /// </summary>
        /// <param name="appProData"></param>
        private void Camera3UpdateIconic(ProVisionEbd.Data.AppProcessData appProData)
        {
            try
            {
                if (_hwndCtrller3 != null)
                {
                    if (appProData != null)
                    {
                        this.Invoke(new System.Windows.Forms.MethodInvoker(() => {

                            _hwndCtrller3.ClearEntities();
                            _hwndCtrller3.ClearMessageLineList();

                            if (_hoImage3 != null
                                 && _hoImage3.IsInitialized())
                                _hoImage3.Dispose();

                            _hoImage3 = appProData.RawImage.Clone();
                            _hwndCtrller3.AddHobjEntity(_hoImage3);

                            _hwndCtrller3.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "yellow");
                            _hwndCtrller3.AddHobjEntity(appProData.InspetcRegion);
                            ProVision.Communal.MessageLine msl = new ProVision.Communal.MessageLine();

                            if (appProData.ImgProcessOK)
                            {
                                if (appProData.ImgResultOK)
                                {
                                    msl.Context = "处理结果满足要求";
                                    msl.CtxColor = "green";
                                    _hwndCtrller3.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "green");
                                }
                                else
                                {
                                    msl.Context = "处理结果不满足要求";
                                    msl.CtxColor = "red";
                                    _hwndCtrller3.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "red");
                                }
                            }
                            else
                            {
                                msl.Context = "图像处理异常";
                                msl.CtxColor = "red";
                                _hwndCtrller3.ChangeGraphicSettings(ProVision.InteractiveROI.GraphicContext.GC_COLOR, "red");
                            }

                            _hwndCtrller3.AddMessageLine(msl);
                            _hwndCtrller3.AddHobjEntity(appProData.ResultRegion);
                            _hwndCtrller3.Repaint();
                            appProData.Dispose();

                        }));
                    }
                }
            }
            catch (HalconDotNet.HalconException hex) { }
            catch (System.Exception ex) { }
        }

        #endregion


        #region 初始化
        private void InitializeControl()
        {



            LogicStatus.Instance.Logic.Init();//模块任务添加到线程池
            point = new Point();

            
            posmachine = new PosMachine();
            ShowMessge.StartMsg += new ShowMessge.SendStartMsgEventHandler(ShowMessage);
            clean = new Clean();
            model = new model();
            data = new parameter();
            userInfo = new UserInfo();
            Frm_Machine = new Frm_MotorParam();
            frmLog = new FormLog();
            frm_jog = new XYZ_Jog();
            frm_Machine = new Frm_Machine();

            
            comboBox1.SelectedIndex = 1;
            tabControl1.SelectedIndex = 0;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.SizeMode = TabSizeMode.Fixed;

            data.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            data.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            data.Size = this.panel16.Size;
            data.Parent = this.panel16;//指定子窗体显示的容器
            data.Dock = DockStyle.Fill;
            data.Show();
            data.Activate();

            model.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            model.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            model.Size = this.panel13.Size;
            model.Parent = this.panel13;//指定子窗体显示的容器
            model.Dock = DockStyle.Fill;
            model.Show();
            model.Activate();
        }
        #endregion

        #region 报警

        public void ShowMessage(SendCmdArgs e)
        {
            if (IsDisposed || !userCtrlMsgListView1.Parent.IsHandleCreated) return;
            this.Invoke((Action)(() =>
            {
                userCtrlMsgListView1.AddUserMsg(e.StrReciseve, "提示");
            }));
        }

        public void Clear()
        {
            if ( IsDisposed || !userCtrlMsgListView1.Parent.IsHandleCreated) return;
            this.Invoke((Action)(() =>
            {
                userCtrlMsgListView1.ClearMsgItems();
            }));
        }
        #endregion

        #region 定时器
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IOControl != null)
            {
                IOControl.ValueChangedRefresh();
            }
            if (comboBox1.SelectedIndex == 0)
            {
                TaskManager.Default.FSM.MODE = 0;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                TaskManager.Default.FSM.MODE = 1;
            }
            //左侧
            label3.Text = "打磨次数：" + ProjectData.Instance.SaveData.PolishPlatform[0].PolishSum;
            label4.Text = "焊锡次数：" + ProjectData.Instance.SaveData.SolderPlatform[0].SolderSum;
            label7.Text = "打磨周期：" + ProjectData.Instance.SaveData.PolishPlatform[0].PolishSpendTime;
            label13.Text = "焊锡周期：" + ProjectData.Instance.SaveData.SolderPlatform[0].SolderSpendTime;
            //右侧
            label9.Text = "打磨次数：" + ProjectData.Instance.SaveData.PolishPlatform[1].PolishSum;
            label11.Text = "焊锡次数：" +ProjectData.Instance.SaveData.SolderPlatform[1].SolderSum;
            label5.Text = "打磨周期：" + ProjectData.Instance.SaveData.PolishPlatform[1].PolishSpendTime;
            label6.Text = "焊锡周期：" + ProjectData.Instance.SaveData.SolderPlatform[1].SolderSpendTime;
            label10.Text = "皮带位置：" + DeviceRsDef.Axis_Belt.currPos ;

            label8.Text = "UPH:" + ProjectData.Instance.Product.UPH;
            switch (TaskManager.Default.FSM.Status.ID)
            {

                case FSMStaDef.INIT:
                    label1.Text = "设备初始";
                    label1.BackColor = SystemColors.ActiveCaption;
                    break;

                case FSMStaDef.PAUSE:
                    label1.Text = "设备暂停";
                    label1.BackColor = Color.Yellow;
                    break;

                case FSMStaDef.RESET:
                    label1.Text = "设备复位";
                    label1.BackColor = Color.Red;
                    break;

                case FSMStaDef.RUN:
                    label1.Text = "设备运行";
                    label1.BackColor = Color.Green;
                    break;

                case FSMStaDef.SCRAM:
                    label1.Text = "设备急停";
                    label1.BackColor = Color.Red;
                    break;

                case FSMStaDef.STOP:
                    label1.Text = "设备停止";
                    label1.BackColor = Color.Yellow;
                    break;

                case FSMStaDef.ALARM:
                    label1.Text = "错误暂停";
                    label1.BackColor = Color.Yellow;
                    break;

                case FSMStaDef.ERROR:
                    label1.Text = "错误停止";
                    label1.BackColor = Color.Red;
                    break;
            }
        }
        #endregion

        /// <summary>
        /// 界面切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void toolStripButton1_Click(object sender, EventArgs e)
        {
            ToolStripButton btn =  (ToolStripButton)sender;
            switch (btn.Tag.ToInt32())
            {
                case 1:
                    tabControl1.SelectedIndex = 0;
                    break;
                case 2:
                    tabControl1.SelectedIndex = 1;
                    Frm_Machine.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                    Frm_Machine.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                    Frm_Machine.Size = this.panel12.Size;
                    Frm_Machine.Parent = this.panel12;//指定子窗体显示的容器
                    Frm_Machine.Dock = DockStyle.Fill;
                    Frm_Machine.Show();
                    Frm_Machine.Activate();
                    break;
                case 3:
                    tabControl1.SelectedIndex = 2;
                    if (IOControl == null || IOControl.IsDisposed || IOControl.Disposing)
                    {
                        IOControl = new InputOutput(DeviceRsDef.InputList,DeviceRsDef.OutputList, "INPUTDEFINE.csv", "OUTPUTDEFINE.csv");
                    }
                    IOControl.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                    IOControl.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                    IOControl.Size = this.panel11.Size;
                    IOControl.Parent = this.panel11;//指定子窗体显示的容器
                    IOControl.Dock = DockStyle.Fill;
                    IOControl.Show();
                    IOControl.Activate();
                    break;
                case 6:
                    tabControl1.SelectedIndex = 5;
                    frm_Machine.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                    frm_Machine.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                    frm_Machine.Size = this.panel15.Size;
                    frm_Machine.Parent = this.panel15;//指定子窗体显示的容器
                    frm_Machine.Dock = DockStyle.Fill;
                    frm_Machine.Show();
                    frm_Machine.Activate();
                    break;
                case 7:
                    
                    tabControl1.SelectedIndex = 6;
                    clean.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                    clean.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                    clean.Size = this.panel17.Size;
                    clean.Parent = this.panel17;//指定子窗体显示的容器
                    clean.Dock = DockStyle.Fill;
                    clean.Show();
                    clean.Activate();
                    break;
                case 8:

                    tabControl1.SelectedIndex = 7;
                    posmachine.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                    posmachine.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                    posmachine.Size = this.panel18.Size;
                    posmachine.Parent = this.panel18;//指定子窗体显示的容器
                    posmachine.Dock = DockStyle.Fill;
                    posmachine.Show();
                    posmachine.Activate();
                    break;
                case 9:

                    tabControl1.SelectedIndex = 8;
                    point.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
                    point.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
                    point.Size = this.panel19.Size;
                    point.Parent = this.panel19;//指定子窗体显示的容器
                    point.Dock = DockStyle.Fill;
                    point.Show();
                    point.Activate();
                    break;

            }
        }
        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 4;
        }
        /// <summary>
        /// 模式切换 老化/正常
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    TaskManager.Default.FSM.MODE = 0;
                    break;
                case 1:
                    TaskManager.Default.FSM.MODE = 1;
                    break;
            }
        }
        /// <summary>
        /// 清零
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "1":

                    ProjectData.Instance.SaveData.PolishPlatform[0].PolishSum = 0;
                    break;
                case "2":

                    ProjectData.Instance.SaveData.SolderPlatform[0].SolderSum = 0;
                    break;
                case "3":
                    ProjectData.Instance.SaveData.PolishPlatform[1].PolishSum = 0;
                    break;
                case "4":
                    ProjectData.Instance.SaveData.SolderPlatform[1].SolderSum = 0;
                    break;
            }
        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedIndex = 3;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Frm_Runing_Load(object sender, EventArgs e)
        {
            /*
            this.cameraDisplayWindows1.SetCamera(VisionProject.Instance.Camera[0]);
            this.cameraDisplayWindows2.SetCamera(VisionProject.Instance.Camera[1]);
            this.cameraDisplayWindows3.SetCamera(VisionProject.Instance.Camera[2]);
            this.cameraDisplayWindows4.SetCamera(VisionProject.Instance.Camera[3]);

            VisionProject.Instance.SetDisplayWindow(0, this.cameraDisplayWindows1.HWindow);
            VisionProject.Instance.SetDisplayWindow(1, this.cameraDisplayWindows2.HWindow);
            VisionProject.Instance.SetDisplayWindow(2, this.cameraDisplayWindows3.HWindow);
            VisionProject.Instance.SetDisplayWindow(3, this.cameraDisplayWindows4.HWindow);
            */

            VisionModule();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            TaskManager.Default.FindTask("皮带流程").Start();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DeviceRsDef.Axis_Belt.MC_MoveRel(100);
        }
    }
}
