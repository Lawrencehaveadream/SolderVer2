using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CCWin.SkinControl;
using Device;
using HZZH.Logic.Commmon;

namespace HZZH.UI.DerivedControl
{
    public partial class XYZ_Jog : Form
    {
        public AxisClass[] axisID;
        public XYZ_Jog()
        {
            InitializeComponent();
            comboBox4.SelectedIndex = 0;

            axisID = new AxisClass[4];
            axisID[0] = DeviceRsDef.Axis_X1;
            axisID[1] = DeviceRsDef.Axis_Y1;
            axisID[2] = DeviceRsDef.Axis_Z1;
            axisID[3] = DeviceRsDef.Axis_R1;

            //axisID[4] = DeviceRsDef.Axis_X2;
            //axisID[5] = DeviceRsDef.Axis_Y2;
            //axisID[6] = DeviceRsDef.Axis_Z2;
            //axisID[7] = DeviceRsDef.Axis_R2;

            //axisID[8] = DeviceRsDef.Axis_X3;
            //axisID[9] = DeviceRsDef.Axis_Y3;
            //axisID[10] = DeviceRsDef.Axis_Z3;
            //axisID[11] = DeviceRsDef.Axis_R3;

            //axisID[12] = DeviceRsDef.Axis_X4;
            //axisID[13] = DeviceRsDef.Axis_Y4;
            //axisID[14] = DeviceRsDef.Axis_Z4;
            //axisID[15] = DeviceRsDef.Axis_R4;
            ContorlBling();
            Tagbanding(1);
            timer1.Interval = 200;
            timer1.Enabled = true;
            
        }
        public void Tagbanding(int s)
        {
            List<ComboBoxIndex> box = new List<ComboBoxIndex>();
            switch (s)
            { 
                case 1:
                    axisID[0] = DeviceRsDef.Axis_X3;
                    axisID[1] = DeviceRsDef.Axis_Y3;
                    axisID[2] = DeviceRsDef.Axis_Z3;
                    axisID[3] = DeviceRsDef.Axis_R3;
                    box.Add(new ComboBoxIndex() { index = 0, name = "X3轴" });
                    box.Add(new ComboBoxIndex() { index = 1, name = "Y3轴" });
                    box.Add(new ComboBoxIndex() { index = 2, name = "Z3轴" });
                    box.Add(new ComboBoxIndex() { index = 3, name = "R3轴" });
                    break;
                case 2:
                    axisID[0] = DeviceRsDef.Axis_X4;
                    axisID[1] = DeviceRsDef.Axis_Y4;
                    axisID[2] = DeviceRsDef.Axis_Z4;
                    axisID[3] = DeviceRsDef.Axis_R4;
                    box.Add(new ComboBoxIndex() { index = 0, name = "X4轴" });
                    box.Add(new ComboBoxIndex() { index = 1, name = "Y4轴" });
                    box.Add(new ComboBoxIndex() { index = 2, name = "Z4轴" });
                    box.Add(new ComboBoxIndex() { index = 3, name = "R4轴" });
                    
                    break;
                case 3:
                    axisID[0] = DeviceRsDef.Axis_X1;
                    axisID[1] = DeviceRsDef.Axis_Y1;
                    axisID[2] = DeviceRsDef.Axis_Z1;
                    axisID[3] = DeviceRsDef.Axis_R1;
                    box.Add(new ComboBoxIndex() { index = 0, name = "X1轴" });
                    box.Add(new ComboBoxIndex() { index = 1, name = "Y1轴" });
                    box.Add(new ComboBoxIndex() { index = 2, name = "Z1轴" });
                    box.Add(new ComboBoxIndex() { index = 3, name = "R1轴" });
                    break;
                case 4:
                    axisID[0] = DeviceRsDef.Axis_X2;
                    axisID[1] = DeviceRsDef.Axis_Y2;
                    axisID[2] = DeviceRsDef.Axis_Z2;
                    axisID[3] = DeviceRsDef.Axis_R2;
                    box.Add(new ComboBoxIndex() { index = 0, name = "X2轴" });
                    box.Add(new ComboBoxIndex() { index = 1, name = "Y2轴" });
                    box.Add(new ComboBoxIndex() { index = 2, name = "Z2轴" });
                    box.Add(new ComboBoxIndex() { index = 3, name = "R2轴" });
                    box.Add(new ComboBoxIndex() { index = 4, name = "S2轴" });
                    break;
            }
            comboBox4.DataSource = box;
            comboBox4.ValueMember = "index";
            comboBox4.DisplayMember = "name";
            comboBox4.SelectedIndex = 0;
        }
        public void ContorlBling()
        {
            ConfigJog(Direction.Pos, button9);
            ConfigJog(Direction.Neg, button10);

            ConfigJog(Direction.Neg, button8);
            ConfigJog(Direction.Pos, button7);

            ConfigJog(Direction.Pos, button12);
            ConfigJog(Direction.Neg, button11);

            ConfigJog(Direction.Pos, R_Pos);
            ConfigJog(Direction.Neg, R_Neg);

            ConfigJog(Direction.Hom, Bt_home);
        }

