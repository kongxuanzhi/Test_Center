﻿namespace TRESystem2011.Sample
{
    partial class SampleView
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SnoLB = new System.Windows.Forms.Label();
            this.titemsUC1 = new TRESystem2011.UserControls.TitemsUC();
            this.sampleUC1 = new TRESystem2011.UserControls.SampleUC();
            this.label3 = new System.Windows.Forms.Label();
            this.SstatusLB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "退出";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前样品：";
            // 
            // SnoLB
            // 
            this.SnoLB.AutoSize = true;
            this.SnoLB.ForeColor = System.Drawing.Color.Blue;
            this.SnoLB.Location = new System.Drawing.Point(205, 24);
            this.SnoLB.Name = "SnoLB";
            this.SnoLB.Size = new System.Drawing.Size(0, 12);
            this.SnoLB.TabIndex = 4;
            // 
            // titemsUC1
            // 
            this.titemsUC1.Location = new System.Drawing.Point(523, 12);
            this.titemsUC1.Name = "titemsUC1";
            this.titemsUC1.Size = new System.Drawing.Size(600, 544);
            this.titemsUC1.TabIndex = 2;
            // 
            // sampleUC1
            // 
            this.sampleUC1.Location = new System.Drawing.Point(1, 84);
            this.sampleUC1.Name = "sampleUC1";
            this.sampleUC1.Size = new System.Drawing.Size(516, 472);
            this.sampleUC1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(329, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "当前状态";
            // 
            // SstatusLB
            // 
            this.SstatusLB.AutoSize = true;
            this.SstatusLB.ForeColor = System.Drawing.Color.Blue;
            this.SstatusLB.Location = new System.Drawing.Point(398, 24);
            this.SstatusLB.Name = "SstatusLB";
            this.SstatusLB.Size = new System.Drawing.Size(0, 12);
            this.SstatusLB.TabIndex = 4;
            // 
            // SampleView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 562);
            this.Controls.Add(this.SstatusLB);
            this.Controls.Add(this.SnoLB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titemsUC1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sampleUC1);
            this.Name = "SampleView";
            this.Text = "样品详情查看";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TRESystem2011.UserControls.SampleUC sampleUC1;
        private System.Windows.Forms.Button button1;
        private TRESystem2011.UserControls.TitemsUC titemsUC1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SnoLB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SstatusLB;

    }
}