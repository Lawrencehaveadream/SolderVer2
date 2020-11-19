using CCWin.SkinClass;
using CommonRs;
using Device;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using HZZH.UI.DerivedControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProVisionEbd.Device;
using HalconDotNet;
using ProVision.MatchModel;
using ProVision.InteractiveROI;
using System.Collections;
using System.IO;
using ProVisionEbd.Vision.Parameter;
using ProVision.MatchModel;

namespace HZZH.ProjectUI
{
    public partial class model : Form
    {
        /// <summary>
        /// 标志当前回调函数获取到的图片是训练图片还是测试图片
        /// </summary>
        private bool _isImgForTrain = true;
        public model()
        {
            InitializeComponent();
            Initial();
        }
        private void showTrainImage()
        {
            try {
                HTuple imgW, imgH;
                HOperatorSet.GetImageSize(_imgTrain, out imgW, out imgH);
                this.halconWindowTrainImage.HalconWindow.SetPart(0, 0, imgH - 1, imgW - 1);
                this.halconWindowTrainImage.HalconWindow.DispObj(_imgTrain);
            }
            catch (Exception ex)
            {

            }
        }
        private void showTestImage()
        {
            try
            {
                HTuple imgW, imgH;
                HOperatorSet.GetImageSize(_imgTest, out imgW, out imgH);
                this.halconWindowTestImage.HalconWindow.SetPart(0, 0, imgH - 1, imgW - 1);
                this.halconWindowTestImage.HalconWindow.DispObj(_imgTest);
            }
            catch (Exception ex)
            {

            }
        }
        public bool IsRoutinueValid()
        {
            string str = GetPath_Routinue();
            if (string.IsNullOrEmpty(str)) return false;
            return true;
        }
        public bool CheckRoutinueValid()
        {
            if (IsRoutinueValid()) return true;
            MessageBox.Show("还没有打开程式!");
            return false;
        }
        private bool loadAndShowCurTrainFile()
        {
            try
            {
                //显示现有训练图片
                string path = GetPath_Routinue();
                FrmMatchModel fmm = getMatchModel(false);
                if (fmm == null) return false;
                ShapeModelAssistant ass = fmm.CtrlMatchModel.MatchAssistant;
                bool ok = (ass.LoadShapeModel(path) && ass.TrainImage != null && ass.TrainImage.IsInitialized());
                if (!ok) return false;
                FreeObj(ref this._imgTrain);
                this._imgTrain = ass.TrainImage.Clone();
                showTrainImage();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        private void model_Shown(object sender, EventArgs e)
        {
        }
        private FrmMatchModel getMatchModel(bool isCreate)
        {
            try
            {
                string path = GetPath_Routinue();
                if (string.IsNullOrEmpty(path)) return null;
                FrmMatchModel matchModel = null;
                if (isCreate)
                {
                    matchModel = new FrmMatchModel("zh-CN", this._imgTrain, path, null, true);
                }
                else
                {
                    matchModel = new FrmMatchModel("zh-CN", null, true);
                    matchModel.CtrlMatchModel.MatchAssistant.LoadShapeModel(path);
                }

                return matchModel;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        private void Initial()
        {
            EnsurePathExist();
            //加载设定的点





            //tabControl1.SelectedIndex = 0;
            //tabControl1.ItemSize = new Size(0, 1);
            //tabControl1.Appearance = TabAppearance.FlatButtons;
            //tabControl1.SizeMode = TabSizeMode.Fixed;

            //tabControl2.SelectedIndex = 0;
            //tabControl2.ItemSize = new Size(0, 1);
            //tabControl2.Appearance = TabAppearance.FlatButtons;
            //tabControl2.SizeMode = TabSizeMode.Fixed;


            //frm_jog = new XYZ_Jog();
            //frm_jog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            //frm_jog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            //frm_jog.Size = this.panel3.Size;
            //frm_jog.Parent = this.panel3;//指定子窗体显示的容器
            //frm_jog.Dock = DockStyle.Fill;
            //frm_jog.Show();
            //frm_jog.Activate();
            //propertyGrid1.SelectedObject = processData.test;

        }
        private void DataBingdings()
        {
            try
            {
                //Functions.SetBinding(numericUpDown1, "Value", ProductConfig.Inst.logicMain.LPolishPlatform..para, "X");
                //Functions.SetBinding(numericUpDown2, "Value", VisionProject.Instance.visionTool.OffsetLeft, "X");
                //Functions.SetBinding(numericUpDown4, "Value", VisionProject.Instance.visionTool.OffsetLeft, "X");
                //Functions.SetBinding(numericUpDown3, "Value", VisionProject.Instance.visionTool.OffsetLeft, "X");
            }
            catch (Exception ex)
            {
                MessageBox.Show("数据绑定有问题 " + ex.ToString());
            }

        }
        private void SaveDataGridView(List<PointFB> teachList, DataGridView dataGridView)
        {
            try
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    teachList[i].X = Convert.ToSingle(dataGridView.Rows[i].Cells[1].Value);
                    teachList[i].Y = Convert.ToSingle(dataGridView.Rows[i].Cells[2].Value);
                    teachList[i].Ban = dataGridView.Rows[i].Cells[3].Value.ToString() == "启用" ? false : true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public void LoadDGVData(List<PointFB> teachList, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            for (int i = 0; i < teachList.Count; i++)
            {
                #region 方法1

                DataGridViewRow row = new DataGridViewRow();
                DataGridViewTextBoxCell[] textboxcell = new DataGridViewTextBoxCell[7];
                for (int j = 0; j < 7; j++)
                {
                    textboxcell[j] = new DataGridViewTextBoxCell();
                }
                DataGridViewCheckBoxCell checkBoxcell = new DataGridViewCheckBoxCell();

                textboxcell[0].Value = i + 1;
                row.Cells.Add(textboxcell[0]);
                textboxcell[1].Value = teachList[i].Clone().X.ToString("f3");
                row.Cells.Add(textboxcell[1]);
                textboxcell[2].Value = teachList[i].Clone().Y.ToString("f3");
                row.Cells.Add(textboxcell[2]);
                textboxcell[3].Value = teachList[i].Clone().Ban ? "禁用" : "启用";
                row.Cells.Add(textboxcell[3]);
                dataGridView.Rows.Add(row);

                if (i % 2 == 0)
                {
                    dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.SystemColors.Window;
                }
                else
                {
                    dataGridView.Rows[dataGridView.Rows.Count - 1].DefaultCellStyle.BackColor = System.Drawing.SystemColors.Control;
                }

                #endregion
            }
            int index = 0;
            dataGridView.Columns[index].FillWeight = 5;
            index++;
            dataGridView.Columns[index].FillWeight = 8;
            index++;
            dataGridView.Columns[index].FillWeight = 8;
            index++;
            dataGridView.Columns[index].FillWeight = 8;

            int rownum = dataGridView.Rows.Count;

            if (rownum != 0)
            {
                dataGridView.CurrentCell = dataGridView.Rows[rownum - 1].Cells[0];
            }
        }
        private int _curCameraIndex = -1;    //默认0号相机
        private Camera getCurCamera()
        {
            try
            {
                CameraManager cm = CameraManager.Instance;
                string strId = cm.GetCameraID(this._curCameraIndex);
                if (cm.CameraList.ContainsKey(strId)) return cm.CameraList[strId];
                else return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private bool setImageGrabCallBack(bool isSetToThisForm)
        {
            try
            {
                CameraManager cm = CameraManager.Instance;
                Camera cam = getCurCamera();
                if (cam == null) return false;
                if (isSetToThisForm)
                {
                    cam.API.ImageGrabbedEvt -= cm.AddImage;
                    cam.API.ImageGrabbedEvt += AddImage;
                }
                else
                {
                    cam.API.ImageGrabbedEvt -= AddImage;
                    cam.API.ImageGrabbedEvt += cm.AddImage;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        private bool isCurCameraValid()
        {
            if (this._curCameraIndex < 0 || this._curCameraIndex > 3) return false;
            return true;
        }
        private void buttonGetTrainImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isCurCameraValid())
                {
                    MessageBox.Show("请先选择相机!");
                    return;
                }
                this._isImgForTrain = true;
                setImageGrabCallBack(true);
                ProVisionEbd.Logic.VisionInteraction.Instance.TriggerCamera(this._curCameraIndex);
            }
            catch(Exception ex)
            {
                MessageBox.Show("异常!");
                return;
            }
        }
        private HObject _imgTrain = null;
        private HObject _imgTest = null;
        private void FreeObj(ref HObject obj)
        {
            if (obj == null) return;
            obj.Dispose();
            obj = null;
        }
        private void TransObj(ref HObject src, ref HObject dest)
        {
            if (dest != null) FreeObj(ref dest);
            dest = src;
            src = null;
        }

        /// 添加图像
        /// [采集到图像事件回调,只需要负责将采集到的图像添加到图像列表]
        /// </summary>
        /// <param name="camProperty"></param>
        /// <param name="hoImage"></param>
        public void AddImage(ProCommon.Communal.CameraProperty camProperty, HalconDotNet.HObject hoImage)
        {
            try
            {
                if (this._isImgForTrain)
                {
                    TransObj(ref hoImage, ref this._imgTrain);
                    showTrainImage();
                }
                else
                {
                    TransObj(ref hoImage, ref this._imgTest);
                }
                hoImage = null;
            }
            catch(Exception ex)
            {
            }
            finally
            {
                setImageGrabCallBack(false);
            }
        }
        public string GetPath_Routinue()
        {
            string str = ProVisionEbd.Config.CfgManager.Instance.CfgVsPara.StrRoutineDir;
            if (!Directory.Exists(str)) return null;
            return str;
            //return "Routine/Test";
        }
        private void EnsurePathExist()
        {
            try
            {
                string path = GetPath_Routinue();
                if (string.IsNullOrEmpty(path)) return;
                Directory.CreateDirectory(path);
            }
            catch(Exception ex)
            {

            }          
        }
        private void buttonAddModel_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckRoutinueValid()) return;
                if (this._imgTrain == null || this._imgTrain.IsInitialized() == false)
                {
                    MessageBox.Show("请先设置训练图片!");
                    return;
                }
                FrmMatchModel matchModel = getMatchModel(true);
                if (matchModel == null) return;
                matchModel.ShowDialog();
                 //HTuple roiData = matchModel.CtrlMatchModel.MatchAssistant.ModelPose;
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonAddPoint_Click(object sender, EventArgs e)
        {
            HObject ROI = null;
            try
            {
                if (!CheckRoutinueValid()) return;
                if (!isCurCameraValid())
                {
                    MessageBox.Show("请先选择相机!");
                    return;
                }
                if (this._imgTrain == null || this._imgTrain.IsInitialized() == false)
                {
                    MessageBox.Show("请先设置训练图片!");
                    return;
                }
                FrmDefineAndModifyRegion frm = new FrmDefineAndModifyRegion("zh-CN", this._imgTrain);
                frm.ShowDialog();
                ArrayList list = frm.CtrlDefineAndModifyRegion.CtrlROIManager.ROIList;
                if (list.Count == 1)
                {
                    ROI = ((ProVision.InteractiveROI.ROI)list[0]).GetModelRegion();
                    HTuple ROIData = ((ProVision.InteractiveROI.ROI)list[0]).GetModelData();
                    if (ROIData.Length == 2)
                    {
                        AppVisionProcessParam param = ProVisionEbd.Config.CfgManager.Instance.CfgVsPara.GetParam(this._curCameraIndex);
                        if (param != null)
                        {
                            param.SpecifiedRow = (int)ROIData[0].D;
                            param.SpecifiedCol = (int)ROIData[1].D;
                            showTrainImage();
                            this.halconWindowTrainImage.HalconWindow.SetColor("green");
                            this.halconWindowTrainImage.HalconWindow.DispObj(ROI);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请绘制彷射矩形！");
                    }
                }
            }
            catch(Exception ex)
            {

            }
            finally
            {
                FreeObj(ref ROI);
            }
        }
        
        public bool Follow(ShapeModelAssistant ass, ref double row, ref double col)
        {
            try
            {
                if (ass == null || ass.Result == null || ass.ModelPose == null || ass.ModelPose.Length != 4) return false;
                HTuple mat = null;
                HOperatorSet.VectorAngleToRigid(ass.ModelPose[0], ass.ModelPose[1], ass.ModelPose[2], ass.Result.Row, ass.Result.Col, ass.Result.Angle, out mat);
                HTuple r, c;
                HOperatorSet.AffineTransPixel(mat, row, col, out r, out c);
                row = r.D;
                col = c.D;
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }

        }
        private void buttonTestPos_Click(object sender, EventArgs e)
        {
            HObject objTemp = null;
            try
            {
                if (!CheckRoutinueValid()) return;
                if (!isCurCameraValid())
                {
                    MessageBox.Show("请先选择相机!");
                    return;
                }
                if (this._imgTrain == null || this._imgTrain.IsInitialized() == false)
                {
                    MessageBox.Show("请先设置训练图片!");
                    return;
                }
                this._isImgForTrain = false;
                setImageGrabCallBack(true);
                ProVisionEbd.Logic.VisionInteraction.Instance.TriggerCamera(this._curCameraIndex);
                FreeObj(ref this._imgTest);
                DateTime dtStart = DateTime.Now;
                //等待获取到图片
                while (true)
                {
                    if (this._imgTest != null) break;
                    if (DateTime.Now - dtStart > new TimeSpan(0,0,5))
                    {
                        MessageBox.Show("获取图片失败!");
                        return;
                    }
                    Application.DoEvents();
                    System.Threading.Thread.Sleep(20);
                }
                showTestImage();
                FrmMatchModel match = getMatchModel(false);
                if (match == null) return;
                ShapeModelAssistant ass = match.CtrlMatchModel.MatchAssistant;
                ass.SetTestImage(this._imgTest);
                if (!ass.DetectShapeModel())
                {
                    MessageBox.Show("匹配模板失败!");
                    return;
                }
                FreeObj(ref objTemp);

                AppVisionProcessParam param = ProVisionEbd.Config.CfgManager.Instance.CfgVsPara.GetParam(this._curCameraIndex);
                if (param == null) return;

                double row = param.SpecifiedRow;
                double col = param.SpecifiedCol;
                if (!Follow(ass, ref row, ref col)) return;

                HOperatorSet.GenCrossContourXld(out objTemp, row, col, 300, 0);
                this.halconWindowTestImage.HalconWindow.SetColor("green");
                this.halconWindowTestImage.HalconWindow.DispObj(objTemp);
            }
            catch (Exception ex)
            {
                FreeObj(ref objTemp);
            }
        }

        private void buttonLeftPolish_Click(object sender, EventArgs e)
        {
            SwitchCamera(0);
        }

        private void buttonRightPolish_Click(object sender, EventArgs e)
        {
            SwitchCamera(1);
        }

        private void buttonLeftSolder_Click(object sender, EventArgs e)
        {
            SwitchCamera(2);
        }

        private void buttonRightSolder_Click(object sender, EventArgs e)
        {
            SwitchCamera(3);
        }
        private void SwitchCamera(int index)
        {
            try
            {
                this._curCameraIndex = index;
                ProVisionEbd.Config.CfgManager.Instance.CfgVsPara.LoadPoint(this._curCameraIndex);
                loadAndShowCurTrainFile();
            }
            catch(Exception ex)
            {

            }
        }
    }
}
