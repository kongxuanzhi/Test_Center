namespace TRESystem2011.Sample
{
    partial class SelectReport
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmaCB = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.snolabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.PreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.rptlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.wzRadio = new System.Windows.Forms.RadioButton();
            this.jyRadio = new System.Windows.Forms.RadioButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmaCB);
            this.groupBox2.Location = new System.Drawing.Point(568, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(119, 77);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "加盖印章";
            // 
            // cmaCB
            // 
            this.cmaCB.AutoSize = true;
            this.cmaCB.Checked = true;
            this.cmaCB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cmaCB.Location = new System.Drawing.Point(14, 25);
            this.cmaCB.Name = "cmaCB";
            this.cmaCB.Size = new System.Drawing.Size(54, 16);
            this.cmaCB.TabIndex = 1;
            this.cmaCB.Text = "CMA章";
            this.cmaCB.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Location = new System.Drawing.Point(197, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 41);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "落款单位选择";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(167, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "江西理工大学分析测试中心";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.snolabel);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.PreviewCheckBox);
            this.panel1.Controls.Add(this.rptlabel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(992, 81);
            this.panel1.TabIndex = 20;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(693, 52);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(125, 26);
            this.button3.TabIndex = 27;
            this.button3.Text = "检测报告详情";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(693, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 40);
            this.button2.TabIndex = 26;
            this.button2.Text = "预授权";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // snolabel
            // 
            this.snolabel.AutoSize = true;
            this.snolabel.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.snolabel.Location = new System.Drawing.Point(72, 7);
            this.snolabel.Name = "snolabel";
            this.snolabel.Size = new System.Drawing.Size(18, 12);
            this.snolabel.TabIndex = 25;
            this.snolabel.Text = "无";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 24;
            this.label2.Text = "样品";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(824, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 61);
            this.button1.TabIndex = 23;
            this.button1.Text = "【授权确认】";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PreviewCheckBox
            // 
            this.PreviewCheckBox.AutoSize = true;
            this.PreviewCheckBox.Checked = true;
            this.PreviewCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.PreviewCheckBox.Location = new System.Drawing.Point(89, 56);
            this.PreviewCheckBox.Name = "PreviewCheckBox";
            this.PreviewCheckBox.Size = new System.Drawing.Size(72, 16);
            this.PreviewCheckBox.TabIndex = 22;
            this.PreviewCheckBox.Text = "开启预览";
            this.PreviewCheckBox.UseVisualStyleBackColor = true;
            // 
            // rptlabel
            // 
            this.rptlabel.AutoSize = true;
            this.rptlabel.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rptlabel.Location = new System.Drawing.Point(72, 32);
            this.rptlabel.Name = "rptlabel";
            this.rptlabel.Size = new System.Drawing.Size(18, 12);
            this.rptlabel.TabIndex = 21;
            this.rptlabel.Text = "无";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "报告格式";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.wzRadio);
            this.groupBox3.Controls.Add(this.jyRadio);
            this.groupBox3.Location = new System.Drawing.Point(443, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(119, 77);
            this.groupBox3.TabIndex = 19;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "格式选择";
            // 
            // wzRadio
            // 
            this.wzRadio.AutoSize = true;
            this.wzRadio.Location = new System.Drawing.Point(18, 47);
            this.wzRadio.Name = "wzRadio";
            this.wzRadio.Size = new System.Drawing.Size(71, 16);
            this.wzRadio.TabIndex = 1;
            this.wzRadio.Text = "完整格式";
            this.wzRadio.UseVisualStyleBackColor = true;
            // 
            // jyRadio
            // 
            this.jyRadio.AutoSize = true;
            this.jyRadio.Checked = true;
            this.jyRadio.Location = new System.Drawing.Point(18, 19);
            this.jyRadio.Name = "jyRadio";
            this.jyRadio.Size = new System.Drawing.Size(71, 16);
            this.jyRadio.TabIndex = 0;
            this.jyRadio.TabStop = true;
            this.jyRadio.Text = "简约格式";
            this.jyRadio.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 81);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(992, 485);
            this.splitContainer1.SplitterDistance = 161;
            this.splitContainer1.TabIndex = 21;
            // 
            // listBox1
            // 
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(0, 0);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(161, 485);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(827, 485);
            this.crystalReportViewer1.TabIndex = 0;
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // SelectReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "SelectReport";
            this.Text = "报告类型选择";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectReport_FormClosing);
            this.Load += new System.EventHandler(this.SelectReport_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label rptlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox PreviewCheckBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label snolabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cmaCB;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton wzRadio;
        private System.Windows.Forms.RadioButton jyRadio;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}