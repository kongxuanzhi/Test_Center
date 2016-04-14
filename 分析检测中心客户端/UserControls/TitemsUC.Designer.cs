namespace TRESystem2011.UserControls
{
    partial class TitemsUC
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.SiTV = new System.Windows.Forms.TreeView();
            this.SiDV = new System.Windows.Forms.DataGridView();
            this.Titem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tunit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tstandard = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tvalue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.SiDV)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SiTV
            // 
            this.SiTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SiTV.Location = new System.Drawing.Point(0, 0);
            this.SiTV.Name = "SiTV";
            this.SiTV.Size = new System.Drawing.Size(199, 470);
            this.SiTV.TabIndex = 235;
            this.SiTV.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.SiTV_NodeMouseDoubleClick);
            // 
            // SiDV
            // 
            this.SiDV.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SiDV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SiDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SiDV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Titem,
            this.Tunit,
            this.Tstandard,
            this.Tvalue,
            this.Column31});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SiDV.DefaultCellStyle = dataGridViewCellStyle2;
            this.SiDV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SiDV.Location = new System.Drawing.Point(0, 0);
            this.SiDV.Name = "SiDV";
            this.SiDV.RowTemplate.Height = 23;
            this.SiDV.Size = new System.Drawing.Size(397, 470);
            this.SiDV.TabIndex = 234;
            // 
            // Titem
            // 
            this.Titem.DataPropertyName = "Titem";
            this.Titem.HeaderText = "检测项目";
            this.Titem.Name = "Titem";
            this.Titem.Width = 90;
            // 
            // Tunit
            // 
            this.Tunit.DataPropertyName = "Tunit";
            this.Tunit.HeaderText = "单位";
            this.Tunit.Name = "Tunit";
            this.Tunit.Width = 60;
            // 
            // Tstandard
            // 
            this.Tstandard.DataPropertyName = "Tstandard";
            this.Tstandard.HeaderText = "标准规定值";
            this.Tstandard.Name = "Tstandard";
            this.Tstandard.Width = 90;
            // 
            // Tvalue
            // 
            this.Tvalue.DataPropertyName = "Tvalue";
            this.Tvalue.HeaderText = "检测结果";
            this.Tvalue.Name = "Tvalue";
            this.Tvalue.Width = 90;
            // 
            // Column31
            // 
            this.Column31.HeaderText = "判定";
            this.Column31.Name = "Column31";
            this.Column31.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.SiTV);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.SiDV);
            this.splitContainer1.Size = new System.Drawing.Size(600, 470);
            this.splitContainer1.SplitterDistance = 199;
            this.splitContainer1.TabIndex = 236;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "检测项目";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 90;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "单位";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 55;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "标准规定值";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 90;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "检测结果";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 90;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "判定";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // TitemsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TitemsUC";
            this.Size = new System.Drawing.Size(600, 470);
            ((System.ComponentModel.ISupportInitialize)(this.SiDV)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView SiTV;
        public System.Windows.Forms.DataGridView SiDV;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Titem;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tunit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tstandard;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tvalue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column31;
    }
}
