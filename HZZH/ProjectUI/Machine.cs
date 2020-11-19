using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CommonRs;
using Device;
using HZZH.Logic.Commmon;
using HZZH.Logic.Data;
using HZZH.UI.DerivedControl;
using UI;

namespace HZZH.UI
{
    public partial class Frm_Machine : Form
    {
        private XYZ_Jog jog;
        private XYZ_Jog jogr;
        public Frm_Machine()
        {
            InitializeComponent();
            Initial();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void  Initial()
        {

            Binding();
            jog = new XYZ_Jog();
            jog.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            jog.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            jog.Size = this.panel7.Size;
            jog.Parent = this.panel7;//指定子窗体显示的容器
            jog.Dock = DockStyle.Fill;
            jog.Show();
            jog.Activate();
            jog.Tagbanding(4);


            jogr = new XYZ_Jog();
            jogr.TopLevel = false; //将子窗体设置成非最高层，非顶级控件
            jogr.FormBorderStyle = FormBorderStyle.None;//去掉窗体边框
            jogr.Size = this.panel4.Size;
            jogr.Parent = this.panel4;//指定子窗体显示的容器
            jogr.Dock = DockStyle.Fill;
            jogr.Show();
            jogr.Activate();
            jogr.Tagbanding(3);
        }
        int xID = 0;
        int yID = 1;
        int zID = 2;
        int rID = 3;
        float SafeZ = 0;
        public enum UsingPlatformSelect
        {
            Left,
            Right
        };
        /// <summary>
        /// 左侧0
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ZeroPostion.X = DeviceRsDef.Axis_X1.currPos;
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ZeroPostion.Y = DeviceRsDef.Axis_Y1.currPos;
            numericUpDown7.DataBindings["Value"].ReadValue();
            numericUpDown6.DataBindings["Value"].ReadValue();
        }
        /// <summary>
        /// 左侧180
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ReversePostion.X = DeviceRsDef.Axis_X1.currPos;
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ReversePostion.Y = DeviceRsDef.Axis_Y1.currPos;
            numericUpDown5.DataBindings["Value"].ReadValue();
            numericUpDown4.DataBindings["Value"].ReadValue();
        }
        /// <summary>
        /// 左侧XYR数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            float x = (ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ZeroPostion.X + ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ReversePostion.X) / 2.0f;
            float y = (ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ZeroPostion.Y + ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ReversePostion.Y) / 2.0f;
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePostion.X = x;
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePostion.Y = y;

            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.Radius = (float)Math.Sqrt(Math.Pow((x - ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ZeroPostion.X), 2) + Math.Pow((y - ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ZeroPostion.Y), 2));

            double ang = Math.Atan(y / x);
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePostionStartAngle = (float)(ang * 180 / Math.PI);

