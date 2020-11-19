namespace HZZH.UI.DerivedControl
{
    partial class XYZ_Jog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(XYZ_Jog));
            this.numericUpDown31 = new System.Windows.Forms.NumericUpDown();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.Bt_home = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.R_Neg = new System.Windows.Forms.Button();
            this.R_Pos = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown31)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown31
            // 
            this.numericUpDown31.DecimalPlaces = 3;
            this.numericUpDown31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numericUpDown31.Location = new System.Drawing.Point(141, 30);
            this.numericUpDown31.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown31.Name = "numericUpDown31";
            this.numericUpDown31.Size = new System.Drawing.Size(79, 27);
            this.numericUpDown31.TabIndex = 261;
            this.numericUpDown31.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown31.ValueChanged += new System.EventHandler(this.numericUpDown31_ValueChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.Checked = true;
            this.checkBox6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox6.Location = new System.Drawing.Point(26, 28);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(74, 31);
            this.checkBox6.TabIndex = 259;
            this.checkBox6.Text = "点动";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // comboBox4
            // 
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "X轴",
            "Y轴",
            "Z1",
            "Z2",
            "R1",
            "R2"});
            this.comboBox4.Location = new System.Drawing.Point(267, 26);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(71, 35);
            this.comboBox4.TabIndex = 255;
            // 
            // Bt_home
            // 
            this.Bt_home.BackColor = System.Drawing.SystemColors.Control;
            this.Bt_home.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.Bt_home.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Bt_home.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Bt_home.Location = new System.Drawing.Point(385, 27);
            this.Bt_home.Name = "Bt_home";
            this.Bt_home.Size = new System.Drawing.Size(61, 35);
            this.Bt_home.TabIndex = 251;
            this.Bt_home.Tag = "0";
            this.Bt_home.Text = "回零";
            this.Bt_home.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // R_Neg
            // 
            this.R_Neg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Neg.BackgroundImage")));
            this.R_Neg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.R_Neg.FlatAppearance.BorderSize = 0;
            this.R_Neg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.R_Neg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.R_Neg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.R_Neg.Location = new System.Drawing.Point(293, 204);
            this.R_Neg.Name = "R_Neg";
            this.R_Neg.Size = new System.Drawing.Size(40, 53);
            this.R_Neg.TabIndex = 282;
            this.R_Neg.Tag = "3";
            this.R_Neg.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.R_Neg.UseVisualStyleBackColor = true;
            // 
            // R_Pos
            // 
            this.R_Pos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("R_Pos.BackgroundImage")));
            this.R_Pos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.R_Pos.FlatAppearance.BorderSize = 0;
            this.R_Pos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.R_Pos.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.R_Pos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.R_Pos.Location = new System.Drawing.Point(292, 85);
            this.R_Pos.Name = "R_Pos";
            this.R_Pos.Size = new System.Drawing.Size(41, 52);
            this.R_Pos.TabIndex = 281;
            this.R_Pos.Tag = "3";
            this.R_Pos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.R_Pos.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.Location = new System.Drawing.Point(86, 91);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(54, 53);
            this.button7.TabIndex = 284;
            this.button7.Tag = "1";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.FlatAppearance.BorderSize = 0;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Image = ((System.Drawing.Image)(resources.GetObject("button8.Image")));
            this.button8.Location = new System.Drawing.Point(87, 200);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(54, 53);
            this.button8.TabIndex = 286;
            this.button8.Tag = "1";
            this.button8.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button8.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.FlatAppearance.BorderSize = 0;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.Location = new System.Drawing.Point(139, 144);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(65, 53);
            this.button9.TabIndex = 285;
            this.button9.Tag = "0";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.FlatAppearance.BorderSize = 0;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.Location = new System.Drawing.Point(26, 144);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(61, 53);
            this.button10.TabIndex = 287;
            this.button10.Tag = "0";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = false;
            // 
            // button11
            // 
            this.button11.FlatAppearance.BorderSize = 0;
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button11.Image = ((System.Drawing.Image)(resources.GetObject("button11.Image")));
            this.button11.Location = new System.Drawing.Point(205, 201);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(53, 58);
            this.button11.TabIndex = 289;
            this.button11.Tag = "2";
            this.button11.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.FlatAppearance.BorderSize = 0;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button12.Image = ((System.Drawing.Image)(resources.GetObject("button12.Image")));
            this.button12.Location = new System.Drawing.Point(204, 79);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(53, 64);
            this.button12.TabIndex = 288;
            this.button12.Tag = "2";
            this.button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button12.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(373, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 26);
            this.label1.TabIndex = 290;
            this.label1.Text = "X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(374, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 26);
            this.label2.TabIndex = 291;
            this.label2.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(373, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 26);
            this.label3.TabIndex = 292;
            this.label3.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(374, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 26);
            this.label4.TabIndex = 293;
            this.label4.Text = "R:";
            // 
            // XYZ_Jog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(497, 283);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.R_Neg);
            this.Controls.Add(this.R_Pos);
            this.Controls.Add(this.numericUpDown31);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.comboBox4);
            this.Controls.Add(this.Bt_home);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "XYZ_Jog";
            this.Text = "XYZ_Jog";
            this.Load += new System.EventHandler(this.XYZ_Jog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown31)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.NumericUpDown numericUpDown31;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Button Bt_home;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button R_Neg;
        private System.Windows.Forms.Button R_Pos;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}