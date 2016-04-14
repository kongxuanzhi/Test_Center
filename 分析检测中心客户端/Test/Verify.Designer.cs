namespace TRESystem2011.Test
{
    partial class Verify
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Verify));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.crystal_result_main = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.button1 = new System.Windows.Forms.Button();
            this.axFramerControl1 = new AxDSOFramer.AxFramerControl();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.splitContainer1.Panel2.AllowDrop = true;
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(1306, 548);
            this.splitContainer1.SplitterDistance = 498;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.crystal_result_main);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.axFramerControl1);
            this.splitContainer2.Size = new System.Drawing.Size(1306, 498);
            this.splitContainer2.SplitterDistance = 719;
            this.splitContainer2.TabIndex = 0;
            // 
            // crystal_result_main
            // 
            this.crystal_result_main.ActiveViewIndex = -1;
            this.crystal_result_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystal_result_main.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystal_result_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystal_result_main.Location = new System.Drawing.Point(0, 0);
            this.crystal_result_main.Name = "crystal_result_main";
            this.crystal_result_main.ShowCloseButton = false;
            this.crystal_result_main.ShowCopyButton = false;
            this.crystal_result_main.ShowExportButton = false;
            this.crystal_result_main.ShowGroupTreeButton = false;
            this.crystal_result_main.ShowLogo = false;
            this.crystal_result_main.ShowParameterPanelButton = false;
            this.crystal_result_main.ShowPrintButton = false;
            this.crystal_result_main.ShowRefreshButton = false;
            this.crystal_result_main.ShowTextSearchButton = false;
            this.crystal_result_main.ShowZoomButton = false;
            this.crystal_result_main.Size = new System.Drawing.Size(719, 498);
            this.crystal_result_main.TabIndex = 0;
            this.crystal_result_main.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("SimSun", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(1306, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "提交审核";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // axFramerControl1
            // 
            this.axFramerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axFramerControl1.Enabled = true;
            this.axFramerControl1.Location = new System.Drawing.Point(0, 0);
            this.axFramerControl1.Name = "axFramerControl1";
            this.axFramerControl1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axFramerControl1.OcxState")));
            this.axFramerControl1.Size = new System.Drawing.Size(583, 498);
            this.axFramerControl1.TabIndex = 0;
            // 
            // Verify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1306, 548);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Verify";
            this.Text = "结果审核";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Verify_FormClosed);
            this.Load += new System.EventHandler(this.Verify_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axFramerControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystal_result_main;
        private AxDSOFramer.AxFramerControl axFramerControl1;
        private System.Windows.Forms.Button button1;
    }
}