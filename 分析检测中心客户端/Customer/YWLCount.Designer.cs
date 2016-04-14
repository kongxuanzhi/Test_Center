namespace TRESystem2011.Customer
{
    partial class YWLCount
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
            this.label1 = new System.Windows.Forms.Label();
            this.nameCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.startDTP = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.endDTP = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.infoTB = new System.Windows.Forms.TextBox();
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
            this.splitContainer1.Panel1.Controls.Add(this.infoTB);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.endDTP);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.startDTP);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.nameCB);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.searchGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(992, 566);
            this.splitContainer1.SplitterDistance = 84;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名";
            // 
            // nameCB
            // 
            this.nameCB.FormattingEnabled = true;
            this.nameCB.Location = new System.Drawing.Point(56, 17);
            this.nameCB.Name = "nameCB";
            this.nameCB.Size = new System.Drawing.Size(111, 20);
            this.nameCB.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(196, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "从";
            // 
            // startDTP
            // 
            this.startDTP.Location = new System.Drawing.Point(240, 11);
            this.startDTP.Name = "startDTP";
            this.startDTP.Size = new System.Drawing.Size(111, 21);
            this.startDTP.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(196, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "到";
            // 
            // endDTP
            // 
            this.endDTP.Location = new System.Drawing.Point(240, 38);
            this.endDTP.Name = "endDTP";
            this.endDTP.Size = new System.Drawing.Size(111, 21);
            this.endDTP.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 45);
            this.button1.TabIndex = 4;
            this.button1.Text = "统计";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // infoTB
            // 
            this.infoTB.BackColor = System.Drawing.Color.White;
            this.infoTB.Location = new System.Drawing.Point(475, 4);
            this.infoTB.Multiline = true;
            this.infoTB.Name = "infoTB";
            this.infoTB.ReadOnly = true;
            this.infoTB.Size = new System.Drawing.Size(333, 77);
            this.infoTB.TabIndex = 5;
            // 
            // searchGridView1
            // 
            this.searchGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchGridView1.Location = new System.Drawing.Point(0, 0);
            this.searchGridView1.Name = "searchGridView1";
            this.searchGridView1.Size = new System.Drawing.Size(992, 478);
            this.searchGridView1.TabIndex = 0;
            // 
            // YWLCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 566);
            this.Controls.Add(this.splitContainer1);
            this.Name = "YWLCount";
            this.Text = "业务量统计";
            this.Load += new System.EventHandler(this.YWLCount_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nameCB;
        private System.Windows.Forms.DateTimePicker endDTP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker startDTP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private TRESystem2011.UserControls.SearchGridView searchGridView1;
        private System.Windows.Forms.TextBox infoTB;
    }
}