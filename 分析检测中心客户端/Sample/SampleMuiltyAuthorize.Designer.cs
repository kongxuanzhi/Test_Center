namespace TRESystem2011.Sample
{
    partial class SampleMuiltyAuthorize
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
            this.button1 = new System.Windows.Forms.Button();
            this.itemCB = new System.Windows.Forms.CheckBox();
            this.costCB = new System.Windows.Forms.CheckBox();
            this.hyCB = new System.Windows.Forms.CheckBox();
            this.jyCB = new System.Windows.Forms.CheckBox();
            this.resultCB = new System.Windows.Forms.CheckBox();
            this.infoCB = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.searchBar1 = new TRESystem2011.UserControls.SearchBar();
            this.searchGridView1 = new TRESystem2011.UserControls.SearchGridView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.itemCB);
            this.splitContainer1.Panel1.Controls.Add(this.costCB);
            this.splitContainer1.Panel1.Controls.Add(this.hyCB);
            this.splitContainer1.Panel1.Controls.Add(this.jyCB);
            this.splitContainer1.Panel1.Controls.Add(this.resultCB);
            this.splitContainer1.Panel1.Controls.Add(this.infoCB);
            this.splitContainer1.Panel1.Controls.Add(this.searchBar1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.searchGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(992, 566);
            this.splitContainer1.SplitterDistance = 126;
            this.splitContainer1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(96, 77);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 38);
            this.button1.TabIndex = 3;
            this.button1.Text = "授权修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // itemCB
            // 
            this.itemCB.AutoSize = true;
            this.itemCB.Location = new System.Drawing.Point(12, 99);
            this.itemCB.Name = "itemCB";
            this.itemCB.Size = new System.Drawing.Size(72, 16);
            this.itemCB.TabIndex = 2;
            this.itemCB.Text = "检测项目";
            this.itemCB.UseVisualStyleBackColor = true;
            // 
            // costCB
            // 
            this.costCB.AutoSize = true;
            this.costCB.Location = new System.Drawing.Point(12, 77);
            this.costCB.Name = "costCB";
            this.costCB.Size = new System.Drawing.Size(72, 16);
            this.costCB.TabIndex = 2;
            this.costCB.Text = "检测费用";
            this.costCB.UseVisualStyleBackColor = true;
            // 
            // hyCB
            // 
            this.hyCB.AutoSize = true;
            this.hyCB.Location = new System.Drawing.Point(12, 55);
            this.hyCB.Name = "hyCB";
            this.hyCB.Size = new System.Drawing.Size(72, 16);
            this.hyCB.TabIndex = 2;
            this.hyCB.Text = "合约时间";
            this.hyCB.UseVisualStyleBackColor = true;
            // 
            // jyCB
            // 
            this.jyCB.AutoSize = true;
            this.jyCB.Location = new System.Drawing.Point(12, 33);
            this.jyCB.Name = "jyCB";
            this.jyCB.Size = new System.Drawing.Size(72, 16);
            this.jyCB.TabIndex = 2;
            this.jyCB.Text = "进样时间";
            this.jyCB.UseVisualStyleBackColor = true;
            // 
            // resultCB
            // 
            this.resultCB.AutoSize = true;
            this.resultCB.Location = new System.Drawing.Point(96, 11);
            this.resultCB.Name = "resultCB";
            this.resultCB.Size = new System.Drawing.Size(72, 16);
            this.resultCB.TabIndex = 2;
            this.resultCB.Text = "检测结果";
            this.resultCB.UseVisualStyleBackColor = true;
            // 
            // infoCB
            // 
            this.infoCB.AutoSize = true;
            this.infoCB.Location = new System.Drawing.Point(12, 11);
            this.infoCB.Name = "infoCB";
            this.infoCB.Size = new System.Drawing.Size(72, 16);
            this.infoCB.TabIndex = 2;
            this.infoCB.Text = "基本信息";
            this.infoCB.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(96, 33);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 38);
            this.button2.TabIndex = 4;
            this.button2.Text = "搜索";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchBar1
            // 
            this.searchBar1.Location = new System.Drawing.Point(192, 0);
            this.searchBar1.Name = "searchBar1";
            this.searchBar1.Size = new System.Drawing.Size(800, 127);
            this.searchBar1.TabIndex = 1;
            // 
            // searchGridView1
            // 
            this.searchGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchGridView1.Location = new System.Drawing.Point(0, 0);
            this.searchGridView1.Name = "searchGridView1";
            this.searchGridView1.Size = new System.Drawing.Size(992, 436);
            this.searchGridView1.TabIndex = 0;
            // 
            // SampleMuiltyAuthorize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SampleMuiltyAuthorize";
            this.Text = "样品授权修改";
            this.Load += new System.EventHandler(this.SampleMuiltyAuthorize_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox itemCB;
        private System.Windows.Forms.CheckBox costCB;
        private System.Windows.Forms.CheckBox hyCB;
        private System.Windows.Forms.CheckBox jyCB;
        private System.Windows.Forms.CheckBox infoCB;
        private TRESystem2011.UserControls.SearchBar searchBar1;
        private System.Windows.Forms.CheckBox resultCB;
        private System.Windows.Forms.Button button1;
        private TRESystem2011.UserControls.SearchGridView searchGridView1;
        private System.Windows.Forms.Button button2;
    }
}