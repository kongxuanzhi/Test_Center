namespace TRESystem2011.YHP
{
    partial class yhpHistoryView
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.InameTB = new System.Windows.Forms.TextBox();
            this.allRB = new System.Windows.Forms.RadioButton();
            this.cjRB = new System.Windows.Forms.RadioButton();
            this.rkRB = new System.Windows.Forms.RadioButton();
            this.ckRB = new System.Windows.Forms.RadioButton();
            this.gjRB = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.gjRB);
            this.splitContainer1.Panel1.Controls.Add(this.ckRB);
            this.splitContainer1.Panel1.Controls.Add(this.cjRB);
            this.splitContainer1.Panel1.Controls.Add(this.rkRB);
            this.splitContainer1.Panel1.Controls.Add(this.allRB);
            this.splitContainer1.Panel1.Controls.Add(this.InameTB);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(992, 566);
            this.splitContainer1.SplitterDistance = 72;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(992, 490);
            this.dataGridView1.TabIndex = 0;
            // 
            // InameTB
            // 
            this.InameTB.Location = new System.Drawing.Point(12, 20);
            this.InameTB.Name = "InameTB";
            this.InameTB.Size = new System.Drawing.Size(100, 21);
            this.InameTB.TabIndex = 0;
            // 
            // allRB
            // 
            this.allRB.AutoSize = true;
            this.allRB.Checked = true;
            this.allRB.Location = new System.Drawing.Point(118, 21);
            this.allRB.Name = "allRB";
            this.allRB.Size = new System.Drawing.Size(47, 16);
            this.allRB.TabIndex = 1;
            this.allRB.TabStop = true;
            this.allRB.Text = "所有";
            this.allRB.UseVisualStyleBackColor = true;
            // 
            // cjRB
            // 
            this.cjRB.AutoSize = true;
            this.cjRB.Location = new System.Drawing.Point(171, 21);
            this.cjRB.Name = "cjRB";
            this.cjRB.Size = new System.Drawing.Size(47, 16);
            this.cjRB.TabIndex = 1;
            this.cjRB.Text = "创建";
            this.cjRB.UseVisualStyleBackColor = true;
            // 
            // rkRB
            // 
            this.rkRB.AutoSize = true;
            this.rkRB.Location = new System.Drawing.Point(171, 44);
            this.rkRB.Name = "rkRB";
            this.rkRB.Size = new System.Drawing.Size(47, 16);
            this.rkRB.TabIndex = 1;
            this.rkRB.Text = "入库";
            this.rkRB.UseVisualStyleBackColor = true;
            // 
            // ckRB
            // 
            this.ckRB.AutoSize = true;
            this.ckRB.Location = new System.Drawing.Point(224, 44);
            this.ckRB.Name = "ckRB";
            this.ckRB.Size = new System.Drawing.Size(47, 16);
            this.ckRB.TabIndex = 1;
            this.ckRB.Text = "出库";
            this.ckRB.UseVisualStyleBackColor = true;
            // 
            // gjRB
            // 
            this.gjRB.AutoSize = true;
            this.gjRB.Location = new System.Drawing.Point(224, 21);
            this.gjRB.Name = "gjRB";
            this.gjRB.Size = new System.Drawing.Size(47, 16);
            this.gjRB.TabIndex = 1;
            this.gjRB.Text = "改价";
            this.gjRB.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "查询";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yhpHistoryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "yhpHistoryView";
            this.Text = "历史记录查看";
            this.Load += new System.EventHandler(this.yhpView_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.RadioButton allRB;
        private System.Windows.Forms.TextBox InameTB;
        private System.Windows.Forms.RadioButton cjRB;
        private System.Windows.Forms.RadioButton gjRB;
        private System.Windows.Forms.RadioButton ckRB;
        private System.Windows.Forms.RadioButton rkRB;
        private System.Windows.Forms.Button button1;


    }
}