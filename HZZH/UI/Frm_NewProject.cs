using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public partial class Frm_NewProject : Form
    {
        public Frm_NewProject()
        {
            InitializeComponent();

            this.Text = "新建项目";

            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.StartPosition = FormStartPosition.CenterParent;
        }

     
        private void Frm_NewProject_Load(object sender, EventArgs e)
        {

        }

      

        public bool bln_IsOk = false;
        public string str_proName = null;

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (txt_proName.Text != "")
            {
                bln_IsOk = true;
                str_proName = txt_proName.Text;
                this.Close();
            }
            else
            {
                bln_IsOk = false;
                MessageBox.Show("输入不能为空");
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            bln_IsOk = false;
            this.Close();
        }
    }
}
