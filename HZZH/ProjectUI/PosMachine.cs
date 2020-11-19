using CommonRs;
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

namespace HZZH.ProjectUI
{
    public partial class PosMachine : Form
    {
        private XYZ_Jog ljog;
        private XYZ_Jog rjog;
        public PosMachine()
        {
            InitializeComponent();
            Initial();
        }
        public void Initial()
        {
            databanding();
            ljog = new XYZ_Jog();
            rjog = new XYZ_Jog();
            ljog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            ljog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            ljog.Size = this.panel3.Size;
            ljog.Parent = this.panel3;//指定子窗体显示的容器
            ljog.Dock = DockStyle.Fill;
            ljog.Show();
            ljog.Activate();
            ljog.Tagbanding(1);

            rjog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            rjog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            rjog.Size = this.panel4.Size;
            rjog.Parent = this.panel4;//指定子窗体显示的容器
            rjog.Dock = DockStyle.Fill;
            rjog.Show();
            rjog.Activate();
            rjog.Tagbanding(2);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                ljog.Tagbanding(1);
            }
            else
            {
                ljog.Tagbanding(3);
            }
        }
        public void databanding()
        {
            try
            {
                Functions.SetBinding(numericUpDown46,"Value",ProjectData.Instance.SaveData.PolishPlatform[0].machinePolishcarmera, "X");
                Functions.SetBinding(numericUpDown45,"Value",ProjectData.Instance.SaveData.PolishPlatform[0].machinePolishcarmera, "Y");

                Functions.SetBinding(numericUpDown48, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].machinePolish, "X");
                Functions.SetBinding(numericUpDown47, "Value", ProjectData.Instance.SaveData.PolishPlatform[0].machinePolish, "Y");

                Functions.SetBinding(numericUpDown11, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].machineSoldercamera, "X");
                Functions.SetBinding(numericUpDown9, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].machineSoldercamera, "Y");

                Functions.SetBinding(numericUpDown8, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].machineSolder, "X");
                Functions.SetBinding(numericUpDown10, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].machineSolder, "Y");

                Functions.SetBinding(numericUpDown12, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].machinePolishcarmera, "X");
                Functions.SetBinding(numericUpDown6, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].machinePolishcarmera, "Y");

                Functions.SetBinding(numericUpDown5, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].machinePolish, "X");
                Functions.SetBinding(numericUpDown7, "Value", ProjectData.Instance.SaveData.PolishPlatform[1].machinePolish, "Y");

                Functions.SetBinding(numericUpDown4, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].machineSoldercamera, "X");
                Functions.SetBinding(numericUpDown2, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].machineSoldercamera, "Y");

                Functions.SetBinding(numericUpDown1, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].machineSolder, "X");
                Functions.SetBinding(numericUpDown3, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].machineSolder, "Y");

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            switch (btn.Tag.ToString())
            {
                case "1":
                    numericUpDown46.Value = (decimal)DeviceRsDef.Axis_X3.currPos;
                    numericUpDown45.Value = (decimal)DeviceRsDef.Axis_Y3.currPos;

                    break;
                case "2":
                    numericUpDown11.Value = (decimal)DeviceRsDef.Axis_X1.currPos;
                    numericUpDown9.Value = (decimal)DeviceRsDef.Axis_Y1.currPos;
                    break;
                case "3":
                    numericUpDown48.Value = (decimal)DeviceRsDef.Axis_X3.currPos;
                    numericUpDown47.Value = (decimal)DeviceRsDef.Axis_Y3.currPos;
                    break;
                case "4":
                    numericUpDown8.Value = (decimal)DeviceRsDef.Axis_X1.currPos;
                    numericUpDown10.Value = (decimal)DeviceRsDef.Axis_Y1.currPos;
                    break;
                case "5":
                    numericUpDown12.Value = (decimal)DeviceRsDef.Axis_X4.currPos;
                    numericUpDown6.Value = (decimal)DeviceRsDef.Axis_Y4.currPos;
                    break;
                case "6":
                    numericUpDown4.Value = (decimal)DeviceRsDef.Axis_X2.currPos;
                    numericUpDown2.Value = (decimal)DeviceRsDef.Axis_Y2.currPos;
                    break;
                case "7":
                    numericUpDown5.Value = (decimal)DeviceRsDef.Axis_X4.currPos;
                    numericUpDown7.Value = (decimal)DeviceRsDef.Axis_Y4.currPos;
                    break;
                case "8":
                    numericUpDown1.Value = (decimal)DeviceRsDef.Axis_X2.currPos;
                    numericUpDown3.Value = (decimal)DeviceRsDef.Axis_Y2.currPos;
                    break;
            }
        }
        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == 0)
            {
                rjog.Tagbanding(2);
            }
            else
            {
                rjog.Tagbanding(4);
            }
        }
        
    }

}
