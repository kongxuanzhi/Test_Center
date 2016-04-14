namespace TRESystem2011.Items
{
    partial class ProductManage
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
            this.kindLB = new System.Windows.Forms.ListBox();
            this.ProductLB = new System.Windows.Forms.ListBox();
            this.PtypeLB = new System.Windows.Forms.ListBox();
            this.ItemsGV = new System.Windows.Forms.DataGridView();
            this.ProductItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ItemValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PnameTB = new System.Windows.Forms.TextBox();
            this.addProductBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.delProductBtn = new System.Windows.Forms.Button();
            this.PtypeTB = new System.Windows.Forms.TextBox();
            this.addPtypeBtn = new System.Windows.Forms.Button();
            this.delPtypeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PclassTB = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGV)).BeginInit();
            this.SuspendLayout();
            // 
            // kindLB
            // 
            this.kindLB.DisplayMember = "ProductKind";
            this.kindLB.FormattingEnabled = true;
            this.kindLB.ItemHeight = 12;
            this.kindLB.Location = new System.Drawing.Point(3, 109);
            this.kindLB.Name = "kindLB";
            this.kindLB.Size = new System.Drawing.Size(86, 448);
            this.kindLB.TabIndex = 0;
            this.kindLB.ValueMember = "ProductKind";
            this.kindLB.SelectedIndexChanged += new System.EventHandler(this.kindLB_SelectedIndexChanged);
            // 
            // ProductLB
            // 
            this.ProductLB.FormattingEnabled = true;
            this.ProductLB.ItemHeight = 12;
            this.ProductLB.Location = new System.Drawing.Point(95, 109);
            this.ProductLB.Name = "ProductLB";
            this.ProductLB.Size = new System.Drawing.Size(154, 448);
            this.ProductLB.TabIndex = 1;
            this.ProductLB.SelectedIndexChanged += new System.EventHandler(this.ProductLB_SelectedIndexChanged);
            // 
            // PtypeLB
            // 
            this.PtypeLB.DisplayMember = "ProductItem";
            this.PtypeLB.FormattingEnabled = true;
            this.PtypeLB.ItemHeight = 12;
            this.PtypeLB.Location = new System.Drawing.Point(265, 109);
            this.PtypeLB.Name = "PtypeLB";
            this.PtypeLB.Size = new System.Drawing.Size(152, 448);
            this.PtypeLB.TabIndex = 1;
            this.PtypeLB.ValueMember = "ProductItem";
            this.PtypeLB.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ItemLB_MouseDoubleClick);
            // 
            // ItemsGV
            // 
            this.ItemsGV.AllowUserToResizeRows = false;
            this.ItemsGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ItemsGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductItem,
            this.ItemUnit,
            this.ItemValue});
            this.ItemsGV.Location = new System.Drawing.Point(423, 5);
            this.ItemsGV.Name = "ItemsGV";
            this.ItemsGV.RowTemplate.Height = 23;
            this.ItemsGV.Size = new System.Drawing.Size(349, 552);
            this.ItemsGV.TabIndex = 2;
            // 
            // ProductItem
            // 
            this.ProductItem.DataPropertyName = "ProductItem";
            this.ProductItem.HeaderText = "检测项目";
            this.ProductItem.Name = "ProductItem";
            // 
            // ItemUnit
            // 
            this.ItemUnit.DataPropertyName = "ItemUnit";
            this.ItemUnit.HeaderText = "单位";
            this.ItemUnit.Name = "ItemUnit";
            this.ItemUnit.Width = 80;
            // 
            // ItemValue
            // 
            this.ItemValue.DataPropertyName = "ItemValue";
            this.ItemValue.HeaderText = "默认值";
            this.ItemValue.Name = "ItemValue";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "大类别";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "产品";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "产品子分类";
            // 
            // PnameTB
            // 
            this.PnameTB.Location = new System.Drawing.Point(145, 12);
            this.PnameTB.Name = "PnameTB";
            this.PnameTB.Size = new System.Drawing.Size(104, 21);
            this.PnameTB.TabIndex = 5;
            // 
            // addProductBtn
            // 
            this.addProductBtn.Location = new System.Drawing.Point(102, 39);
            this.addProductBtn.Name = "addProductBtn";
            this.addProductBtn.Size = new System.Drawing.Size(52, 23);
            this.addProductBtn.TabIndex = 6;
            this.addProductBtn.Text = "新增";
            this.addProductBtn.UseVisualStyleBackColor = true;
            this.addProductBtn.Click += new System.EventHandler(this.addProductBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "产品名";
            // 
            // delProductBtn
            // 
            this.delProductBtn.Location = new System.Drawing.Point(178, 39);
            this.delProductBtn.Name = "delProductBtn";
            this.delProductBtn.Size = new System.Drawing.Size(52, 23);
            this.delProductBtn.TabIndex = 6;
            this.delProductBtn.Text = "删除";
            this.delProductBtn.UseVisualStyleBackColor = true;
            this.delProductBtn.Click += new System.EventHandler(this.delProductBtn_Click);
            // 
            // PtypeTB
            // 
            this.PtypeTB.Location = new System.Drawing.Point(837, 15);
            this.PtypeTB.Name = "PtypeTB";
            this.PtypeTB.Size = new System.Drawing.Size(104, 21);
            this.PtypeTB.TabIndex = 5;
            // 
            // addPtypeBtn
            // 
            this.addPtypeBtn.ForeColor = System.Drawing.Color.Red;
            this.addPtypeBtn.Location = new System.Drawing.Point(808, 109);
            this.addPtypeBtn.Name = "addPtypeBtn";
            this.addPtypeBtn.Size = new System.Drawing.Size(154, 59);
            this.addPtypeBtn.TabIndex = 6;
            this.addPtypeBtn.Text = "新增子类型和检测项目表";
            this.addPtypeBtn.UseVisualStyleBackColor = true;
            this.addPtypeBtn.Click += new System.EventHandler(this.addPtypeBtn_Click);
            // 
            // delPtypeBtn
            // 
            this.delPtypeBtn.Location = new System.Drawing.Point(294, 39);
            this.delPtypeBtn.Name = "delPtypeBtn";
            this.delPtypeBtn.Size = new System.Drawing.Size(82, 23);
            this.delPtypeBtn.TabIndex = 6;
            this.delPtypeBtn.Text = "删除子分类";
            this.delPtypeBtn.UseVisualStyleBackColor = true;
            this.delPtypeBtn.Click += new System.EventHandler(this.delPtypeBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(785, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "类型名";
            // 
            // PclassTB
            // 
            this.PclassTB.Location = new System.Drawing.Point(837, 55);
            this.PclassTB.Name = "PclassTB";
            this.PclassTB.Size = new System.Drawing.Size(104, 21);
            this.PclassTB.TabIndex = 5;
            this.PclassTB.Text = "/";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(785, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 7;
            this.label6.Text = "等级";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ProductItem";
            this.dataGridViewTextBoxColumn1.HeaderText = "检测项目";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "ItemUnit";
            this.dataGridViewTextBoxColumn2.HeaderText = "单位";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ItemValue";
            this.dataGridViewTextBoxColumn3.HeaderText = "默认值";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(808, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 59);
            this.button1.TabIndex = 8;
            this.button1.Text = "修改当前分类检测项目";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(808, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(154, 59);
            this.button2.TabIndex = 8;
            this.button2.Text = "<---预设项目填充";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ProductManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.delPtypeBtn);
            this.Controls.Add(this.delProductBtn);
            this.Controls.Add(this.addPtypeBtn);
            this.Controls.Add(this.addProductBtn);
            this.Controls.Add(this.PclassTB);
            this.Controls.Add(this.PtypeTB);
            this.Controls.Add(this.PnameTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemsGV);
            this.Controls.Add(this.PtypeLB);
            this.Controls.Add(this.ProductLB);
            this.Controls.Add(this.kindLB);
            this.Name = "ProductManage";
            this.Text = "预设样品分类管理";
            this.Load += new System.EventHandler(this.ProductManage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ItemsGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox kindLB;
        private System.Windows.Forms.ListBox ProductLB;
        private System.Windows.Forms.ListBox PtypeLB;
        private System.Windows.Forms.DataGridView ItemsGV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PnameTB;
        private System.Windows.Forms.Button addProductBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button delProductBtn;
        private System.Windows.Forms.TextBox PtypeTB;
        private System.Windows.Forms.Button addPtypeBtn;
        private System.Windows.Forms.Button delPtypeBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PclassTB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn ItemValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}