        private void numericUpDown31_ValueChanged(object sender, EventArgs e)
        {
            _targetPos = (float)numericUpDown31.Value;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                _mode = 1;
            }
            else
            {
                _mode = 0;
            }
        }
        /// <summary>
        /// 移动距离
        /// </summary>
        public float _targetPos = 1;
        /// <summary>
        /// 移动速度
        /// </summary>
        public float _speed = 20;

        public int _mode = 1;
        private void ConfigJog(Direction type, Button _b)
        {
            _b.MouseDown -= btn_JogAxisNeg_MouseDown;
            _b.MouseDown -= btn_JogAxisPos_MouseDown;
            _b.MouseUp -= btn_JogAxis_MouseUp;
            _b.Click -= btn_Home_Click;

            switch (type)
            {
                case Direction.Pos:
                    _b.MouseDown += btn_JogAxisPos_MouseDown;
                    _b.MouseUp += btn_JogAxis_MouseUp;
                    break;
                case Direction.Neg:
                    _b.MouseDown += btn_JogAxisNeg_MouseDown;
                    _b.MouseUp += btn_JogAxis_MouseUp;
                    break;
                case Direction.Hom:
                    _b.Click += btn_Home_Click;
                    break;
            }
        }

        private void btn_JogAxisPos_MouseDown(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            int axis = Convert.ToUInt16(_btn.Tag);
            if (e.Button == MouseButtons.Left)
            {
                _speed = 50;
                if (_mode == 0)
                {
                    axisID[axis].MC_MoveSpd(_speed, _targetPos);
                }
                else
                {
                    axisID[axis].MC_MoveRel(_speed, _targetPos);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                _speed = 10;
                if (_mode == 0)
                {
                    axisID[axis].MC_MoveSpd(_speed, _targetPos);
                }
                else
                {
                    axisID[axis].MC_MoveRel(_speed, _targetPos);
                }
            }
        }

        private void btn_JogAxis_MouseUp(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            int axis = Convert.ToUInt16(_btn.Tag);
            if (_mode == 0)
            {
                axisID[axis].MC_StopDec();
            }
        }
        private void btn_JogAxisNeg_MouseDown(object sender, MouseEventArgs e)
        {
            Button _btn = sender as Button;
            int axis = Convert.ToUInt16(_btn.Tag);
            if (e.Button == MouseButtons.Left)
            {
                _speed = 50;
                if (_mode == 0)
                {
                    axisID[axis].MC_MoveSpd(_speed, -_targetPos);
                }
                else
                {
                    axisID[axis].MC_MoveRel(_speed, -_targetPos);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                _speed = 10;
                if (_mode == 0)
                {
                    axisID[axis].MC_MoveSpd(_speed, -_targetPos);
                }
                else
                {
                    axisID[axis].MC_MoveRel(_speed, -_targetPos);
                }
            }
        }

        private void btn_Home_Click(object sender, EventArgs e)
        {
            ushort axis = (ushort)comboBox4.SelectedIndex;
            if (MessageBox.Show("确定要执行此轴回零...", (string)comboBox4.Items[axis].ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                axisID[axis].MC_Home();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = "X:" + axisID[0].currPos.ToString("0.00");
            label2.Text = "Y:" + axisID[1].currPos.ToString("0.00");
            label3.Text = "Z:" + axisID[2].currPos.ToString("0.00");
            label4.Text = "R:" + axisID[3].currPos.ToString("0.00");
        }
        private void XYZ_Jog_Load(object sender, EventArgs e)
        {

        }
    }

    public enum Direction : int
    {
        Pos,
        Neg,
        Hom
    }
    public class ComboBoxIndex
    {
        public int index { get; set; }
        public string name { get; set; }
    }
}
