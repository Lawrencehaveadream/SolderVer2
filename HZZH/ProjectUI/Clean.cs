using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonRs;
using HzControl.Logic;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using HZZH.Logic.LogicMission;
using HZZH.UI.DerivedControl;

namespace HZZH.ProjectUI
{
    public partial class Clean : Form
    {
        private XYZ_Jog pljog;
        private XYZ_Jog sljog;
        private XYZ_Jog prjog;
        private XYZ_Jog srjog;
        public Clean()
        {
            InitializeComponent();
            Initial();
            databanding();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initial()
        {
            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            pljog = new XYZ_Jog();
            pljog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            pljog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            pljog.Size = this.panel4.Size;
            pljog.Parent = this.panel4;//指定子窗体显示的容器
            pljog.Dock = DockStyle.Fill;
            pljog.Show();
            pljog.Activate();
            pljog.Tagbanding(1);

            sljog = new XYZ_Jog();
            sljog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            sljog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            sljog.Size = this.panel2.Size;
            sljog.Parent = this.panel2;//指定子窗体显示的容器
            sljog.Dock = DockStyle.Fill;
            sljog.Show();
            sljog.Activate();
            sljog.Tagbanding(3);

            prjog = new XYZ_Jog();
            prjog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            prjog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            prjog.Size = this.panel7.Size;
            prjog.Parent = this.panel7;//指定子窗体显示的容器
            prjog.Dock = DockStyle.Fill;
            prjog.Show();
            prjog.Activate();
            prjog.Tagbanding(2);

            srjog = new XYZ_Jog();
            srjog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            srjog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            srjog.Size = this.panel6.Size;
            srjog.Parent = this.panel6;//指定子窗体显示的容器
            srjog.Dock = DockStyle.Fill;
            srjog.Show();
            srjog.Activate();
            srjog.Tagbanding(4);
        }
        /// <summary>
        /// 数据绑定
        /// </summary>
        public void databanding()
        {
            try
            {
                //左上锡
                Functions.SetBinding(numericUpDown1, "Value", ProjectData.Instance.SaveData.SolderCleanData[0].CleanPos, "X");
                Functions.SetBinding(numericUpDown2, "Value", ProjectData.Instance.SaveData.SolderCleanData[0].CleanPos, "Y");
                Functions.SetBinding(numericUpDown3, "Value", ProjectData.Instance.SaveData.SolderCleanData[0].CleanPos, "Z");
                Functions.SetBinding(numericUpDown4, "Value", ProjectData.Instance.SaveData.SolderCleanData[0].CleanPos, "R");

                Functions.SetBinding(numericUpDown5, "Value", ProjectData.Instance.SaveData.SolderCleanData[0], "PosLength");
                Functions.SetBinding(numericUpDown6, "Value", ProjectData.Instance.SaveData.SolderCleanData[0], "PosSpeed");
                Functions.SetBinding(numericUpDown7, "Value", ProjectData.Instance.SaveData.SolderCleanData[0], "NegLength");
                Functions.SetBinding(numericUpDown8, "Value", ProjectData.Instance.SaveData.SolderCleanData[0], "NegSpeed");
                Functions.SetBinding(numericUpDown31, "Value", ProjectData.Instance.SaveData.SolderCleanData[0], "CleanTime");
                Functions.SetBinding(numericUpDown25, "Value", ProjectData.Instance.SaveData.SolderPlatform[0], "PerTimesClean");
                //左打磨
                Functions.SetBinding(numericUpDown20, "Value", ProjectData.Instance.SaveData.PolishCleanData[0].CleanPos, "X");
                Functions.SetBinding(numericUpDown19, "Value", ProjectData.Instance.SaveData.PolishCleanData[0].CleanPos, "Y");
                Functions.SetBinding(numericUpDown18, "Value", ProjectData.Instance.SaveData.PolishCleanData[0].CleanPos, "Z");
                Functions.SetBinding(numericUpDown17, "Value", ProjectData.Instance.SaveData.PolishCleanData[0].CleanPos, "R");

                Functions.SetBinding(numericUpDown30, "Value", ProjectData.Instance.SaveData.PolishCleanData[0], "CleanTimes");
                Functions.SetBinding(numericUpDown29, "Value", ProjectData.Instance.SaveData.PolishCleanData[0], "range");
                Functions.SetBinding(numericUpDown28, "Value", ProjectData.Instance.SaveData.PolishCleanData[0], "interval");
                Functions.SetBinding(numericUpDown33, "Value", ProjectData.Instance.SaveData.PolishCleanData[0], "CleanSpeed");
                Functions.SetBinding(numericUpDown27, "Value", ProjectData.Instance.SaveData.PolishPlatform[0], "PerTtimesClean");

                //右上锡
                Functions.SetBinding(numericUpDown44, "Value", ProjectData.Instance.SaveData.SolderCleanData[1].CleanPos, "X");
                Functions.SetBinding(numericUpDown43, "Value", ProjectData.Instance.SaveData.SolderCleanData[1].CleanPos, "Y");
                Functions.SetBinding(numericUpDown42, "Value", ProjectData.Instance.SaveData.SolderCleanData[1].CleanPos, "Z");
                Functions.SetBinding(numericUpDown41, "Value", ProjectData.Instance.SaveData.SolderCleanData[1].CleanPos, "R");

                Functions.SetBinding(numericUpDown46, "Value", ProjectData.Instance.SaveData.SolderCleanData[1], "PosLength");
                Functions.SetBinding(numericUpDown47, "Value", ProjectData.Instance.SaveData.SolderCleanData[1], "PosSpeed");
                Functions.SetBinding(numericUpDown48, "Value", ProjectData.Instance.SaveData.SolderCleanData[1], "NegLength");
                Functions.SetBinding(numericUpDown45, "Value", ProjectData.Instance.SaveData.SolderCleanData[1], "NegSpeed");
                Functions.SetBinding(numericUpDown39, "Value", ProjectData.Instance.SaveData.SolderCleanData[1], "CleanTime");
                Functions.SetBinding(numericUpDown40, "Value", ProjectData.Instance.SaveData.SolderPlatform[1], "PerTimesClean");
                //右打磨
                Functions.SetBinding(numericUpDown76, "Value", ProjectData.Instance.SaveData.PolishCleanData[1].CleanPos, "X");
                Functions.SetBinding(numericUpDown75, "Value", ProjectData.Instance.SaveData.PolishCleanData[1].CleanPos, "Y");
                Functions.SetBinding(numericUpDown74, "Value", ProjectData.Instance.SaveData.PolishCleanData[1].CleanPos, "Z");
                Functions.SetBinding(numericUpDown73, "Value", ProjectData.Instance.SaveData.PolishCleanData[1].CleanPos, "R");

                Functions.SetBinding(numericUpDown71, "Value", ProjectData.Instance.SaveData.PolishCleanData[1], "CleanTimes");
                Functions.SetBinding(numericUpDown70, "Value", ProjectData.Instance.SaveData.PolishCleanData[1], "range");
                Functions.SetBinding(numericUpDown72, "Value", ProjectData.Instance.SaveData.PolishCleanData[1], "interval");
                Functions.SetBinding(numericUpDown68, "Value", ProjectData.Instance.SaveData.PolishCleanData[1], "CleanSpeed");
                Functions.SetBinding(numericUpDown69, "Value", ProjectData.Instance.SaveData.PolishPlatform[1], "PerTtimesClean");
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// 读取点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "1":
                    numericUpDown1.Value = (decimal)DeviceRsDef.Axis_X1.currPos;
                    numericUpDown2.Value = (decimal)DeviceRsDef.Axis_Y1.currPos;
                    numericUpDown3.Value = (decimal)DeviceRsDef.Axis_Z1.currPos;
                    numericUpDown4.Value = (decimal)DeviceRsDef.Axis_R1.currPos;
                    break;
                case "2":
                    numericUpDown20.Value = (decimal)DeviceRsDef.Axis_X3.currPos;
                    numericUpDown19.Value = (decimal)DeviceRsDef.Axis_Y3.currPos;
                    numericUpDown18.Value = (decimal)DeviceRsDef.Axis_Z3.currPos;
                    numericUpDown17.Value = (decimal)DeviceRsDef.Axis_R3.currPos;
                    break;
                case "3":
                    numericUpDown76.Value = (decimal)DeviceRsDef.Axis_X4.currPos;
                    numericUpDown75.Value = (decimal)DeviceRsDef.Axis_Y4.currPos;
                    numericUpDown74.Value = (decimal)DeviceRsDef.Axis_Z4.currPos;
                    numericUpDown73.Value = (decimal)DeviceRsDef.Axis_R4.currPos;
                    break;
                case "4":
                    numericUpDown44.Value = (decimal)DeviceRsDef.Axis_X2.currPos;
                    numericUpDown43.Value = (decimal)DeviceRsDef.Axis_Y2.currPos;
                    numericUpDown42.Value = (decimal)DeviceRsDef.Axis_Z2.currPos;
                    numericUpDown41.Value = (decimal)DeviceRsDef.Axis_R2.currPos;
                    break;
            }
        }
        /// <summary>
        /// 定位点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "1":
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown1.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown2.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown3.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown4.Value;
                    TaskManager.Default.FindTask("左焊锡轴移动流程").Start();
                    
                    break;
                case "2":
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown20.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown19.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown18.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown17.Value;
                    TaskManager.Default.FindTask("左打磨轴移动流程").Start();
                    break;
                case "3":
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown76.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown75.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown74.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown73.Value;
                    TaskManager.Default.FindTask("右打磨轴移动流程").Start();
                    break;
                case "4":
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.X = (float)numericUpDown44.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Y = (float)numericUpDown43.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.Z = (float)numericUpDown42.Value;
                    ProjectData.Instance.SaveData.processdata.LocatedPointPos.R = (float)numericUpDown41.Value;
                    TaskManager.Default.FindTask("右焊锡轴移动流程").Start();
                    break;
            }

        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                ProjectData.Instance.SaveData.PolishCleanData[0].Mode = 1;
            }
            else
            {
                ProjectData.Instance.SaveData.PolishCleanData[0].Mode = 2;
            }
        }

        private void comboBox4_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                ProjectData.Instance.SaveData.PolishCleanData[1].Mode = 1;
            }
            else
            {
                ProjectData.Instance.SaveData.PolishCleanData[1].Mode = 2;
            }
        }
    }
}
