namespace ICPTOOLS_DONET
{
    partial class RPTForm
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
            this.pathBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.XTListBox = new System.Windows.Forms.ListBox();
            this.clearPathBtn = new System.Windows.Forms.Button();
            this.dbbtn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.SmartCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(205, 22);
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
            this.button2.Text = "解析报告";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            // clearPathBtn
            // 
            this.clearPathBtn.Location = new System.Drawing.Point(124, 18);
            this.clearPathBtn.Name = "clearPathBtn";
            this.clearPathBtn.Size = new System.Drawing.Size(75, 27);
            this.clearPathBtn.TabIndex = 14;
            this.clearPathBtn.Text = "清空";
            this.clearPathBtn.UseVisualStyleBackColor = true;
            this.clearPathBtn.Click += new System.EventHandler(this.clearPathBtn_Click);
            // 
            // dbbtn
            // 
            this.dbbtn.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dbbtn.ForeColor = System.Drawing.Color.Red;
            this.dbbtn.Location = new System.Drawing.Point(749, 48);
            this.dbbtn.Name = "dbbtn";
            this.dbbtn.Size = new System.Drawing.Size(75, 48);
            this.dbbtn.TabIndex = 20;
            this.dbbtn.Text = "写入数据库";
            this.dbbtn.UseVisualStyleBackColor = true;
            this.dbbtn.Click += new System.EventHandler(this.dbbtn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(155, 114);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(672, 436);
            this.dataGridView1.TabIndex = 21;
            // 
            // SmartCB
            // 
            this.SmartCB.AutoSize = true;
            this.SmartCB.Location = new System.Drawing.Point(623, 64);
            this.SmartCB.Name = "SmartCB";
            this.SmartCB.Size = new System.Drawing.Size(120, 16);
            this.SmartCB.TabIndex = 22;
            this.SmartCB.Text = "智能添加TRE/TREO";
            this.SmartCB.UseVisualStyleBackColor = true;
            // 
            // RPTForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 566);
            this.Controls.Add(this.SmartCB);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dbbtn);
            this.Controls.Add(this.clearPathBtn);
            this.Controls.Add(this.XTListBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pathBox);
            this.Name = "RPTForm";
            this.Text = "解析报告";
            this.Load += new System.EventHandler(this.RPTForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox XTListBox;
        private System.Windows.Forms.Button clearPathBtn;
        private System.Windows.Forms.Button dbbtn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.CheckBox SmartCB;
    }
}