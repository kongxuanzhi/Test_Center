﻿namespace TRESystem2011.YHP
{
    partial class yhpItemAdd
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
            this.label1 = new System.Windows.Forms.Label();
            this.CNameLB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InameTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ISpecTB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.IPriceTB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TotalCountTB = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "供应商";
            // 
            // CNameLB
            // 
            this.CNameLB.AutoSize = true;
            this.CNameLB.Location = new System.Drawing.Point(120, 27);
            this.CNameLB.Name = "CNameLB";
            this.CNameLB.Size = new System.Drawing.Size(53, 12);
            this.CNameLB.TabIndex = 1;
            this.CNameLB.Text = "供应商名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "物品名";
            // 
            // InameTB
            // 
            this.InameTB.Location = new System.Drawing.Point(122, 74);
            this.InameTB.Name = "InameTB";
            this.InameTB.Size = new System.Drawing.Size(179, 21);
            this.InameTB.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "规格";
            // 
            // ISpecTB
            // 
            this.ISpecTB.Location = new System.Drawing.Point(122, 121);
            this.ISpecTB.Name = "ISpecTB";
            this.ISpecTB.Size = new System.Drawing.Size(179, 21);
            this.ISpecTB.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "价格(元)";
            // 
            // IPriceTB
            // 
            this.IPriceTB.Location = new System.Drawing.Point(122, 171);
            this.IPriceTB.Name = "IPriceTB";
            this.IPriceTB.Size = new System.Drawing.Size(179, 21);
            this.IPriceTB.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(133, 260);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "确定添加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 217);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "初始库存";
            // 
            // TotalCountTB
            // 
            this.TotalCountTB.Location = new System.Drawing.Point(122, 214);
            this.TotalCountTB.Name = "TotalCountTB";
            this.TotalCountTB.Size = new System.Drawing.Size(179, 21);
            this.TotalCountTB.TabIndex = 5;
            this.TotalCountTB.Text = "0";
            // 
            // yhpItemAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 325);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TotalCountTB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.IPriceTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ISpecTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InameTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CNameLB);
            this.Controls.Add(this.label1);
            this.Name = "yhpItemAdd";
            this.Text = "添加物品";
            this.Load += new System.EventHandler(this.yhpItemAdd_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CNameLB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InameTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ISpecTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IPriceTB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TotalCountTB;
    }
}