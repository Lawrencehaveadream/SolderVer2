namespace HZZH.UI.DerivedControl
{
    partial class Frm_MotorParam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_MotorParam));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.Nud_DAch2 = new System.Windows.Forms.NumericUpDown();
            this.Nud_DAch1 = new System.Windows.Forms.NumericUpDown();
            this.Nud_ADch2 = new System.Windows.Forms.NumericUpDown();
            this.Nud_ADch1 = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.LB_Encoder4 = new System.Windows.Forms.Label();
            this.LB_Encoder3 = new System.Windows.Forms.Label();
            this.LB_Encoder2 = new System.Windows.Forms.Label();
            this.LB_Encoder1 = new System.Windows.Forms.Label();
            this.Bt_MotorPowe = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown31 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.skinTrackBar1 = new CCWin.SkinControl.SkinTrackBar();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.速度参数 = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.脉冲数 = new System.Windows.Forms.TabPage();
            this.propertyGrid2 = new System.Windows.Forms.PropertyGrid();
            this.轴配置 = new System.Windows.Forms.TabPage();
            this.propertyGrid3 = new System.Windows.Forms.PropertyGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_DAch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_DAch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_ADch2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_ADch1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.速度参数.SuspendLayout();
            this.脉冲数.SuspendLayout();
            this.轴配置.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText;
            this.treeView1.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(428, 804);
            this.treeView1.TabIndex = 54;
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // Nud_DAch2
            // 
            this.Nud_DAch2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Nud_DAch2.Location = new System.Drawing.Point(561, 131);
            this.Nud_DAch2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Nud_DAch2.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.Nud_DAch2.Name = "Nud_DAch2";
            this.Nud_DAch2.Size = new System.Drawing.Size(107, 35);
            this.Nud_DAch2.TabIndex = 277;
            // 
            // Nud_DAch1
            // 
            this.Nud_DAch1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Nud_DAch1.Location = new System.Drawing.Point(561, 78);
            this.Nud_DAch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Nud_DAch1.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.Nud_DAch1.Name = "Nud_DAch1";
            this.Nud_DAch1.Size = new System.Drawing.Size(107, 35);
            this.Nud_DAch1.TabIndex = 276;
            // 
            // Nud_ADch2
            // 
            this.Nud_ADch2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Nud_ADch2.Location = new System.Drawing.Point(227, 129);
            this.Nud_ADch2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Nud_ADch2.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.Nud_ADch2.Name = "Nud_ADch2";
            this.Nud_ADch2.Size = new System.Drawing.Size(107, 35);
            this.Nud_ADch2.TabIndex = 275;
            // 
            // Nud_ADch1
            // 
            this.Nud_ADch1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Nud_ADch1.Location = new System.Drawing.Point(227, 78);
            this.Nud_ADch1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Nud_ADch1.Maximum = new decimal(new int[] {
            4095,
            0,
            0,
            0});
            this.Nud_ADch1.Name = "Nud_ADch1";
            this.Nud_ADch1.Size = new System.Drawing.Size(107, 35);
            this.Nud_ADch1.TabIndex = 274;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("黑体", 15F);
            this.label15.Location = new System.Drawing.Point(420, 106);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 25);
            this.label15.TabIndex = 273;
            this.label15.Text = "DA";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("黑体", 15F);
            this.label14.Location = new System.Drawing.Point(85, 100);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 25);
            this.label14.TabIndex = 272;
            this.label14.Text = "AD";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("黑体", 15F);
            this.label3.Location = new System.Drawing.Point(476, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 25);
            this.label3.TabIndex = 271;
            this.label3.Text = "CH2:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("黑体", 15F);
            this.label10.Location = new System.Drawing.Point(476, 81);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 25);
            this.label10.TabIndex = 270;
            this.label10.Text = "CH1:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("黑体", 15F);
            this.label12.Location = new System.Drawing.Point(141, 134);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 25);
            this.label12.TabIndex = 269;
            this.label12.Text = "CH2:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("黑体", 15F);
            this.label13.Location = new System.Drawing.Point(141, 80);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 25);
            this.label13.TabIndex = 268;
            this.label13.Text = "CH1:";
            // 
            // LB_Encoder4
            // 
            this.LB_Encoder4.AutoSize = true;
            this.LB_Encoder4.Font = new System.Drawing.Font("黑体", 15F);
            this.LB_Encoder4.Location = new System.Drawing.Point(332, 149);
            this.LB_Encoder4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Encoder4.Name = "LB_Encoder4";
            this.LB_Encoder4.Size = new System.Drawing.Size(207, 25);
            this.LB_Encoder4.TabIndex = 271;
            this.LB_Encoder4.Text = "编码器4：000000";
            // 
            // LB_Encoder3
            // 
            this.LB_Encoder3.AutoSize = true;
            this.LB_Encoder3.Font = new System.Drawing.Font("黑体", 15F);
            this.LB_Encoder3.Location = new System.Drawing.Point(332, 71);
            this.LB_Encoder3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Encoder3.Name = "LB_Encoder3";
            this.LB_Encoder3.Size = new System.Drawing.Size(207, 25);
            this.LB_Encoder3.TabIndex = 270;
            this.LB_Encoder3.Text = "编码器3：000000";
            // 
            // LB_Encoder2
            // 
            this.LB_Encoder2.AutoSize = true;
            this.LB_Encoder2.Font = new System.Drawing.Font("黑体", 15F);
            this.LB_Encoder2.Location = new System.Drawing.Point(56, 149);
            this.LB_Encoder2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Encoder2.Name = "LB_Encoder2";
            this.LB_Encoder2.Size = new System.Drawing.Size(207, 25);
            this.LB_Encoder2.TabIndex = 269;
            this.LB_Encoder2.Text = "编码器2：000000";
            // 
            // LB_Encoder1
            // 
            this.LB_Encoder1.AutoSize = true;
            this.LB_Encoder1.Font = new System.Drawing.Font("黑体", 15F);
            this.LB_Encoder1.Location = new System.Drawing.Point(56, 71);
            this.LB_Encoder1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LB_Encoder1.Name = "LB_Encoder1";
            this.LB_Encoder1.Size = new System.Drawing.Size(207, 25);
            this.LB_Encoder1.TabIndex = 268;
            this.LB_Encoder1.Text = "编码器1：000000";
            // 
            // Bt_MotorPowe
            // 
            this.Bt_MotorPowe.BackgroundImage = global::HZZH.Properties.Resources.使能开4;
            this.Bt_MotorPowe.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Bt_MotorPowe.Location = new System.Drawing.Point(641, 129);
            this.Bt_MotorPowe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bt_MotorPowe.Name = "Bt_MotorPowe";
            this.Bt_MotorPowe.Size = new System.Drawing.Size(112, 69);
            this.Bt_MotorPowe.TabIndex = 267;
            this.Bt_MotorPowe.UseVisualStyleBackColor = true;
            this.Bt_MotorPowe.Click += new System.EventHandler(this.Bt_MotorPowe_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(27, 13);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 20);
            this.label11.TabIndex = 266;
            this.label11.Text = "轴名称";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(420, 96);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 15);
            this.label9.TabIndex = 264;
            this.label9.Text = "步长";
            // 
            // numericUpDown31
            // 
            this.numericUpDown31.DecimalPlaces = 3;
            this.numericUpDown31.Location = new System.Drawing.Point(480, 92);
            this.numericUpDown31.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown31.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown31.Name = "numericUpDown31";
            this.numericUpDown31.Size = new System.Drawing.Size(100, 25);
            this.numericUpDown31.TabIndex = 263;
            this.numericUpDown31.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(331, 51);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(75, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "速度";
            // 
            // skinTrackBar1
            // 
            this.skinTrackBar1.BackColor = System.Drawing.Color.Transparent;
            this.skinTrackBar1.Bar = null;
            this.skinTrackBar1.BarStyle = CCWin.SkinControl.HSLTrackBarStyle.Opacity;
            this.skinTrackBar1.Location = new System.Drawing.Point(140, 32);
            this.skinTrackBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.skinTrackBar1.Minimum = 1;
            this.skinTrackBar1.Name = "skinTrackBar1";
            this.skinTrackBar1.Size = new System.Drawing.Size(172, 56);
            this.skinTrackBar1.TabIndex = 10;
            this.skinTrackBar1.Track = null;
            this.skinTrackBar1.Value = 1;
            this.skinTrackBar1.Scroll += new System.EventHandler(this.skinTrackBar1_Scroll);
            // 
            // button4
            // 
            this.button4.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button4.BackgroundImage")));
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Location = new System.Drawing.Point(179, 126);
            this.button4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(77, 72);
            this.button4.TabIndex = 9;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Location = new System.Drawing.Point(495, 125);
            this.button3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 72);
            this.button3.TabIndex = 8;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(503, 54);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "轴负限位";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(716, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "轴正限位";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 54);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "轴原点";
            this.label4.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(428, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "轴报警";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("黑体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(72, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "轴当前位置";
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Location = new System.Drawing.Point(20, 126);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(77, 72);
            this.button2.TabIndex = 1;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Location = new System.Drawing.Point(337, 126);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(77, 72);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.速度参数);
            this.tabControl1.Controls.Add(this.脉冲数);
            this.tabControl1.Controls.Add(this.轴配置);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(916, 502);
            this.tabControl1.TabIndex = 56;
            // 
            // 速度参数
            // 
            this.速度参数.Controls.Add(this.propertyGrid1);
            this.速度参数.Location = new System.Drawing.Point(4, 25);
            this.速度参数.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.速度参数.Name = "速度参数";
            this.速度参数.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.速度参数.Size = new System.Drawing.Size(908, 473);
            this.速度参数.TabIndex = 0;
            this.速度参数.Text = "速度参数";
            this.速度参数.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(4, 4);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(0);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(900, 465);
            this.propertyGrid1.TabIndex = 0;
            this.propertyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid1_Click);
            // 
            // 脉冲数
            // 
            this.脉冲数.Controls.Add(this.propertyGrid2);
            this.脉冲数.Location = new System.Drawing.Point(4, 25);
            this.脉冲数.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.脉冲数.Name = "脉冲数";
            this.脉冲数.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.脉冲数.Size = new System.Drawing.Size(908, 473);
            this.脉冲数.TabIndex = 1;
            this.脉冲数.Text = "脉冲数";
            this.脉冲数.UseVisualStyleBackColor = true;
            // 
            // propertyGrid2
            // 
            this.propertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid2.Location = new System.Drawing.Point(4, 4);
            this.propertyGrid2.Margin = new System.Windows.Forms.Padding(0);
            this.propertyGrid2.Name = "propertyGrid2";
            this.propertyGrid2.Size = new System.Drawing.Size(900, 465);
            this.propertyGrid2.TabIndex = 1;
            this.propertyGrid2.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid2_Click);
            // 
            // 轴配置
            // 
            this.轴配置.Controls.Add(this.propertyGrid3);
            this.轴配置.Location = new System.Drawing.Point(4, 25);
            this.轴配置.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.轴配置.Name = "轴配置";
            this.轴配置.Size = new System.Drawing.Size(908, 473);
            this.轴配置.TabIndex = 2;
            this.轴配置.Text = "轴配置";
            this.轴配置.UseVisualStyleBackColor = true;
            // 
            // propertyGrid3
            // 
            this.propertyGrid3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid3.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid3.Margin = new System.Windows.Forms.Padding(0);
            this.propertyGrid3.Name = "propertyGrid3";
            this.propertyGrid3.Size = new System.Drawing.Size(908, 473);
            this.propertyGrid3.TabIndex = 1;
            this.propertyGrid3.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.propertyGrid3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tabControl2);
            this.panel3.Controls.Add(this.tabControl1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(428, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(916, 804);
            this.panel3.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 502);
            this.tabControl2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(916, 302);
            this.tabControl2.TabIndex = 57;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(908, 273);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "轴动";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.LightGray;
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.Bt_MotorPowe);
            this.panel4.Controls.Add(this.button2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.numericUpDown31);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.skinTrackBar1);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.button4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(4, 4);
            this.panel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(900, 265);
            this.panel4.TabIndex = 3;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.Color.Red;
            this.label16.Location = new System.Drawing.Point(63, 218);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(329, 20);
            this.label16.TabIndex = 268;
            this.label16.Text = "注：鼠标左键走步长，右键连续点动";
            this.label16.Visible = false;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.LightGray;
            this.tabPage2.Controls.Add(this.LB_Encoder4);
            this.tabPage2.Controls.Add(this.LB_Encoder3);
            this.tabPage2.Controls.Add(this.LB_Encoder2);
            this.tabPage2.Controls.Add(this.LB_Encoder1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(908, 272);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "编码器";
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.Nud_DAch2);
            this.tabPage3.Controls.Add(this.Nud_DAch1);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.Nud_ADch2);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.Nud_ADch1);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(908, 272);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "模拟量";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1344, 804);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(428, 804);
            this.panel2.TabIndex = 55;
            // 
            // Frm_MotorParam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 804);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_MotorParam";
            this.Text = "Frm_MachinePrm";
            ((System.ComponentModel.ISupportInitialize)(this.Nud_DAch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_DAch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_ADch2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nud_ADch1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.skinTrackBar1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.速度参数.ResumeLayout(false);
            this.脉冲数.ResumeLayout(false);
            this.轴配置.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TreeView treeView1;
        private CCWin.SkinControl.SkinTrackBar skinTrackBar1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown31;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button Bt_MotorPowe;
        private System.Windows.Forms.Label LB_Encoder4;
        private System.Windows.Forms.Label LB_Encoder3;
        private System.Windows.Forms.Label LB_Encoder2;
        private System.Windows.Forms.Label LB_Encoder1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown Nud_DAch2;
        private System.Windows.Forms.NumericUpDown Nud_DAch1;
        private System.Windows.Forms.NumericUpDown Nud_ADch2;
        private System.Windows.Forms.NumericUpDown Nud_ADch1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 速度参数;
        private System.Windows.Forms.TabPage 脉冲数;
        private System.Windows.Forms.TabPage 轴配置;
        private System.Windows.Forms.PropertyGrid propertyGrid2;
        private System.Windows.Forms.PropertyGrid propertyGrid3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label16;
    }
}