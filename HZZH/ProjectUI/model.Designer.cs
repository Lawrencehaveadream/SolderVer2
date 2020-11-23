namespace HZZH.ProjectUI
{
    partial class model
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.halconWindowTrain = new HalconDotNet.HWindowControl();
            this.panelPreview = new System.Windows.Forms.Panel();
            this.halconWindowPreview_1 = new HalconDotNet.HWindowControl();
            this.halconWindowPreview_2 = new HalconDotNet.HWindowControl();
            this.halconWindowPreview_0 = new HalconDotNet.HWindowControl();
            this.panel4 = new System.Windows.Forms.Panel();
            this.halconWindowTestImage = new HalconDotNet.HWindowControl();
            this.panel5 = new System.Windows.Forms.Panel();
            this.buttonRightSolder = new System.Windows.Forms.Button();
            this.buttonLeftSolder = new System.Windows.Forms.Button();
            this.buttonRightPolish = new System.Windows.Forms.Button();
            this.buttonLeftPolish = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.buttonGetTrainImage = new System.Windows.Forms.Button();
            this.buttonTestPos = new System.Windows.Forms.Button();
            this.buttonAddModel = new System.Windows.Forms.Button();
            this.buttonRemovePoint = new System.Windows.Forms.Button();
            this.buttonRemoveModel = new System.Windows.Forms.Button();
            this.buttonAddPoint = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelPreview.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.67742F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.37903F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.84274F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelPreview, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel6, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.35849F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.69811F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.75472F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(992, 530);
            this.tableLayoutPanel1.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.halconWindowTrain);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(586, 351);
            this.panel1.TabIndex = 0;
            // 
            // halconWindowTrain
            // 
            this.halconWindowTrain.BackColor = System.Drawing.Color.Black;
            this.halconWindowTrain.BorderColor = System.Drawing.Color.Black;
            this.halconWindowTrain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWindowTrain.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.halconWindowTrain.Location = new System.Drawing.Point(0, 0);
            this.halconWindowTrain.Name = "halconWindowTrain";
            this.halconWindowTrain.Size = new System.Drawing.Size(586, 351);
            this.halconWindowTrain.TabIndex = 3;
            this.halconWindowTrain.WindowSize = new System.Drawing.Size(586, 351);
            // 
            // panelPreview
            // 
            this.panelPreview.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelPreview.Controls.Add(this.halconWindowPreview_1);
            this.panelPreview.Controls.Add(this.halconWindowPreview_2);
            this.panelPreview.Controls.Add(this.halconWindowPreview_0);
            this.panelPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPreview.Location = new System.Drawing.Point(3, 360);
            this.panelPreview.Name = "panelPreview";
            this.tableLayoutPanel1.SetRowSpan(this.panelPreview, 2);
            this.panelPreview.Size = new System.Drawing.Size(586, 167);
            this.panelPreview.TabIndex = 2;
            this.panelPreview.SizeChanged += new System.EventHandler(this.panelPreview_SizeChanged);
            // 
            // halconWindowPreview_1
            // 
            this.halconWindowPreview_1.BackColor = System.Drawing.Color.Black;
            this.halconWindowPreview_1.BorderColor = System.Drawing.Color.Black;
            this.halconWindowPreview_1.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.halconWindowPreview_1.Location = new System.Drawing.Point(200, 6);
            this.halconWindowPreview_1.Name = "halconWindowPreview_1";
            this.halconWindowPreview_1.Size = new System.Drawing.Size(194, 158);
            this.halconWindowPreview_1.TabIndex = 6;
            this.halconWindowPreview_1.WindowSize = new System.Drawing.Size(194, 158);
            this.halconWindowPreview_1.HMouseDown += new HalconDotNet.HMouseEventHandler(this.halconWindowPreview_1_HMouseDown);
            // 
            // halconWindowPreview_2
            // 
            this.halconWindowPreview_2.BackColor = System.Drawing.Color.Black;
            this.halconWindowPreview_2.BorderColor = System.Drawing.Color.Black;
            this.halconWindowPreview_2.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.halconWindowPreview_2.Location = new System.Drawing.Point(400, 3);
            this.halconWindowPreview_2.Name = "halconWindowPreview_2";
            this.halconWindowPreview_2.Size = new System.Drawing.Size(183, 164);
            this.halconWindowPreview_2.TabIndex = 5;
            this.halconWindowPreview_2.WindowSize = new System.Drawing.Size(183, 164);
            this.halconWindowPreview_2.HMouseDown += new HalconDotNet.HMouseEventHandler(this.halconWindowPreview_2_HMouseDown);
            // 
            // halconWindowPreview_0
            // 
            this.halconWindowPreview_0.BackColor = System.Drawing.Color.Black;
            this.halconWindowPreview_0.BorderColor = System.Drawing.Color.Black;
            this.halconWindowPreview_0.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.halconWindowPreview_0.Location = new System.Drawing.Point(3, 3);
            this.halconWindowPreview_0.Name = "halconWindowPreview_0";
            this.halconWindowPreview_0.Size = new System.Drawing.Size(191, 155);
            this.halconWindowPreview_0.TabIndex = 4;
            this.halconWindowPreview_0.WindowSize = new System.Drawing.Size(191, 155);
            this.halconWindowPreview_0.HMouseDown += new HalconDotNet.HMouseEventHandler(this.halconWindowPreview_0_HMouseDown);
            // 
            // panel4
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel4, 2);
            this.panel4.Controls.Add(this.halconWindowTestImage);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(595, 360);
            this.panel4.Name = "panel4";
            this.tableLayoutPanel1.SetRowSpan(this.panel4, 2);
            this.panel4.Size = new System.Drawing.Size(394, 167);
            this.panel4.TabIndex = 5;
            // 
            // halconWindowTestImage
            // 
            this.halconWindowTestImage.BackColor = System.Drawing.Color.Black;
            this.halconWindowTestImage.BorderColor = System.Drawing.Color.Black;
            this.halconWindowTestImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.halconWindowTestImage.ImagePart = new System.Drawing.Rectangle(0, 0, 640, 480);
            this.halconWindowTestImage.Location = new System.Drawing.Point(0, 0);
            this.halconWindowTestImage.Name = "halconWindowTestImage";
            this.halconWindowTestImage.Size = new System.Drawing.Size(394, 167);
            this.halconWindowTestImage.TabIndex = 4;
            this.halconWindowTestImage.WindowSize = new System.Drawing.Size(394, 167);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.buttonRightSolder);
            this.panel5.Controls.Add(this.buttonLeftSolder);
            this.panel5.Controls.Add(this.buttonRightPolish);
            this.panel5.Controls.Add(this.buttonLeftPolish);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(817, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(172, 351);
            this.panel5.TabIndex = 6;
            // 
            // buttonRightSolder
            // 
            this.buttonRightSolder.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRightSolder.Location = new System.Drawing.Point(24, 279);
            this.buttonRightSolder.Name = "buttonRightSolder";
            this.buttonRightSolder.Size = new System.Drawing.Size(128, 64);
            this.buttonRightSolder.TabIndex = 7;
            this.buttonRightSolder.Tag = "3";
            this.buttonRightSolder.Text = "右侧上锡";
            this.buttonRightSolder.UseVisualStyleBackColor = true;
            this.buttonRightSolder.Click += new System.EventHandler(this.buttonLeftPolish_Click_1);
            // 
            // buttonLeftSolder
            // 
            this.buttonLeftSolder.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLeftSolder.Location = new System.Drawing.Point(24, 190);
            this.buttonLeftSolder.Name = "buttonLeftSolder";
            this.buttonLeftSolder.Size = new System.Drawing.Size(128, 64);
            this.buttonLeftSolder.TabIndex = 6;
            this.buttonLeftSolder.Tag = "2";
            this.buttonLeftSolder.Text = "左侧上锡";
            this.buttonLeftSolder.UseVisualStyleBackColor = true;
            this.buttonLeftSolder.Click += new System.EventHandler(this.buttonLeftPolish_Click_1);
            // 
            // buttonRightPolish
            // 
            this.buttonRightPolish.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRightPolish.Location = new System.Drawing.Point(24, 101);
            this.buttonRightPolish.Name = "buttonRightPolish";
            this.buttonRightPolish.Size = new System.Drawing.Size(128, 64);
            this.buttonRightPolish.TabIndex = 5;
            this.buttonRightPolish.Tag = "1";
            this.buttonRightPolish.Text = "右侧打磨";
            this.buttonRightPolish.UseVisualStyleBackColor = true;
            this.buttonRightPolish.Click += new System.EventHandler(this.buttonLeftPolish_Click_1);
            // 
            // buttonLeftPolish
            // 
            this.buttonLeftPolish.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonLeftPolish.Location = new System.Drawing.Point(24, 12);
            this.buttonLeftPolish.Name = "buttonLeftPolish";
            this.buttonLeftPolish.Size = new System.Drawing.Size(128, 64);
            this.buttonLeftPolish.TabIndex = 4;
            this.buttonLeftPolish.Tag = "0";
            this.buttonLeftPolish.Text = "左侧打磨";
            this.buttonLeftPolish.UseVisualStyleBackColor = true;
            this.buttonLeftPolish.Click += new System.EventHandler(this.buttonLeftPolish_Click_1);
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.buttonGetTrainImage);
            this.panel6.Controls.Add(this.buttonTestPos);
            this.panel6.Controls.Add(this.buttonAddModel);
            this.panel6.Controls.Add(this.buttonRemovePoint);
            this.panel6.Controls.Add(this.buttonRemoveModel);
            this.panel6.Controls.Add(this.buttonAddPoint);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(595, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(216, 351);
            this.panel6.TabIndex = 7;
            // 
            // buttonGetTrainImage
            // 
            this.buttonGetTrainImage.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonGetTrainImage.Location = new System.Drawing.Point(6, 12);
            this.buttonGetTrainImage.Name = "buttonGetTrainImage";
            this.buttonGetTrainImage.Size = new System.Drawing.Size(203, 77);
            this.buttonGetTrainImage.TabIndex = 10;
            this.buttonGetTrainImage.Text = "获 取 图 片";
            this.buttonGetTrainImage.UseVisualStyleBackColor = true;
            this.buttonGetTrainImage.Click += new System.EventHandler(this.buttonGetTrainImage_Click);
            // 
            // buttonTestPos
            // 
            this.buttonTestPos.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonTestPos.Location = new System.Drawing.Point(6, 280);
            this.buttonTestPos.Name = "buttonTestPos";
            this.buttonTestPos.Size = new System.Drawing.Size(203, 63);
            this.buttonTestPos.TabIndex = 9;
            this.buttonTestPos.Text = "点 位 测 试";
            this.buttonTestPos.UseVisualStyleBackColor = true;
            this.buttonTestPos.Click += new System.EventHandler(this.buttonTestPos_Click);
            // 
            // buttonAddModel
            // 
            this.buttonAddModel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddModel.Location = new System.Drawing.Point(6, 99);
            this.buttonAddModel.Name = "buttonAddModel";
            this.buttonAddModel.Size = new System.Drawing.Size(90, 79);
            this.buttonAddModel.TabIndex = 3;
            this.buttonAddModel.Text = "添加模板";
            this.buttonAddModel.UseVisualStyleBackColor = true;
            this.buttonAddModel.Click += new System.EventHandler(this.buttonAddModel_Click);
            // 
            // buttonRemovePoint
            // 
            this.buttonRemovePoint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRemovePoint.Location = new System.Drawing.Point(119, 192);
            this.buttonRemovePoint.Name = "buttonRemovePoint";
            this.buttonRemovePoint.Size = new System.Drawing.Size(90, 79);
            this.buttonRemovePoint.TabIndex = 8;
            this.buttonRemovePoint.Text = "移除点";
            this.buttonRemovePoint.UseVisualStyleBackColor = true;
            // 
            // buttonRemoveModel
            // 
            this.buttonRemoveModel.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonRemoveModel.Location = new System.Drawing.Point(119, 99);
            this.buttonRemoveModel.Name = "buttonRemoveModel";
            this.buttonRemoveModel.Size = new System.Drawing.Size(90, 79);
            this.buttonRemoveModel.TabIndex = 4;
            this.buttonRemoveModel.Text = "移除模板";
            this.buttonRemoveModel.UseVisualStyleBackColor = true;
            // 
            // buttonAddPoint
            // 
            this.buttonAddPoint.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonAddPoint.Location = new System.Drawing.Point(6, 192);
            this.buttonAddPoint.Name = "buttonAddPoint";
            this.buttonAddPoint.Size = new System.Drawing.Size(90, 79);
            this.buttonAddPoint.TabIndex = 7;
            this.buttonAddPoint.Text = "添加点";
            this.buttonAddPoint.UseVisualStyleBackColor = true;
            this.buttonAddPoint.Click += new System.EventHandler(this.buttonAddPoint_Click);
            // 
            // model
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(992, 530);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "model";
            this.Text = "Polish";
            this.Shown += new System.EventHandler(this.model_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panelPreview.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Button buttonTestPos;
        private System.Windows.Forms.Button buttonRemovePoint;
        private System.Windows.Forms.Button buttonAddPoint;
        private System.Windows.Forms.Button buttonRemoveModel;
        private System.Windows.Forms.Button buttonAddModel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button buttonRightSolder;
        private System.Windows.Forms.Button buttonLeftSolder;
        private System.Windows.Forms.Button buttonRightPolish;
        private System.Windows.Forms.Button buttonLeftPolish;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Button buttonGetTrainImage;
        private HalconDotNet.HWindowControl halconWindowTrain;
        private HalconDotNet.HWindowControl halconWindowTestImage;
        private HalconDotNet.HWindowControl halconWindowPreview_1;
        private HalconDotNet.HWindowControl halconWindowPreview_2;
        private HalconDotNet.HWindowControl halconWindowPreview_0;
    }
}