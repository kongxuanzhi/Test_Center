namespace ICPTOOLS_DONET
{
    partial class PureForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.upBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.upRateBox = new System.Windows.Forms.TextBox();
            this.downBox = new System.Windows.Forms.TextBox();
            this.downRateBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.XTListBox = new System.Windows.Forms.ListBox();
            this.XTGridView1 = new System.Windows.Forms.DataGridView();
            this.result = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxdiff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.val5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToOBtn = new System.Windows.Forms.Button();
            this.ToNOBtn = new System.Windows.Forms.Button();
            this.clearPathBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.fileFromBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.getInfoBox = new System.Windows.Forms.Button();
            this.PureYsBox = new System.Windows.Forms.TextBox();
            this.NOFZLBox = new System.Windows.Forms.TextBox();
            this.OFZLBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ISOBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.customBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveFileBtn = new System.Windows.Forms.Button();
            this.loadFileBtn = new System.Windows.Forms.Button();
            this.rptBtn = new System.Windows.Forms.Button();
            this.dbbtn = new System.Windows.Forms.Button();
            this.smartRPTBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.XTGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(197, 18);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(622, 21);
            this.pathBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 25);
            this.button1.TabIndex = 1;
            this.button1.Text = "添加(可多选)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 49);
            this.button2.TabIndex = 2;
            this.button2.Text = "解析纯度";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // upBox
            // 
            this.upBox.Location = new System.Drawing.Point(263, 48);
            this.upBox.Name = "upBox";
            this.upBox.ReadOnly = true;
            this.upBox.Size = new System.Drawing.Size(35, 21);
            this.upBox.TabIndex = 4;
            this.upBox.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(204, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "纯度上限";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "上限位数";
            // 
            // upRateBox
            // 
            this.upRateBox.Location = new System.Drawing.Point(363, 48);
            this.upRateBox.Name = "upRateBox";
            this.upRateBox.Size = new System.Drawing.Size(30, 21);
            this.upRateBox.TabIndex = 4;
            this.upRateBox.Text = "2";
            // 
            // downBox
            // 
            this.downBox.Location = new System.Drawing.Point(263, 75);
            this.downBox.Name = "downBox";
            this.downBox.Size = new System.Drawing.Size(35, 21);
            this.downBox.TabIndex = 4;
            this.downBox.Text = "0.010";
            // 
            // downRateBox
            // 
            this.downRateBox.Location = new System.Drawing.Point(363, 75);
            this.downRateBox.Name = "downRateBox";
            this.downRateBox.Size = new System.Drawing.Size(30, 21);
            this.downRateBox.TabIndex = 4;
            this.downRateBox.Text = "3";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(204, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "纯度下限";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(304, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "下限位数";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(409, 47);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(76, 48);
            this.button4.TabIndex = 3;
            this.button4.Text = "修正";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // XTListBox
            // 
            this.XTListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.XTListBox.FormattingEnabled = true;
            this.XTListBox.ItemHeight = 12;
            this.XTListBox.Location = new System.Drawing.Point(12, 114);
            this.XTListBox.Name = "XTListBox";
            this.XTListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.XTListBox.Size = new System.Drawing.Size(123, 436);
            this.XTListBox.Sorted = true;
            this.XTListBox.TabIndex = 9;
            this.XTListBox.SelectedIndexChanged += new System.EventHandler(this.XTListBox_SelectedIndexChanged);
            this.XTListBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.XTListBox_KeyDown);
            // 
            // XTGridView1
            // 
            this.XTGridView1.AllowUserToAddRows = false;
            this.XTGridView1.AllowUserToDeleteRows = false;
            this.XTGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.XTGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.XTGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.XTGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.XTGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.result,
            this.avg,
            this.maxdiff,
            this.val1,
            this.val2,
            this.val3,
            this.val4,
            this.val5});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.NullValue = null;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.XTGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.XTGridView1.Location = new System.Drawing.Point(313, 114);
            this.XTGridView1.Name = "XTGridView1";
            this.XTGridView1.RowTemplate.Height = 23;
            this.XTGridView1.Size = new System.Drawing.Size(603, 436);
            this.XTGridView1.TabIndex = 10;
            // 
            // result
            // 
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.result.DefaultCellStyle = dataGridViewCellStyle3;
            this.result.HeaderText = "修正结果";
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Width = 78;
            // 
            // avg
            // 
            this.avg.HeaderText = "平均值";
            this.avg.Name = "avg";
            this.avg.ReadOnly = true;
            this.avg.Width = 66;
            // 
            // maxdiff
            // 
            this.maxdiff.HeaderText = "最大差值";
            this.maxdiff.Name = "maxdiff";
            this.maxdiff.ReadOnly = true;
            this.maxdiff.Width = 78;
            // 
            // val1
            // 
            this.val1.HeaderText = "数据1";
            this.val1.Name = "val1";
            this.val1.ReadOnly = true;
            this.val1.Width = 60;
            // 
            // val2
            // 
            this.val2.HeaderText = "数据2";
            this.val2.Name = "val2";
            this.val2.ReadOnly = true;
            this.val2.Width = 60;
            // 
            // val3
            // 
            this.val3.HeaderText = "数据3";
            this.val3.Name = "val3";
            this.val3.ReadOnly = true;
            this.val3.Width = 60;
            // 
            // val4
            // 
            this.val4.HeaderText = "数据4";
            this.val4.Name = "val4";
            this.val4.ReadOnly = true;
            this.val4.Width = 60;
            // 
            // val5
            // 
            this.val5.HeaderText = "数据5";
            this.val5.Name = "val5";
            this.val5.Width = 60;
            // 
            // ToOBtn
            // 
            this.ToOBtn.Location = new System.Drawing.Point(3, 13);
            this.ToOBtn.Name = "ToOBtn";
            this.ToOBtn.Size = new System.Drawing.Size(75, 23);
            this.ToOBtn.TabIndex = 11;
            this.ToOBtn.Text = "氧化物";
            this.ToOBtn.UseVisualStyleBackColor = true;
            this.ToOBtn.Click += new System.EventHandler(this.ToOBtn_Click);
            // 
            // ToNOBtn
            // 
            this.ToNOBtn.Location = new System.Drawing.Point(3, 35);
            this.ToNOBtn.Name = "ToNOBtn";
            this.ToNOBtn.Size = new System.Drawing.Size(75, 23);
            this.ToNOBtn.TabIndex = 12;
            this.ToNOBtn.Text = "单质";
            this.ToNOBtn.UseVisualStyleBackColor = true;
            this.ToNOBtn.Click += new System.EventHandler(this.ToNOBtn_Click);
            // 
            // clearPathBtn
            // 
            this.clearPathBtn.Location = new System.Drawing.Point(124, 18);
            this.clearPathBtn.Name = "clearPathBtn";
            this.clearPathBtn.Size = new System.Drawing.Size(55, 27);
            this.clearPathBtn.TabIndex = 14;
            this.clearPathBtn.Text = "清空";
            this.clearPathBtn.UseVisualStyleBackColor = true;
            this.clearPathBtn.Click += new System.EventHandler(this.clearPathBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.fileFromBox);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.getInfoBox);
            this.panel1.Controls.Add(this.PureYsBox);
            this.panel1.Controls.Add(this.NOFZLBox);
            this.panel1.Controls.Add(this.OFZLBox);
            this.panel1.Controls.Add(this.ToNOBtn);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.ToOBtn);
            this.panel1.Controls.Add(this.ISOBox);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.customBox);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.nameBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.idBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(141, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 436);
            this.panel1.TabIndex = 15;
            // 
            // fileFromBox
            // 
            this.fileFromBox.Location = new System.Drawing.Point(11, 357);
            this.fileFromBox.Multiline = true;
            this.fileFromBox.Name = "fileFromBox";
            this.fileFromBox.ReadOnly = true;
            this.fileFromBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.fileFromBox.Size = new System.Drawing.Size(145, 76);
            this.fileFromBox.TabIndex = 14;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(9, 341);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(65, 12);
            this.label12.TabIndex = 13;
            this.label12.Text = "文件来源：";
            // 
            // getInfoBox
            // 
            this.getInfoBox.Location = new System.Drawing.Point(81, 13);
            this.getInfoBox.Name = "getInfoBox";
            this.getInfoBox.Size = new System.Drawing.Size(75, 45);
            this.getInfoBox.TabIndex = 2;
            this.getInfoBox.Text = "获取信息";
            this.getInfoBox.UseVisualStyleBackColor = true;
            this.getInfoBox.Click += new System.EventHandler(this.getInfoBox_Click);
            // 
            // PureYsBox
            // 
            this.PureYsBox.Location = new System.Drawing.Point(104, 305);
            this.PureYsBox.Name = "PureYsBox";
            this.PureYsBox.ReadOnly = true;
            this.PureYsBox.Size = new System.Drawing.Size(52, 21);
            this.PureYsBox.TabIndex = 1;
            // 
            // NOFZLBox
            // 
            this.NOFZLBox.Location = new System.Drawing.Point(104, 264);
            this.NOFZLBox.Name = "NOFZLBox";
            this.NOFZLBox.ReadOnly = true;
            this.NOFZLBox.Size = new System.Drawing.Size(52, 21);
            this.NOFZLBox.TabIndex = 1;
            // 
            // OFZLBox
            // 
            this.OFZLBox.Location = new System.Drawing.Point(104, 224);
            this.OFZLBox.Name = "OFZLBox";
            this.OFZLBox.ReadOnly = true;
            this.OFZLBox.Size = new System.Drawing.Size(52, 21);
            this.OFZLBox.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 308);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "最纯的元素：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 267);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "单质分子量：";
            // 
            // ISOBox
            // 
            this.ISOBox.Location = new System.Drawing.Point(56, 187);
            this.ISOBox.Name = "ISOBox";
            this.ISOBox.ReadOnly = true;
            this.ISOBox.Size = new System.Drawing.Size(100, 21);
            this.ISOBox.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 227);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 0;
            this.label9.Text = "氧化物分子量：";
            // 
            // customBox
            // 
            this.customBox.Location = new System.Drawing.Point(56, 148);
            this.customBox.Name = "customBox";
            this.customBox.ReadOnly = true;
            this.customBox.Size = new System.Drawing.Size(100, 21);
            this.customBox.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 190);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "性质：";
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(56, 110);
            this.nameBox.Name = "nameBox";
            this.nameBox.ReadOnly = true;
            this.nameBox.Size = new System.Drawing.Size(100, 21);
            this.nameBox.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 0;
            this.label7.Text = "客户：";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(56, 75);
            this.idBox.Name = "idBox";
            this.idBox.ReadOnly = true;
            this.idBox.Size = new System.Drawing.Size(100, 21);
            this.idBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "名称：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "编号：";
            // 
            // saveFileBtn
            // 
            this.saveFileBtn.Location = new System.Drawing.Point(491, 47);
            this.saveFileBtn.Name = "saveFileBtn";
            this.saveFileBtn.Size = new System.Drawing.Size(75, 23);
            this.saveFileBtn.TabIndex = 16;
            this.saveFileBtn.Text = "保存文件";
            this.saveFileBtn.UseVisualStyleBackColor = true;
            this.saveFileBtn.Click += new System.EventHandler(this.saveFileBtn_Click);
            // 
            // loadFileBtn
            // 
            this.loadFileBtn.Location = new System.Drawing.Point(491, 72);
            this.loadFileBtn.Name = "loadFileBtn";
            this.loadFileBtn.Size = new System.Drawing.Size(75, 23);
            this.loadFileBtn.TabIndex = 17;
            this.loadFileBtn.Text = "读取文件";
            this.loadFileBtn.UseVisualStyleBackColor = true;
            this.loadFileBtn.Click += new System.EventHandler(this.loadFileBtn_Click);
            // 
            // rptBtn
            // 
            this.rptBtn.Location = new System.Drawing.Point(572, 47);
            this.rptBtn.Name = "rptBtn";
            this.rptBtn.Size = new System.Drawing.Size(75, 48);
            this.rptBtn.TabIndex = 18;
            this.rptBtn.Text = "导出报告";
            this.rptBtn.UseVisualStyleBackColor = true;
            this.rptBtn.Click += new System.EventHandler(this.rptBtn_Click);
            // 
            // dbbtn
            // 
            this.dbbtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbbtn.ForeColor = System.Drawing.Color.Red;
            this.dbbtn.Location = new System.Drawing.Point(734, 47);
            this.dbbtn.Name = "dbbtn";
            this.dbbtn.Size = new System.Drawing.Size(75, 48);
            this.dbbtn.TabIndex = 20;
            this.dbbtn.Text = "写入数据库";
            this.dbbtn.UseVisualStyleBackColor = true;
            this.dbbtn.Click += new System.EventHandler(this.dbbtn_Click);
            // 
            // smartRPTBtn
            // 
            this.smartRPTBtn.Location = new System.Drawing.Point(653, 48);
            this.smartRPTBtn.Name = "smartRPTBtn";
            this.smartRPTBtn.Size = new System.Drawing.Size(75, 48);
            this.smartRPTBtn.TabIndex = 18;
            this.smartRPTBtn.Text = "智能分类导出报告";
            this.smartRPTBtn.UseVisualStyleBackColor = true;
            this.smartRPTBtn.Click += new System.EventHandler(this.smartRPTBtn_Click);
            // 
            // PureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(917, 565);
            this.Controls.Add(this.dbbtn);
            this.Controls.Add(this.smartRPTBtn);
            this.Controls.Add(this.rptBtn);
            this.Controls.Add(this.loadFileBtn);
            this.Controls.Add(this.saveFileBtn);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.clearPathBtn);
            this.Controls.Add(this.XTGridView1);
            this.Controls.Add(this.XTListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.downRateBox);
            this.Controls.Add(this.downBox);
            this.Controls.Add(this.upRateBox);
            this.Controls.Add(this.upBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pathBox);
            this.Name = "PureForm";
            this.Text = "解析纯度";
            this.Load += new System.EventHandler(this.PFALForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PFALForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.XTGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox upBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox upRateBox;
        private System.Windows.Forms.TextBox downBox;
        private System.Windows.Forms.TextBox downRateBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox XTListBox;
        private System.Windows.Forms.DataGridView XTGridView1;
        private System.Windows.Forms.Button ToOBtn;
        private System.Windows.Forms.Button ToNOBtn;
        private System.Windows.Forms.Button clearPathBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox ISOBox;
        private System.Windows.Forms.TextBox customBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox NOFZLBox;
        private System.Windows.Forms.TextBox OFZLBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button getInfoBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn result;
        private System.Windows.Forms.DataGridViewTextBoxColumn avg;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxdiff;
        private System.Windows.Forms.DataGridViewTextBoxColumn val1;
        private System.Windows.Forms.DataGridViewTextBoxColumn val2;
        private System.Windows.Forms.DataGridViewTextBoxColumn val3;
        private System.Windows.Forms.DataGridViewTextBoxColumn val4;
        private System.Windows.Forms.DataGridViewTextBoxColumn val5;
        private System.Windows.Forms.Button saveFileBtn;
        private System.Windows.Forms.Button loadFileBtn;
        private System.Windows.Forms.Button rptBtn;
        private System.Windows.Forms.TextBox PureYsBox;
        private System.Windows.Forms.Button dbbtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox fileFromBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button smartRPTBtn;
    }
}