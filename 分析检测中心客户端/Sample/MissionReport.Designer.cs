namespace TRESystem2011.Sample
{
    partial class MissionReport
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
            this.crystalReport_Mission = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crystalReport_Mission
            // 
            this.crystalReport_Mission.ActiveViewIndex = -1;
            this.crystalReport_Mission.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReport_Mission.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReport_Mission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReport_Mission.Location = new System.Drawing.Point(0, 0);
            this.crystalReport_Mission.Name = "crystalReport_Mission";
            this.crystalReport_Mission.Size = new System.Drawing.Size(976, 561);
            this.crystalReport_Mission.TabIndex = 0;
            // 
            // MissionReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 561);
            this.Controls.Add(this.crystalReport_Mission);
            this.Name = "MissionReport";
            this.Text = "MissionReport";
            this.Load += new System.EventHandler(this.MissionReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReport_Mission;
    }
}