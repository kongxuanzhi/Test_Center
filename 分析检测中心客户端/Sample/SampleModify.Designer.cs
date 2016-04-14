namespace TRESystem2011.Sample
{
    partial class SampleModify
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
            this.infolabel = new System.Windows.Forms.Label();
            this.jylabel = new System.Windows.Forms.Label();
            this.hylabel = new System.Windows.Forms.Label();
            this.costlabel = new System.Windows.Forms.Label();
            this.Titemslabel = new System.Windows.Forms.Label();
            this.titemsUC1 = new TRESystem2011.UserControls.TitemsUC();
            this.sampleUC1 = new TRESystem2011.UserControls.SampleUC();
            this.label2 = new System.Windows.Forms.Label();
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
            this.button1.Text = "确定修改提交";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "当前修改的样品：";
            // 
            // SnoLB
            // 
            this.SnoLB.AutoSize = true;
            this.SnoLB.ForeColor = System.Drawing.Color.Blue;
            this.SnoLB.Location = new System.Drawing.Point(235, 24);
            this.SnoLB.Name = "SnoLB";
            this.SnoLB.Size = new System.Drawing.Size(0, 12);
            this.SnoLB.TabIndex = 4;
            // 
            // infolabel
            // 
            this.infolabel.AutoSize = true;
            this.infolabel.ForeColor = System.Drawing.Color.Red;
            this.infolabel.Location = new System.Drawing.Point(211, 53);
            this.infolabel.Name = "infolabel";
            this.infolabel.Size = new System.Drawing.Size(53, 12);
            this.infolabel.TabIndex = 5;
            this.infolabel.Text = "样品信息";
            // 
            // jylabel
            // 
            this.jylabel.AutoSize = true;
            this.jylabel.ForeColor = System.Drawing.Color.Red;
            this.jylabel.Location = new System.Drawing.Point(270, 53);
            this.jylabel.Name = "jylabel";
            this.jylabel.Size = new System.Drawing.Size(53, 12);
            this.jylabel.TabIndex = 5;
            this.jylabel.Text = "进样时间";
            // 
            // hylabel
            // 
            this.hylabel.AutoSize = true;
            this.hylabel.ForeColor = System.Drawing.Color.Red;
            this.hylabel.Location = new System.Drawing.Point(329, 53);
            this.hylabel.Name = "hylabel";
            this.hylabel.Size = new System.Drawing.Size(53, 12);
            this.hylabel.TabIndex = 5;
            this.hylabel.Text = "合约时间";
            // 
            // costlabel
            // 
            this.costlabel.AutoSize = true;
            this.costlabel.ForeColor = System.Drawing.Color.Red;
            this.costlabel.Location = new System.Drawing.Point(388, 53);
            this.costlabel.Name = "costlabel";
            this.costlabel.Size = new System.Drawing.Size(53, 12);
            this.costlabel.TabIndex = 5;
            this.costlabel.Text = "样品价格";
            // 
            // Titemslabel
            // 
            this.Titemslabel.AutoSize = true;
            this.Titemslabel.ForeColor = System.Drawing.Color.Red;
            this.Titemslabel.Location = new System.Drawing.Point(447, 53);
            this.Titemslabel.Name = "Titemslabel";
            this.Titemslabel.Size = new System.Drawing.Size(53, 12);
            this.Titemslabel.TabIndex = 5;
            this.Titemslabel.Text = "检测项目";
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "可修改项目：";
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
            // SampleModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 562);
            this.Controls.Add(this.jylabel);
            this.Controls.Add(this.costlabel);
            this.Controls.Add(this.Titemslabel);
            this.Controls.Add(this.hylabel);
            this.Controls.Add(this.infolabel);
            this.Controls.Add(this.SstatusLB);
            this.Controls.Add(this.SnoLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titemsUC1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sampleUC1);
            this.Name = "SampleModify";
            this.Text = "样品修改";
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
        private System.Windows.Forms.Label infolabel;
        private System.Windows.Forms.Label jylabel;
        private System.Windows.Forms.Label hylabel;
        private System.Windows.Forms.Label costlabel;
        private System.Windows.Forms.Label Titemslabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SstatusLB;

    }
}