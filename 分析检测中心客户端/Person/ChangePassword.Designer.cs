namespace TRESystem2011.Person
{
    partial class ChangePassword
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.oldpwdTB = new System.Windows.Forms.TextBox();
            this.newpwdTB1 = new System.Windows.Forms.TextBox();
            this.newpwdTB2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nameTB = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "原密码";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "新密码";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "重复新密码";
            // 
            // oldpwdTB
            // 
            this.oldpwdTB.Location = new System.Drawing.Point(117, 66);
            this.oldpwdTB.Name = "oldpwdTB";
            this.oldpwdTB.Size = new System.Drawing.Size(142, 21);
            this.oldpwdTB.TabIndex = 1;
            this.oldpwdTB.UseSystemPasswordChar = true;
            // 
            // newpwdTB1
            // 
            this.newpwdTB1.Location = new System.Drawing.Point(117, 102);
            this.newpwdTB1.Name = "newpwdTB1";
            this.newpwdTB1.Size = new System.Drawing.Size(142, 21);
            this.newpwdTB1.TabIndex = 2;
            this.newpwdTB1.UseSystemPasswordChar = true;
            // 
            // newpwdTB2
            // 
            this.newpwdTB2.Location = new System.Drawing.Point(117, 142);
            this.newpwdTB2.Name = "newpwdTB2";
            this.newpwdTB2.Size = new System.Drawing.Size(142, 21);
            this.newpwdTB2.TabIndex = 3;
            this.newpwdTB2.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 201);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "确认修改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "当前用户";
            // 
            // nameTB
            // 
            this.nameTB.AutoSize = true;
            this.nameTB.Location = new System.Drawing.Point(117, 25);
            this.nameTB.Name = "nameTB";
            this.nameTB.Size = new System.Drawing.Size(0, 12);
            this.nameTB.TabIndex = 5;
            // 
            // ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 266);
            this.Controls.Add(this.nameTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.newpwdTB2);
            this.Controls.Add(this.newpwdTB1);
            this.Controls.Add(this.oldpwdTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ChangePassword";
            this.Text = "密码修改";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox oldpwdTB;
        private System.Windows.Forms.TextBox newpwdTB1;
        private System.Windows.Forms.TextBox newpwdTB2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label nameTB;
    }
}