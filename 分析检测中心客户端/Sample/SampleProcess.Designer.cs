﻿namespace TRESystem2011.Sample
{
    partial class SampleProcess
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.searchBar1 = new TRESystem2011.UserControls.SearchBar();
            this.searchGridView1 = new TRESystem2011.UserControls.SearchGridView();
            this.printmission = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.printmission);
            this.splitContainer1.Panel1.Controls.Add(this.button4);
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.button2);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.searchBar1);
            this.splitContainer1.Size = new System.Drawing.Size(1275, 127);
            this.splitContainer1.SplitterDistance = 249;
            this.splitContainer1.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Location = new System.Drawing.Point(104, 91);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 30);
            this.button4.TabIndex = 3;
            this.button4.Text = "导出财务报表";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Red;
            this.button3.Location = new System.Drawing.Point(3, 91);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 30);
            this.button3.TabIndex = 2;
            this.button3.Text = "导出检测结果";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(3, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(188, 30);
            this.button2.TabIndex = 1;
            this.button2.Text = "查看详情";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 50);
            this.button1.TabIndex = 0;
            this.button1.Text = "搜索";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // searchBar1
            // 
            this.searchBar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchBar1.Location = new System.Drawing.Point(0, 0);
            this.searchBar1.Name = "searchBar1";
            this.searchBar1.Size = new System.Drawing.Size(1022, 127);
            this.searchBar1.TabIndex = 0;
            this.searchBar1.Load += new System.EventHandler(this.searchBar1_Load);
            // 
            // searchGridView1
            // 
            this.searchGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchGridView1.Location = new System.Drawing.Point(0, 127);
            this.searchGridView1.Name = "searchGridView1";
            this.searchGridView1.Size = new System.Drawing.Size(1275, 439);
            this.searchGridView1.TabIndex = 1;
            // 
            // printmission
            // 
            this.printmission.Location = new System.Drawing.Point(197, 3);
            this.printmission.Name = "printmission";
            this.printmission.Size = new System.Drawing.Size(49, 124);
            this.printmission.TabIndex = 4;
            this.printmission.Text = "显示任务单";
            this.printmission.UseVisualStyleBackColor = true;
            this.printmission.Click += new System.EventHandler(this.printmission_Click);
            // 
            // SampleProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 566);
            this.Controls.Add(this.searchGridView1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SampleProcess";
            this.Text = "样品进度查看";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button button1;
        private TRESystem2011.UserControls.SearchBar searchBar1;
        private TRESystem2011.UserControls.SearchGridView searchGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button printmission;
    }
}