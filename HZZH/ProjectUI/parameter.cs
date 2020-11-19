using CCWin.SkinClass;
using CommonRs;
using HzControl.Logic;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using HZZH.Logic.LogicMission;
using HZZH.UI.DerivedControl;
using log4net.Util.TypeConverters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZZH.ProjectUI
{
    public partial class parameter : Form
    {
        
        public parameter()
        {
            InitializeComponent();
            Initial();
        }
        private XYZ_Jog frm_jog;
        private void Initial()
        {
            if (ProjectData.Instance.SaveData.processdata.LocatedPointPos == null)
            {
                ProjectData.Instance.SaveData.processdata.LocatedPointPos = new PointF4();
            }
            DataBanding();
            tabControl1.SelectedIndex = 0;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.SizeMode = TabSizeMode.Fixed;
            
            frm_jog = new XYZ_Jog();
            frm_jog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            frm_jog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            frm_jog.Size = this.panel2.Size;
            frm_jog.Parent = this.panel2;//指定子窗体显示的容器
            frm_jog.Dock = DockStyle.Fill;
            frm_jog.Show();
            frm_jog.Activate();
            frm_jog.Tagbanding(1);

            button10.BackColor = Color.Green;
            button9.BackColor = SystemColors.ControlLight;
            button8.BackColor = SystemColors.ControlLight;
            button5.BackColor = SystemColors.ControlLight;
            LoadDGVData(ProjectData.Instance.SaveData.processdata.PolishCTPos[0], dataGridView1);
            //button10_Click(button10, null);
        }
        /// <summary>
        /// 右键添加点/暂时不用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_MouseUp(object sender, MouseEventArgs e)
        {
            DataGridView.HitTestInfo hitTestInfo;
            if (e.Button == MouseButtons.Right)
            {
                hitTestInfo = dataGridView1.HitTest(e.X, e.Y);
                if (hitTestInfo.Type == DataGridViewHitTestType.Cell)
                {
                    contextMenuStrip1.Show(dataGridView1, e.Location);
                }
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
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void DataBanding()
        {
            try
            {   //左打磨平台
                Functions.SetBinding(numericUpDown1, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].ResetPos, "X");
                Functions.SetBinding(numericUpDown2, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].ResetPos, "Y");
                Functions.SetBinding(numericUpDown4, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].ResetPos, "Z");
                Functions.SetBinding(numericUpDown3, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].ResetPos, "R");

                Functions.SetBinding(numericUpDown8, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].EndPos, "X");
                Functions.SetBinding(numericUpDown7, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].EndPos, "Y");
                Functions.SetBinding(numericUpDown6, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].EndPos, "Z");
                Functions.SetBinding(numericUpDown5, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].EndPos, "R");

                Functions.SetBinding(numericUpDown48, "Value", ProjectData.Instance.SaveData.PolishData[0], "SafeZ");
                Functions.SetBinding(numericUpDown51, "Value", ProjectData.Instance.SaveData.PolishData[0], "Reimburse");
                Functions.SetBinding(numericUpDown9, "Value", ProjectData.Instance.SaveData.PolishData[0], "Interval");
                Functions.SetBinding(numericUpDown10, "Value", ProjectData.Instance.SaveData.PolishData[0], "TimesTotal");
                Functions.SetBinding(numericUpDown11, "Value", ProjectData.Instance.SaveData.PolishData[0], "CTDelay");
                //右打磨平台
                Functions.SetBinding(numericUpDown24, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].ResetPos, "X");
                Functions.SetBinding(numericUpDown23, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].ResetPos, "Y");
                Functions.SetBinding(numericUpDown22, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].ResetPos, "Z");
                Functions.SetBinding(numericUpDown21, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].ResetPos, "R");

                Functions.SetBinding(numericUpDown19, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].EndPos, "X");
                Functions.SetBinding(numericUpDown18, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].EndPos, "Y");
                Functions.SetBinding(numericUpDown17, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].EndPos, "Z");
                Functions.SetBinding(numericUpDown16, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].EndPos, "R");

                Functions.SetBinding(numericUpDown15, "Value", ProjectData.Instance.SaveData.PolishData[1], "SafeZ");
                Functions.SetBinding(numericUpDown20, "Value", ProjectData.Instance.SaveData.PolishData[1], "Reimburse");
                Functions.SetBinding(numericUpDown14, "Value", ProjectData.Instance.SaveData.PolishData[1], "Interval");
                Functions.SetBinding(numericUpDown13, "Value", ProjectData.Instance.SaveData.PolishData[1], "TimesTotal");
                Functions.SetBinding(numericUpDown12, "Value", ProjectData.Instance.SaveData.PolishData[1], "CTDelay");
                //左上锡
                Functions.SetBinding(numericUpDown32, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].ResetPos, "X");
                Functions.SetBinding(numericUpDown31, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].ResetPos, "Y");
                Functions.SetBinding(numericUpDown30, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].ResetPos, "Z");
                Functions.SetBinding(numericUpDown29, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].ResetPos, "R");

                Functions.SetBinding(numericUpDown28, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].EndPos, "X");
                Functions.SetBinding(numericUpDown27, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].EndPos, "Y");
                Functions.SetBinding(numericUpDown26, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].EndPos, "Z");
                Functions.SetBinding(numericUpDown25, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].EndPos, "R");

                Functions.SetBinding(numericUpDown33, "Value", ProjectData.Instance.SaveData.SolderData[0], "SafeZ");
                Functions.SetBinding(numericUpDown34, "Value", ProjectData.Instance.SaveData.SolderData[0], "CTDelay");
                Functions.SetBinding(numericUpDown45, "Value", ProjectData.Instance.SaveData.SolderPlatform[0], "TimeforTin");


                //右上锡
                Functions.SetBinding(numericUpDown44, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].ResetPos, "X");
                Functions.SetBinding(numericUpDown43, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].ResetPos, "Y");
                Functions.SetBinding(numericUpDown42, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].ResetPos, "Z");
                Functions.SetBinding(numericUpDown41, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].ResetPos, "R");

                Functions.SetBinding(numericUpDown40, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].EndPos, "X");
                Functions.SetBinding(numericUpDown39, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].EndPos, "Y");
                Functions.SetBinding(numericUpDown38, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].EndPos, "Z");
                Functions.SetBinding(numericUpDown37, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].EndPos, "R");

                Functions.SetBinding(numericUpDown36, "Value", ProjectData.Instance.SaveData.SolderData[1], "SafeZ");
                Functions.SetBinding(numericUpDown35, "Value", ProjectData.Instance.SaveData.SolderData[1], "CTDelay");
                Functions.SetBinding(numericUpDown46, "Value", ProjectData.Instance.SaveData.SolderPlatform[1], "TimeforTin");
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 加载打磨和焊锡拍照位置
        /// </summary>
        /// <param name="teachList"></param>
        /// <param name="dataGridView"></param>
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
        /// <summary>
        /// 四个平台切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Button[] bbt = new Button[4];
            bbt[0] = button10;
            bbt[1] = button9;
            bbt[2] = button8;
            bbt[3] = button5;
            switch (btn.Tag.ToInt32())
            {
                case 1:
                    button1.Tag = 1;
                    button2.Tag = 2;
                    button3.Tag = 3;
                    button4.Tag = 4;
                    frm_jog.Tagbanding(1);
                    tabControl1.SelectedIndex = 0;
                    bbt[0].BackColor = Color.Green;
                    bbt[1].BackColor = SystemColors.ControlLight;
                    bbt[2].BackColor = SystemColors.ControlLight;
                    bbt[3].BackColor = SystemColors.ControlLight;
                    LoadDGVData(ProjectData.Instance.SaveData.processdata.PolishCTPos[0], dataGridView1);
                    //SaveDataGridView(ProductConfig.Inst.processdata.PolishCTPos[0], dataGridView1);
                    
                    break;
                case 2:
                    button1.Tag = 5;
                    button2.Tag = 6;
                    button3.Tag = 7;
                    button4.Tag = 8;
                    frm_jog.Tagbanding(2);
                    tabControl1.SelectedIndex = 1;
                    bbt[0].BackColor = SystemColors.ControlLight;
                    bbt[1].BackColor = Color.Green;
                    bbt[2].BackColor = SystemColors.ControlLight;
                    bbt[3].BackColor = SystemColors.ControlLight;
                    LoadDGVData(ProjectData.Instance.SaveData.processdata.PolishCTPos[1], dataGridView1);
                    //SaveDataGridView(ProductConfig.Inst.processdata.PolishCTPos[1], dataGridView1);
                    
                    break;
                case 3:
                    button1.Tag = 9;
                    button2.Tag = 10;
                    button3.Tag = 11;
                    button4.Tag = 12;
                    frm_jog.Tagbanding(3);
                    tabControl1.SelectedIndex = 2;
                    bbt[0].BackColor = SystemColors.ControlLight;
                    bbt[1].BackColor = SystemColors.ControlLight;
                    bbt[2].BackColor = Color.Green;
                    bbt[3].BackColor = SystemColors.ControlLight;
                    LoadDGVData(ProjectData.Instance.SaveData.processdata.SolderCTPos[0], dataGridView1);
                    //SaveDataGridView(ProductConfig.Inst.processdata.SolderCTPos[0], dataGridView1);
                    
                    break;
                case 4:
                    button1.Tag = 13;
                    button2.Tag = 14;
                    button3.Tag = 15;
                    button4.Tag = 16;
                    frm_jog.Tagbanding(4);
                    tabControl1.SelectedIndex = 3;

                    bbt[0].BackColor = SystemColors.ControlLight;
                    bbt[1].BackColor = SystemColors.ControlLight;
                    bbt[2].BackColor = SystemColors.ControlLight;
                    bbt[3].BackColor = Color.Green;
                    LoadDGVData(ProjectData.Instance.SaveData.processdata.SolderCTPos[1], dataGridView1);
                    //SaveDataGridView(ProductConfig.Inst.processdata.SolderCTPos[1], dataGridView1);
                    break;
            }
        }
        /// <summary>
        /// 四个平台读取点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_read_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToInt32())
            {
                case 1:
                    numericUpDown1.Value = (decimal)DeviceRsDef.Axis_X3.currPos;
                    numericUpDown2.Value = (decimal)DeviceRsDef.Axis_Y3.currPos;
                    numericUpDown4.Value = (decimal)DeviceRsDef.Axis_Z3.currPos;
                    numericUpDown3.Value = (decimal)DeviceRsDef.Axis_R3.currPos;
                    break;
                case 2:
                    numericUpDown8.Value = (decimal)DeviceRsDef.Axis_X3.currPos;
                    numericUpDown7.Value = (decimal)DeviceRsDef.Axis_Y3.currPos;
                    numericUpDown6.Value = (decimal)DeviceRsDef.Axis_Z3.currPos;
                    numericUpDown5.Value = (decimal)DeviceRsDef.Axis_R3.currPos;
                    break;
                case 3:
                    numericUpDown24.Value = (decimal)DeviceRsDef.Axis_X4.currPos;
                    numericUpDown23.Value = (decimal)DeviceRsDef.Axis_Y4.currPos;
                    numericUpDown22.Value = (decimal)DeviceRsDef.Axis_Z4.currPos;
                    numericUpDown21.Value = (decimal)DeviceRsDef.Axis_R4.currPos;
                    break;
                case 4:
                    numericUpDown19.Value = (decimal)DeviceRsDef.Axis_X4.currPos;
                    numericUpDown18.Value = (decimal)DeviceRsDef.Axis_Y4.currPos;
                    numericUpDown17.Value = (decimal)DeviceRsDef.Axis_Z4.currPos;
                    numericUpDown16.Value = (decimal)DeviceRsDef.Axis_R4.currPos;
                    break;
                case 5:
                    numericUpDown32.Value = (decimal)DeviceRsDef.Axis_X1.currPos;
                    numericUpDown31.Value = (decimal)DeviceRsDef.Axis_Y1.currPos;
                    numericUpDown30.Value = (decimal)DeviceRsDef.Axis_Z1.currPos;
                    numericUpDown29.Value = (decimal)DeviceRsDef.Axis_R1.currPos;
                    break;
                case 6:
                    numericUpDown28.Value = (decimal)DeviceRsDef.Axis_X1.currPos;
                    numericUpDown27.Value = (decimal)DeviceRsDef.Axis_Y1.currPos;
                    numericUpDown26.Value = (decimal)DeviceRsDef.Axis_Z1.currPos;
                    numericUpDown25.Value = (decimal)DeviceRsDef.Axis_R1.currPos;
                    break;
                case 7:
                    numericUpDown44.Value = (decimal)DeviceRsDef.Axis_X2.currPos;
                    numericUpDown43.Value = (decimal)DeviceRsDef.Axis_Y2.currPos;
                    numericUpDown42.Value = (decimal)DeviceRsDef.Axis_Z2.currPos;
                    numericUpDown41.Value = (decimal)DeviceRsDef.Axis_R2.currPos;
                    break;
                case 8:
                    numericUpDown40.Value = (decimal)DeviceRsDef.Axis_X2.currPos;
                    numericUpDown39.Value = (decimal)DeviceRsDef.Axis_Y2.currPos;
                    numericUpDown38.Value = (decimal)DeviceRsDef.Axis_Z2.currPos;
                    numericUpDown37.Value = (decimal)DeviceRsDef.Axis_R2.currPos;
                    break;

            }
        }
        //private XYZRMove LPolishXYZR = new XYZRMove("左打磨");
        //private XYZRMove RPolishXYZR = new XYZRMove("右打磨");
        //private XYZRMove LSolderXYZR = new XYZRMove("左上锡");
        //private XYZRMove RSolderXYZR = new XYZRMove("右上锡");
        /// <summary>
        /// 四个平台定位点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Locition_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToInt32())
            {
                case 1:
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown1.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown2.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown4.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown3.Value;
                    TaskManager.Default.FindTask("左打磨轴移动流程").Start();
                    break;
                case 2:
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown8.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown7.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown6.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown5.Value;
                    TaskManager.Default.FindTask("左打磨轴移动流程").Start();
                    break;
                case 3:
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown24.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown23.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown22.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown21.Value;
                    TaskManager.Default.FindTask("右打磨轴移动流程").Start();
                    break;
                case 4:
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown19.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown18.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown17.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown16.Value;
                    TaskManager.Default.FindTask("右打磨轴移动流程").Start();
                    break;
                case 5:
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown32.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown31.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown30.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown29.Value;
                    TaskManager.Default.FindTask("左焊锡轴移动流程").Start();
                    break;
                case 6:
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown28.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown27.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown26.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown25.Value;
                    TaskManager.Default.FindTask("左焊锡轴移动流程").Start();
                    break;
                case 7:
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown44.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown43.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown42.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown41.Value;
                    TaskManager.Default.FindTask("右焊锡轴移动流程").Start();
                    break;
                case 8:
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown40.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown39.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown38.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown37.Value;
                    TaskManager.Default.FindTask("右焊锡轴移动流程").Start();
                    break;

            }
        }
        /// <summary>
        /// 四个平台添加点/移除点/修改点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ProjectData.Instance.SaveData.processdata.LocatedPointPos = new PointF4();
            PointFB pos = new PointFB();
            Button btn = (Button)sender;
            switch (btn.Tag.ToInt32())
            {
                case 1:
                    SaveDataGridView(ProjectData.Instance.SaveData.processdata.PolishCTPos[0], dataGridView1);
                    pos.X = DeviceRsDef.Axis_X3.currPos;
                    pos.Y = DeviceRsDef.Axis_Y3.currPos;
                    pos.Ban = false;
                    ProjectData.Instance.SaveData.processdata.PolishCTPos[0].Add(pos);
                    LoadDGVData(ProjectData.Instance.SaveData.processdata.PolishCTPos[0], dataGridView1);
                    break;
                case 2:
                    if (MessageBox.Show("是否读取", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = DeviceRsDef.Axis_X3.currPos; 
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value = DeviceRsDef.Axis_Y3.currPos; 
                    }
                    break;
                case 3:
                    if (dataGridView1.RowCount > 0)
                    {
                        SaveDataGridView(ProjectData.Instance.SaveData.processdata.PolishCTPos[0], dataGridView1);
                        dataGridView1.AllowUserToDeleteRows = true;

                        for (int i = ProjectData.Instance.SaveData.processdata.PolishCTPos[0].Count - 1; i > -1; i--)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Selected == true)
                            {
                                ProjectData.Instance.SaveData.processdata.PolishCTPos[0].RemoveAt(i);
                            }
                            //rowSele = i;
                        }
                        LoadDGVData(ProjectData.Instance.SaveData.processdata.PolishCTPos[0], dataGridView1);
                        dataGridView1.AllowUserToDeleteRows = false;
                    }
                    break;
                case 4:
                    if (MessageBox.Show("是否定位", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        float x = Convert.ToSingle(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
                        float y = Convert.ToSingle(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
                        float z = ProjectData.Instance.SaveData.PolishData[0].SafeZ;
                        float r = 0;
                        //ProjectData.Instance.SaveData.processdata.LocatedPointPos = new PointF4();
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = x;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = y;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = z;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = r;
                        TaskManager.Default.FindTask("左打磨轴移动流程").Start();
                    }
                    break;


                case 5:
                    SaveDataGridView(ProjectData.Instance.SaveData.processdata.PolishCTPos[1], dataGridView1);
                    pos.X = DeviceRsDef.Axis_X4.currPos;
                    pos.Y = DeviceRsDef.Axis_Y4.currPos;
                    pos.Ban = false;
                    ProjectData.Instance.SaveData.processdata.PolishCTPos[1].Add(pos);
                    LoadDGVData(ProjectData.Instance.SaveData.processdata.PolishCTPos[1], dataGridView1);
                    break;
                case 6:
                    if (MessageBox.Show("是否读取", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = DeviceRsDef.Axis_X4.currPos;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value = DeviceRsDef.Axis_Y4.currPos;
                    }
                    break;
                case 7:
                    if (dataGridView1.RowCount > 0)
                    {
                        SaveDataGridView(ProjectData.Instance.SaveData.processdata.PolishCTPos[1], dataGridView1);
                        dataGridView1.AllowUserToDeleteRows = true;

                        for (int i = ProjectData.Instance.SaveData.processdata.PolishCTPos[1].Count - 1; i > -1; i--)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Selected == true)
                            {
                                ProjectData.Instance.SaveData.processdata.PolishCTPos[1].RemoveAt(i);
                            }
                            //rowSele = i;
                        }
                        LoadDGVData(ProjectData.Instance.SaveData.processdata.PolishCTPos[1], dataGridView1);
                        dataGridView1.AllowUserToDeleteRows = false;
                    }
                    break;
                case 8:
                    if (MessageBox.Show("是否定位", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        float x = Convert.ToSingle(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
                        float y = Convert.ToSingle(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
                        float z = ProjectData.Instance.SaveData.PolishData[1].SafeZ;
                        float r = 0;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = x;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = y;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = z;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = r;
                        TaskManager.Default.FindTask("右打磨轴移动流程").Start();
                    }
                    break;

                case 9:
                    SaveDataGridView(ProjectData.Instance.SaveData.processdata.SolderCTPos[0], dataGridView1);
                    pos.X = DeviceRsDef.Axis_X1.currPos;
                    pos.Y = DeviceRsDef.Axis_Y1.currPos;
                    pos.Ban = false;
                    ProjectData.Instance.SaveData.processdata.SolderCTPos[0].Add(pos);
                    LoadDGVData(ProjectData.Instance.SaveData.processdata.SolderCTPos[0], dataGridView1);
                    break;
                case 10:
                    if (MessageBox.Show("是否读取", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = DeviceRsDef.Axis_X1.currPos;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value = DeviceRsDef.Axis_Y1.currPos;
                    }
                    break;
                case 11:
                    if (dataGridView1.RowCount > 0)
                    {
                        SaveDataGridView(ProjectData.Instance.SaveData.processdata.SolderCTPos[0], dataGridView1);
                        dataGridView1.AllowUserToDeleteRows = true;

                        for (int i = ProjectData.Instance.SaveData.processdata.SolderCTPos[0].Count - 1; i > -1; i--)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Selected == true)
                            {
                                ProjectData.Instance.SaveData.processdata.SolderCTPos[0].RemoveAt(i);
                            }
                            //rowSele = i;
                        }
                        LoadDGVData(ProjectData.Instance.SaveData.processdata.SolderCTPos[0], dataGridView1);
                        dataGridView1.AllowUserToDeleteRows = false;
                    }
                    break;
                case 12:
                    if (MessageBox.Show("是否定位", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        float x = Convert.ToSingle(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
                        float y = Convert.ToSingle(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
                        float z = ProjectData.Instance.SaveData.SolderData[0].SafeZ;
                        float r = 0;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = x;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = y;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = z;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = r;
                        TaskManager.Default.FindTask("左焊锡轴移动流程").Start();
                    }
                    break;




                case 13:
                    SaveDataGridView(ProjectData.Instance.SaveData.processdata.SolderCTPos[1], dataGridView1);
                    pos.X = DeviceRsDef.Axis_X2.currPos;
                    pos.Y = DeviceRsDef.Axis_Y2.currPos;
                    pos.Ban = false;
                    ProjectData.Instance.SaveData.processdata.SolderCTPos[1].Add(pos);
                    LoadDGVData(ProjectData.Instance.SaveData.processdata.SolderCTPos[1], dataGridView1);
                    break;
                case 14:
                    if (MessageBox.Show("是否读取", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value = DeviceRsDef.Axis_X2.currPos;
                        dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value = DeviceRsDef.Axis_Y2.currPos;
                    }
                    break;
                case 15:
                    if (dataGridView1.RowCount > 0)
                    {
                        SaveDataGridView(ProjectData.Instance.SaveData.processdata.SolderCTPos[1], dataGridView1);
                        dataGridView1.AllowUserToDeleteRows = true;

                        for (int i = ProjectData.Instance.SaveData.processdata.SolderCTPos[1].Count - 1; i > -1; i--)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Selected == true)
                            {
                                ProjectData.Instance.SaveData.processdata.SolderCTPos[1].RemoveAt(i);
                            }
                            //rowSele = i;
                        }
                        LoadDGVData(ProjectData.Instance.SaveData.processdata.SolderCTPos[1], dataGridView1);
                        dataGridView1.AllowUserToDeleteRows = false;
                    }
                    break;
                case 16:
                    if (MessageBox.Show("是否定位", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        float x = Convert.ToSingle(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value);
                        float y = Convert.ToSingle(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[2].Value);
                        float z = ProjectData.Instance.SaveData.SolderData[1].SafeZ;
                        float r = 0;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = x;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = y;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = z;
                        ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = r;
                        TaskManager.Default.FindTask("右焊锡轴移动流程").Start();
                    }
                    break;
            }
        }
        /// <summary>
        /// 表格双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = sender as DataGridView;
            if (e.RowIndex == -1 && e.ColumnIndex == 3 && data.RowCount>0)
            {
                if (Convert.ToString( data.Rows[0].Cells[3].Value) == "禁用")
                {
                    for (int i = 0; i < data.RowCount; i++)
                    {
                        data.Rows[i].Cells[3].Value = "启用";
                    }
                }
                else
                {
                    for (int i = 0; i < data.RowCount; i++)
                    {
                        data.Rows[i].Cells[3].Value = "禁用";
                    }
                }
            }
        }
        /// <summary>
        /// 表格单击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView data = sender as DataGridView;

            if (e.RowIndex >= 0)
            {
                switch (e.ColumnIndex)
                {
                    case 3:

                        if (Convert.ToString(data.Rows[e.RowIndex].Cells[3].Value) == "禁用")
                        {
                            data.Rows[e.RowIndex].Cells[3].Value = "启用";
                        }
                        else
                        {
                            data.Rows[e.RowIndex].Cells[3].Value = "禁用";
                        }
                        break;
                }
                data.Rows[e.RowIndex].Selected = true;
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                ProjectData.Instance.SaveData.SolderPlatform[0].UseR = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                ProjectData.Instance.SaveData.SolderPlatform[1].UseR = true;
            }
        }
    }
}
