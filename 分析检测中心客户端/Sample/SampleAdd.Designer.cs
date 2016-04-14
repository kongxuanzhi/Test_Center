namespace TRESystem2011.Sample
{
    partial class SampleAdd
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
            this.titemsUC1 = new TRESystem2011.UserControls.TitemsUC();
            this.sampleUC1 = new TRESystem2011.UserControls.SampleUC();
            this.label1 = new System.Windows.Forms.Label();
            this.lastSnoLB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CountLB = new System.Windows.Forms.Label();
            this.LastSorginalLB = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.InnerNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定添加样品";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // titemsUC1
            // 
            this.titemsUC1.Location = new System.Drawing.Point(523, 12);
            this.titemsUC1.Name = "titemsUC1";
            this.titemsUC1.Size = new System.Drawing.Size(600, 574);
            this.titemsUC1.TabIndex = 2;
            // 
            // sampleUC1
            // 
            this.sampleUC1.Location = new System.Drawing.Point(1, 114);
            this.sampleUC1.Name = "sampleUC1";
            this.sampleUC1.Size = new System.Drawing.Size(516, 472);
            this.sampleUC1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "任务编号：";
            // 
            // lastSnoLB
            // 
            this.lastSnoLB.AutoSize = true;
            this.lastSnoLB.Location = new System.Drawing.Point(92, 82);
            this.lastSnoLB.Name = "lastSnoLB";
            this.lastSnoLB.Size = new System.Drawing.Size(17, 12);
            this.lastSnoLB.TabIndex = 4;
            this.lastSnoLB.Text = "无";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "已录样品数量：";
            // 
            // CountLB
            // 
            this.CountLB.AutoSize = true;
            this.CountLB.ForeColor = System.Drawing.Color.Red;
            this.CountLB.Location = new System.Drawing.Point(183, 8);
            this.CountLB.Name = "CountLB";
            this.CountLB.Size = new System.Drawing.Size(0, 12);
            this.CountLB.TabIndex = 6;
            // 
            // LastSorginalLB
            // 
            this.LastSorginalLB.AutoSize = true;
            this.LastSorginalLB.Location = new System.Drawing.Point(272, 12);
            this.LastSorginalLB.MaximumSize = new System.Drawing.Size(250, 0);
            this.LastSorginalLB.Name = "LastSorginalLB";
            this.LastSorginalLB.Size = new System.Drawing.Size(17, 12);
            this.LastSorginalLB.TabIndex = 8;
            this.LastSorginalLB.Text = "无";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(208, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "原样编号：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "试样编号：";
            // 
            // InnerNo
            // 
            this.InnerNo.AutoSize = true;
            this.InnerNo.Location = new System.Drawing.Point(275, 69);
            this.InnerNo.MaximumSize = new System.Drawing.Size(250, 0);
            this.InnerNo.Name = "InnerNo";
            this.InnerNo.Size = new System.Drawing.Size(17, 12);
            this.InnerNo.TabIndex = 10;
            this.InnerNo.Text = "无";
            // 
            // SampleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1128, 584);
            this.Controls.Add(this.InnerNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LastSorginalLB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CountLB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lastSnoLB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.titemsUC1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.sampleUC1);
            this.Name = "SampleAdd";
            this.Text = "新增样品";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TRESystem2011.UserControls.SampleUC sampleUC1;
        private System.Windows.Forms.Button button1;
        private TRESystem2011.UserControls.TitemsUC titemsUC1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastSnoLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CountLB;
        private System.Windows.Forms.Label LastSorginalLB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label InnerNo;
    }
}