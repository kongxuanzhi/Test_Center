namespace TRESystem2011.Sample
{
    partial class SampleMuiltyAdd
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.samplesDGV = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.titemsUC1 = new TRESystem2011.UserControls.TitemsUC();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.CnoTB = new System.Windows.Forms.TextBox();
            this.CnameTB = new System.Windows.Forms.TextBox();
            this.jyDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label25 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.RcountUD = new System.Windows.Forms.NumericUpDown();
            this.label73 = new System.Windows.Forms.Label();
            this.CostmodeCB = new System.Windows.Forms.ComboBox();
            this.RgivemodeCB = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ScanretestCB = new System.Windows.Forms.ComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.hyDatePicker = new System.Windows.Forms.DateTimePicker();
            this.label67 = new System.Windows.Forms.Label();
            this.ShandleCB = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.samplesDGV)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RcountUD)).BeginInit();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(992, 475);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.samplesDGV);
            this.tabPage2.Location = new System.Drawing.Point(4, 21);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(984, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "样品列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // samplesDGV
            // 
            this.samplesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.samplesDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.samplesDGV.Location = new System.Drawing.Point(3, 3);
            this.samplesDGV.Name = "samplesDGV";
            this.samplesDGV.RowTemplate.Height = 23;
            this.samplesDGV.Size = new System.Drawing.Size(978, 444);
            this.samplesDGV.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.titemsUC1);
            this.tabPage3.Location = new System.Drawing.Point(4, 21);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(984, 450);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "检测项目列表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // titemsUC1
            // 
            this.titemsUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.titemsUC1.Location = new System.Drawing.Point(0, 0);
            this.titemsUC1.Name = "titemsUC1";
            this.titemsUC1.Size = new System.Drawing.Size(984, 450);
            this.titemsUC1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(124, 58);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "导入数据";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 309;
            this.button2.Text = "选择客户";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CnoTB
            // 
            this.CnoTB.BackColor = System.Drawing.Color.White;
            this.CnoTB.Location = new System.Drawing.Point(358, 4);
            this.CnoTB.Name = "CnoTB";
            this.CnoTB.ReadOnly = true;
            this.CnoTB.Size = new System.Drawing.Size(80, 21);
            this.CnoTB.TabIndex = 307;
            // 
            // CnameTB
            // 
            this.CnameTB.BackColor = System.Drawing.Color.White;
            this.CnameTB.Location = new System.Drawing.Point(84, 4);
            this.CnameTB.Name = "CnameTB";
            this.CnameTB.ReadOnly = true;
            this.CnameTB.Size = new System.Drawing.Size(258, 21);
            this.CnameTB.TabIndex = 306;
            // 
            // jyDatePicker
            // 
            this.jyDatePicker.CustomFormat = "";
            this.jyDatePicker.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.jyDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.jyDatePicker.Location = new System.Drawing.Point(542, 5);
            this.jyDatePicker.Name = "jyDatePicker";
            this.jyDatePicker.Size = new System.Drawing.Size(168, 21);
            this.jyDatePicker.TabIndex = 310;
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(470, 8);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(66, 12);
            this.label25.TabIndex = 311;
            this.label25.Text = "进样时间";
            // 
            // label50
            // 
            this.label50.Location = new System.Drawing.Point(385, 35);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(53, 12);
            this.label50.TabIndex = 315;
            this.label50.Text = "交付方式";
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(561, 35);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(58, 12);
            this.label48.TabIndex = 316;
            this.label48.Text = "付款方式";
            this.label48.Click += new System.EventHandler(this.label48_Click);
            // 
            // RcountUD
            // 
            this.RcountUD.Location = new System.Drawing.Point(805, 31);
            this.RcountUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.RcountUD.Name = "RcountUD";
            this.RcountUD.Size = new System.Drawing.Size(107, 21);
            this.RcountUD.TabIndex = 314;
            this.RcountUD.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label73
            // 
            this.label73.Location = new System.Drawing.Point(741, 35);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(58, 12);
            this.label73.TabIndex = 317;
            this.label73.Text = "报告份数";
            // 
            // CostmodeCB
            // 
            this.CostmodeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CostmodeCB.FormattingEnabled = true;
            this.CostmodeCB.Items.AddRange(new object[] {
            "现金",
            "转账",
            "汇款"});
            this.CostmodeCB.Location = new System.Drawing.Point(625, 31);
            this.CostmodeCB.Name = "CostmodeCB";
            this.CostmodeCB.Size = new System.Drawing.Size(107, 20);
            this.CostmodeCB.TabIndex = 313;
            // 
            // RgivemodeCB
            // 
            this.RgivemodeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RgivemodeCB.FormattingEnabled = true;
            this.RgivemodeCB.Items.AddRange(new object[] {
            "自取",
            "传真",
            "E-Mail",
            "挂号邮寄",
            "快递"});
            this.RgivemodeCB.Location = new System.Drawing.Point(444, 31);
            this.RgivemodeCB.Name = "RgivemodeCB";
            this.RgivemodeCB.Size = new System.Drawing.Size(107, 20);
            this.RgivemodeCB.TabIndex = 312;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.ScanretestCB);
            this.panel1.Controls.Add(this.label65);
            this.panel1.Controls.Add(this.label72);
            this.panel1.Controls.Add(this.hyDatePicker);
            this.panel1.Controls.Add(this.label67);
            this.panel1.Controls.Add(this.ShandleCB);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label50);
            this.panel1.Controls.Add(this.jyDatePicker);
            this.panel1.Controls.Add(this.label48);
            this.panel1.Controls.Add(this.CnameTB);
            this.panel1.Controls.Add(this.RcountUD);
            this.panel1.Controls.Add(this.CnoTB);
            this.panel1.Controls.Add(this.label73);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.CostmodeCB);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.RgivemodeCB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 87);
            this.panel1.TabIndex = 318;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(431, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(557, 12);
            this.label1.TabIndex = 327;
            this.label1.Text = "注：模板第一行为中文注释，不会被添加。样品名称、样品类别、原编号、样品数量、检测费用为必填项";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(235, 58);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(107, 23);
            this.button5.TabIndex = 326;
            this.button5.Text = "获取模板";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(7, 58);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(111, 23);
            this.button4.TabIndex = 325;
            this.button4.Text = "手工填写";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Blue;
            this.button3.Location = new System.Drawing.Point(348, 50);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 37);
            this.button3.TabIndex = 324;
            this.button3.Text = "确定添加";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ScanretestCB
            // 
            this.ScanretestCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ScanretestCB.FormattingEnabled = true;
            this.ScanretestCB.Items.AddRange(new object[] {
            "不可复检",
            "可供复检"});
            this.ScanretestCB.Location = new System.Drawing.Point(263, 30);
            this.ScanretestCB.Name = "ScanretestCB";
            this.ScanretestCB.Size = new System.Drawing.Size(107, 20);
            this.ScanretestCB.TabIndex = 322;
            // 
            // label65
            // 
            this.label65.Location = new System.Drawing.Point(204, 34);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(53, 12);
            this.label65.TabIndex = 323;
            this.label65.Text = "能否复检";
            // 
            // label72
            // 
            this.label72.ForeColor = System.Drawing.Color.Red;
            this.label72.Location = new System.Drawing.Point(716, 9);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(60, 12);
            this.label72.TabIndex = 321;
            this.label72.Text = "合约时间";
            // 
            // hyDatePicker
            // 
            this.hyDatePicker.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.hyDatePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.hyDatePicker.Location = new System.Drawing.Point(782, 4);
            this.hyDatePicker.Name = "hyDatePicker";
            this.hyDatePicker.Size = new System.Drawing.Size(130, 21);
            this.hyDatePicker.TabIndex = 320;
            // 
            // label67
            // 
            this.label67.Location = new System.Drawing.Point(12, 34);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(58, 12);
            this.label67.TabIndex = 319;
            this.label67.Text = "样品处置";
            // 
            // ShandleCB
            // 
            this.ShandleCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ShandleCB.FormattingEnabled = true;
            this.ShandleCB.Items.AddRange(new object[] {
            "全部报损",
            "取回未损耗样品",
            "全部取(包括已损坏的样品)"});
            this.ShandleCB.Location = new System.Drawing.Point(84, 30);
            this.ShandleCB.Name = "ShandleCB";
            this.ShandleCB.Size = new System.Drawing.Size(107, 20);
            this.ShandleCB.TabIndex = 318;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(992, 566);
            this.splitContainer1.SplitterDistance = 87;
            this.splitContainer1.TabIndex = 326;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Sname";
            this.dataGridViewTextBoxColumn1.HeaderText = "样品名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Skind";
            this.dataGridViewTextBoxColumn2.HeaderText = "样品类别";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "SoriginalNo";
            this.dataGridViewTextBoxColumn3.HeaderText = "原编号";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Squantity";
            this.dataGridViewTextBoxColumn4.HeaderText = "样品数量";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Costtotal";
            this.dataGridViewTextBoxColumn5.HeaderText = "检测费用";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Costexpress";
            this.dataGridViewTextBoxColumn6.HeaderText = "加急费用";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "CostSpreparation";
            this.dataGridViewTextBoxColumn7.HeaderText = "制样费用";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Costnopay";
            this.dataGridViewTextBoxColumn8.HeaderText = "未付费用";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // SampleMuiltyAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SampleMuiltyAdd";
            this.Text = "批量添加样品";
            this.Load += new System.EventHandler(this.SampleMuiltyAdd_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.samplesDGV)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RcountUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private TRESystem2011.UserControls.TitemsUC titemsUC1;
        private System.Windows.Forms.DataGridView samplesDGV;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        public System.Windows.Forms.TextBox CnoTB;
        public System.Windows.Forms.TextBox CnameTB;
        public System.Windows.Forms.DateTimePicker jyDatePicker;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label50;
        public System.Windows.Forms.Label label48;
        public System.Windows.Forms.NumericUpDown RcountUD;
        public System.Windows.Forms.Label label73;
        public System.Windows.Forms.ComboBox CostmodeCB;
        public System.Windows.Forms.ComboBox RgivemodeCB;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox ShandleCB;
        public System.Windows.Forms.Label label67;
        public System.Windows.Forms.Label label72;
        public System.Windows.Forms.DateTimePicker hyDatePicker;
        public System.Windows.Forms.ComboBox ScanretestCB;
        public System.Windows.Forms.Label label65;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label1;
    }
}