            numericUpDown3.DataBindings["Value"].ReadValue();
            numericUpDown2.DataBindings["Value"].ReadValue();
            numericUpDown1.DataBindings["Value"].ReadValue();


        }

        public void Binding()
        {
            try
            {
                Functions.SetBinding(numericUpDown7, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ZeroPostion, "X");
                Functions.SetBinding(numericUpDown6, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ZeroPostion, "Y");

                Functions.SetBinding(numericUpDown5, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ReversePostion, "X");
                Functions.SetBinding(numericUpDown4, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.ReversePostion, "Y");

                Functions.SetBinding(numericUpDown3, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePostion, "X");
                Functions.SetBinding(numericUpDown2, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePostion, "Y");

                Functions.SetBinding(numericUpDown1, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine, "Radius");


                Functions.SetBinding(numericUpDown17, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.CameraRotatePostion, "X");
                Functions.SetBinding(numericUpDown18, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.CameraRotatePostion, "Y");

                Functions.SetBinding(numericUpDown16, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePstionCameraSize, "X");
                Functions.SetBinding(numericUpDown15, "Value", ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePstionCameraSize, "Y");

                //右
                Functions.SetBinding(numericUpDown26, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ZeroPostion, "X");
                Functions.SetBinding(numericUpDown25, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ZeroPostion, "Y");

                Functions.SetBinding(numericUpDown24, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ReversePostion, "X");
                Functions.SetBinding(numericUpDown23, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ReversePostion, "Y");

                Functions.SetBinding(numericUpDown20, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePostion, "X");
                Functions.SetBinding(numericUpDown19, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePostion, "Y");

                Functions.SetBinding(numericUpDown13, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine, "Radius");


                Functions.SetBinding(numericUpDown21, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.CameraRotatePostion, "X");
                Functions.SetBinding(numericUpDown22, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.CameraRotatePostion, "Y");

                Functions.SetBinding(numericUpDown14, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePstionCameraSize, "X");
                Functions.SetBinding(numericUpDown12, "Value", ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePstionCameraSize, "Y");

            }
            catch (Exception)
            {

                throw;
            }
            
        }

        

        
        /// <summary>
        /// 左侧相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.CameraRotatePostion.X = DeviceRsDef.Axis_X1.currPos;
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.CameraRotatePostion.Y = DeviceRsDef.Axis_Y1.currPos;
            numericUpDown17.DataBindings["Value"].ReadValue();
            numericUpDown18.DataBindings["Value"].ReadValue();
        }
        /// <summary>
        /// 获取相机到原点中心
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            float X = ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.CameraRotatePostion.X - ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePostion.X;
            float Y = ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.CameraRotatePostion.Y - ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePostion.Y;

            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePstionCameraSize.X = X;
            ProjectData.Instance.SaveData.SolderPlatform[0].teachingMechine.RotatePstionCameraSize.Y = Y;
            numericUpDown16.DataBindings["Value"].ReadValue();
            numericUpDown15.DataBindings["Value"].ReadValue();
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ZeroPostion.X = DeviceRsDef.Axis_X2.currPos;
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ZeroPostion.Y = DeviceRsDef.Axis_Y2.currPos;
            numericUpDown26.DataBindings["Value"].ReadValue();
            numericUpDown25.DataBindings["Value"].ReadValue();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ReversePostion.X = DeviceRsDef.Axis_X2.currPos;
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ReversePostion.Y = DeviceRsDef.Axis_Y2.currPos;
            numericUpDown24.DataBindings["Value"].ReadValue();
            numericUpDown23.DataBindings["Value"].ReadValue();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            float x = (ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ZeroPostion.X + ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ReversePostion.X) / 2.0f;
            float y = (ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ZeroPostion.Y + ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ReversePostion.Y) / 2.0f;
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePostion.X = x;
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePostion.Y = y;

            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.Radius = (float)Math.Sqrt(Math.Pow((x - ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ZeroPostion.X), 2) + Math.Pow((y - ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.ZeroPostion.Y), 2));

            double ang = Math.Atan(y / x);
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePostionStartAngle = (float)(ang * 180 / Math.PI);

            numericUpDown20.DataBindings["Value"].ReadValue();
            numericUpDown19.DataBindings["Value"].ReadValue();
            numericUpDown13.DataBindings["Value"].ReadValue();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.CameraRotatePostion.X = DeviceRsDef.Axis_X2.currPos;
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.CameraRotatePostion.Y = DeviceRsDef.Axis_Y2.currPos;
            numericUpDown21.DataBindings["Value"].ReadValue();
            numericUpDown22.DataBindings["Value"].ReadValue();
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            float X = ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.CameraRotatePostion.X - ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePostion.X;
            float Y = ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.CameraRotatePostion.Y - ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePostion.Y;

            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePstionCameraSize.X = X;
            ProjectData.Instance.SaveData.SolderPlatform[1].teachingMechine.RotatePstionCameraSize.Y = Y;
            numericUpDown14.DataBindings["Value"].ReadValue();
            numericUpDown12.DataBindings["Value"].ReadValue();
        }
    }
}
