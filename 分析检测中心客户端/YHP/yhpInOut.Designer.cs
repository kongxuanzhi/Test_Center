namespace TRESystem2011.YHP
{
    partial class yhpInOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(yhpInOut));
            this.nameTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.InBtn = new System.Windows.Forms.Button();
            this.OutBtn = new System.Windows.Forms.Button();
            this.PriceBtn = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.remarkTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.CountNowLB = new System.Windows.Forms.Label();
            this.modeLB = new System.Windows.Forms.Label();
            this.nameLB = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.countTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gjTB = new System.Windows.Forms.TextBox();
            this.remarkTB2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.yjLB = new System.Windows.Forms.Label();
            this.nameLB2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personLB = new System.Windows.Forms.Label();
            this.personTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // nameTB
            // 
            this.nameTB.Location = new System.Drawing.Point(48, 23);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(138, 21);
            this.nameTB.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(192, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Iid,
            this.CName,
            this.IName,
            this.Spec,
            this.TotalCount,
            this.Price});
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(966, 494);
            this.dataGridView1.TabIndex = 3;
            // 
            // InBtn
            // 
            this.InBtn.Location = new System.Drawing.Point(381, 12);
            this.InBtn.Name = "InBtn";
            this.InBtn.Size = new System.Drawing.Size(75, 41);
            this.InBtn.TabIndex = 4;
            this.InBtn.Text = "入库";
            this.InBtn.UseVisualStyleBackColor = true;
            this.InBtn.Click += new System.EventHandler(this.InBtn_Click);
            // 
            // OutBtn
            // 
            this.OutBtn.Location = new System.Drawing.Point(462, 12);
            this.OutBtn.Name = "OutBtn";
            this.OutBtn.Size = new System.Drawing.Size(75, 41);
            this.OutBtn.TabIndex = 4;
            this.OutBtn.Text = "出库";
            this.OutBtn.UseVisualStyleBackColor = true;
            this.OutBtn.Click += new System.EventHandler(this.OutBtn_Click);
            // 
            // PriceBtn
            // 
            this.PriceBtn.Location = new System.Drawing.Point(543, 12);
            this.PriceBtn.Name = "PriceBtn";
            this.PriceBtn.Size = new System.Drawing.Size(75, 41);
            this.PriceBtn.TabIndex = 4;
            this.PriceBtn.Text = "价格修改";
            this.PriceBtn.UseVisualStyleBackColor = true;
            this.PriceBtn.Click += new System.EventHandler(this.PriceBtn_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.remarkTB);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.CountNowLB);
            this.panel1.Controls.Add(this.modeLB);
            this.panel1.Controls.Add(this.nameLB);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.personTB);
            this.panel1.Controls.Add(this.personLB);
            this.panel1.Controls.Add(this.countTB);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Location = new System.Drawing.Point(203, 145);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(312, 305);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            // 
            // remarkTB
            // 
            this.remarkTB.Location = new System.Drawing.Point(77, 154);
            this.remarkTB.Multiline = true;
            this.remarkTB.Name = "remarkTB";
            this.remarkTB.Size = new System.Drawing.Size(210, 70);
            this.remarkTB.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "备注";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(188, 241);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // CountNowLB
            // 
            this.CountNowLB.AutoSize = true;
            this.CountNowLB.Location = new System.Drawing.Point(167, 89);
            this.CountNowLB.Name = "CountNowLB";
            this.CountNowLB.Size = new System.Drawing.Size(0, 12);
            this.CountNowLB.TabIndex = 6;
            // 
            // modeLB
            // 
            this.modeLB.AutoSize = true;
            this.modeLB.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.modeLB.Location = new System.Drawing.Point(106, 19);
            this.modeLB.Name = "modeLB";
            this.modeLB.Size = new System.Drawing.Size(0, 12);
            this.modeLB.TabIndex = 5;
            // 
            // nameLB
            // 
            this.nameLB.AutoSize = true;
            this.nameLB.Location = new System.Drawing.Point(76, 53);
            this.nameLB.Name = "nameLB";
            this.nameLB.Size = new System.Drawing.Size(0, 12);
            this.nameLB.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "物品";
            // 
            // countTB
            // 
            this.countTB.Location = new System.Drawing.Point(77, 86);
            this.countTB.Name = "countTB";
            this.countTB.Size = new System.Drawing.Size(75, 21);
            this.countTB.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "数量";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(77, 241);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "确定";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(192, 31);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "刷新";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gjTB);
            this.panel2.Controls.Add(this.remarkTB2);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.yjLB);
            this.panel2.Controls.Add(this.nameLB2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Location = new System.Drawing.Point(280, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(312, 317);
            this.panel2.TabIndex = 10;
            this.panel2.Visible = false;
            // 
            // gjTB
            // 
            this.gjTB.Location = new System.Drawing.Point(73, 126);
            this.gjTB.Name = "gjTB";
            this.gjTB.Size = new System.Drawing.Size(113, 21);
            this.gjTB.TabIndex = 10;
            // 
            // remarkTB2
            // 
            this.remarkTB2.Location = new System.Drawing.Point(73, 167);
            this.remarkTB2.Multiline = true;
            this.remarkTB2.Name = "remarkTB2";
            this.remarkTB2.Size = new System.Drawing.Size(194, 84);
            this.remarkTB2.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "备注";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(188, 257);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 7;
            this.button5.Text = "取消";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(122, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 12);
            this.label7.TabIndex = 5;
            this.label7.Text = "价格修改";
            // 
            // yjLB
            // 
            this.yjLB.AutoSize = true;
            this.yjLB.Location = new System.Drawing.Point(76, 89);
            this.yjLB.Name = "yjLB";
            this.yjLB.Size = new System.Drawing.Size(0, 12);
            this.yjLB.TabIndex = 4;
            // 
            // nameLB2
            // 
            this.nameLB2.AutoSize = true;
            this.nameLB2.Location = new System.Drawing.Point(76, 53);
            this.nameLB2.Name = "nameLB2";
            this.nameLB2.Size = new System.Drawing.Size(0, 12);
            this.nameLB2.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(29, 12);
            this.label9.TabIndex = 3;
            this.label9.Text = "物品";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "改价";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(28, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 1;
            this.label10.Text = "原价";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(77, 257);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 0;
            this.button6.Text = "确定";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(281, 12);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 40);
            this.button7.TabIndex = 11;
            this.button7.Text = "历史记录";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Controls.Add(this.dataGridView2);
            this.panel3.Location = new System.Drawing.Point(136, 98);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 400);
            this.panel3.TabIndex = 12;
            this.panel3.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(33, 22);
            this.toolStripButton1.Text = "关闭";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 28);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(794, 369);
            this.dataGridView2.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "CName";
            this.dataGridViewTextBoxColumn1.HeaderText = "公司";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "IName";
            this.dataGridViewTextBoxColumn2.HeaderText = "物品";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Spec";
            this.dataGridViewTextBoxColumn3.HeaderText = "规格";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TotalCount";
            this.dataGridViewTextBoxColumn4.HeaderText = "库存";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TotalCount";
            this.dataGridViewTextBoxColumn5.HeaderText = "价格";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn6.HeaderText = "价格";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Iid
            // 
            this.Iid.DataPropertyName = "Iid";
            this.Iid.HeaderText = "Iid";
            this.Iid.Name = "Iid";
            this.Iid.ReadOnly = true;
            this.Iid.Visible = false;
            // 
            // CName
            // 
            this.CName.DataPropertyName = "CName";
            this.CName.HeaderText = "公司";
            this.CName.Name = "CName";
            this.CName.ReadOnly = true;
            // 
            // IName
            // 
            this.IName.DataPropertyName = "IName";
            this.IName.HeaderText = "物品";
            this.IName.Name = "IName";
            this.IName.ReadOnly = true;
            // 
            // Spec
            // 
            this.Spec.DataPropertyName = "Spec";
            this.Spec.HeaderText = "规格";
            this.Spec.Name = "Spec";
            this.Spec.ReadOnly = true;
            // 
            // TotalCount
            // 
            this.TotalCount.DataPropertyName = "TotalCount";
            this.TotalCount.HeaderText = "库存";
            this.TotalCount.Name = "TotalCount";
            this.TotalCount.ReadOnly = true;
            // 
            // Price
            // 
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "价格";
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // personLB
            // 
            this.personLB.AutoSize = true;
            this.personLB.Location = new System.Drawing.Point(28, 125);
            this.personLB.Name = "personLB";
            this.personLB.Size = new System.Drawing.Size(17, 12);
            this.personLB.TabIndex = 1;
            this.personLB.Text = "人";
            // 
            // personTB
            // 
            this.personTB.Location = new System.Drawing.Point(77, 122);
            this.personTB.Name = "personTB";
            this.personTB.Size = new System.Drawing.Size(75, 21);
            this.personTB.TabIndex = 2;
            // 
            // yhpInOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.PriceBtn);
            this.Controls.Add(this.OutBtn);
            this.Controls.Add(this.InBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dataGridView1);
            this.Name = "yhpInOut";
            this.Text = "易耗品库存管理";
            this.Load += new System.EventHandler(this.yhpInOut_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button InBtn;
        private System.Windows.Forms.Button OutBtn;
        private System.Windows.Forms.Button PriceBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label nameLB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox countTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label modeLB;
        private System.Windows.Forms.Label CountNowLB;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox remarkTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iid;
        private System.Windows.Forms.DataGridViewTextBoxColumn CName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox remarkTB2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label nameLB2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label yjLB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox gjTB;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.TextBox personTB;
        private System.Windows.Forms.Label personLB;
    }
}