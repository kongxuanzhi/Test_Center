using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Code;

namespace TRESystem2011.Items
{
    public partial class ProductManage : Form
    {
        ProductControl m_pc = null;
        public ProductManage()
        {
            InitializeComponent();
            m_pc = new ProductControl();
        }

        private void ProductManage_Load(object sender, EventArgs e)
        {
            bindKindLB();
        }

        /// <summary>
        /// 类型选择后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kindLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bindProductLB();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("操作出错！"+ex.Message);
            }

        }

        /// <summary>
        /// 名称选择后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                bindPtypeLB();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("操作出错！"+ex.Message);
            }
        }

        //双击后
        private void ItemLB_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                string Pname = ProductLB.SelectedValue.ToString();
                string Ptype = PtypeLB.SelectedValue.ToString();
                ItemsGV.DataSource = DB.getDataTable(string.Format("select ProductItem,ItemUnit,ItemValue from productitem where productname='{0}' and producttype='{1}' order by [itemindex]", Pname, Ptype));

                PtypeTB.Text = Ptype.Trim();
                PclassTB.Text = DB.ExecuteScalar(string.Format("select top 1 ProductClass from ProductItem where ProductName='{0}' and Producttype='{1}'", Pname, Ptype)).Trim();
        
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("操作出错！"+ex.Message);
            }

        }

        //新增
        private void addProductBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string Ptype = kindLB.SelectedValue.ToString();
                string Pname = PnameTB.Text;
                //string Paccording=AccordingTb.Text;
                m_pc.AddProduct(Pname, Ptype, "/");
                bindProductLB();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("操作出错！"+ex.Message);
            }

        }


        void bindKindLB()
        {
            kindLB.DataSource = DB.getList("select Kindsname from samplekinds order by i");
        }

        void bindProductLB()
        {
            string kind = kindLB.SelectedValue.ToString();
            ProductLB.DataSource = DB.getList(string.Format("select Productname from Productname where productkind='{0}' order by [productindex]", kind));
            if (ProductLB.Items.Count == 0)//如果绑定之后为0，则第三项也赋值为空
            {
                PtypeLB.DataSource = null;
            }
        }

        void bindPtypeLB()
        {
            string Pname = ProductLB.SelectedValue.ToString();
            
            PtypeLB.DataSource = DB.getList(string.Format("select distinct(Producttype) from Productitem where productname='{0}'", Pname));
        }


        private void delProductBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗？此项操作将带来很大风险！", "警告！", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            string Pname = ProductLB.SelectedValue.ToString();
            m_pc.DeleteProduct(Pname);
            bindProductLB();
        }

        private void addPtypeBtn_Click(object sender, EventArgs e)
        {
            if (PtypeTB.Text == "" || PclassTB.Text == "")
            {
                MessageBox.Show("类型名和等级都不能为空");
                return;
            }
            try
            {
                string Pname = ProductLB.SelectedValue.ToString();
                string Ptype = PtypeTB.Text;
                string Pclass = PclassTB.Text;
                DataTable dt = Libs.DataGridViewToDataTable(ItemsGV);
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("最少需要一个检测项目！");
                    return;
                }
                NewProductControl.AddPtype(Pname, Ptype, Pclass, dt);
                bindPtypeLB();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("操作出错！"+ex.Message);
            }

        }

        /// <summary>
        /// 删除子分类
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void delPtypeBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要删除吗？", "警告！", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                return;
            }
            try
            {
                string Pname = ProductLB.SelectedValue.ToString();
                string Ptype = PtypeLB.SelectedValue.ToString();
                NewProductControl.DeletePtype(Pname, Ptype);
                bindPtypeLB();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("操作出错！"+ex.Message);       	
            }

        }

        /// <summary>
        /// 修改当前分类检测项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string Pname = ProductLB.SelectedValue.ToString();
            string Poldtype= PtypeLB.SelectedValue.ToString();
            string Ptype = PtypeTB.Text;
            string Pclass = PclassTB.Text;
            if (Ptype.Trim() == ""||Pclass.Trim()=="")
            {
                MessageBox.Show("类型名和等级都不能为空！");
                return;
            }

            try
            {
                NewProductControl.DeletePtype(Pname, Poldtype);
                NewProductControl.AddPtype(Pname, Ptype, Pclass, Libs.DataGridViewToDataTable(ItemsGV));
                bindPtypeLB();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("操作出错！"+ex.Message);      
            }

        }

        /// <summary>
        /// 预设项目填充
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string[] ArraryMetal = { "La2O3/TREO", "CeO2/TREO", "Pr6O11/TREO", "Nd2O3/TREO", "Sm2O3/TREO", "Eu2O3/TREO", "Gd2O3/TREO", "Tb4O7/TREO", "Dy2O3/TREO", "Ho2O3/TREO", "Er2O3/TREO", "Tm2O3/TREO", "Yb2O3/TREO", "Lu2O3/TREO", "Y2O3/TREO", "TREO", "L.O.I", "CaO", "Al2O3", "Cr2O3", "MnO2", "Fe2O3", "Co2O3", "NiO", "CuO", "ZnO", "PbO", "SiO2", "氯根", "硫酸根", "La/TRE", "Ce/TRE", "Pr/TRE", "Nd/TRE", "Sm/TRE", "Eu/TRE", "Gd/TRE", "Tb/TRE", "Dy/TRE", "Ho/TRE", "Er/TRE", "Tm/TRE", "Yb/TRE", "Lu/TRE", "Y/TRE", "TRE", "Ca", "Al", "Cr", "Mn", "Fe", "Co", "Ni", "Cu", "Zn", "Pb", "O", "C", "S", "Si", "氯根" };
            foreach (string item in ArraryMetal)
            {
                try
                {
                    ItemsGV.Rows.Add(item, "%", "/");
                }
                catch (Exception)
                {
                    MessageBox.Show("控件已被绑定，不能操作！");
                    throw;
                }
            }
        }
    }
}
