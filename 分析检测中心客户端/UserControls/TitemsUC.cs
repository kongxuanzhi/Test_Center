using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Code;
using System.Data.OleDb;

namespace TRESystem2011.UserControls
{
    public partial class TitemsUC : UserControl
    {

        public Control snControl; //样品名称
        public Control stControl; //样品规格
        public Control sgControl;   //grade //样品等级

        private DataTable m_dt; //用来绑定数据的m_dt  


        public TitemsUC()
        {
            InitializeComponent();
            SiDV.AutoGenerateColumns = false;
        }



        public void init()  //初始化
        {
            ProductControl myclass = new ProductControl();
            myclass.GetProduct(SiTV);
        }


        /// <summary>
        /// 从datagridview中获取数据表
        /// </summary>
        /// <returns></returns>
        public DataTable getDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Titem");
            dt.Columns.Add("Tunit");
            dt.Columns.Add("Tstandard");
            dt.Columns.Add("Tvalue");
            dt.Columns.Add("Tdeterminant");

            for (int i = 0; i < SiDV.Rows.Count; i++)
            {
                try
                {   //如果发生了转换异常，直接结束
                    if(SiDV.Rows[i].Selected == true)  //设置只对选中的项目进行检测
                    {
                        DataRow dr = dt.NewRow();
                        dr["Titem"] = SiDV.Rows[i].Cells["Titem"].Value?.ToString();
                        dr["Tunit"] = SiDV.Rows[i].Cells["Tunit"].Value?.ToString();
                        dr["Tstandard"] = SiDV.Rows[i].Cells["Tstandard"].Value?.ToString();
                        dr["Tvalue"] = SiDV.Rows[i].Cells["Tvalue"].Value?.ToString();
                        dr["Tdeterminant"] = "/";
                        dt.Rows.Add(dr);
                    }
                }
                catch(Exception)
                {
                    break;
                }
            }
            return dt;
        }

        /// <summary>
        /// 将数据表中的数据更新到数据库中
        /// </summary>
        /// <returns></returns>
        public int updateGridView()
        {
            if (m_dt==null)
            {
                return 0;
            }
            return DB.UpdateDataTable(m_dt, "Resulttable");            
        }



        /// <summary>
        /// 用数据表填充datagridview
        /// </summary>
        /// <param name="dt"></param>
        public void setDataGridView(DataTable dt)
        {
            m_dt = dt;
            SiDV.DataSource = m_dt;
        }


        /// <summary>
        /// 双击树节点时发生，加载预留数据到数据表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SiTV_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TextBox tb_SN = new TextBox();  //样品名称
            TextBox tb_SC = new TextBox(); 
            TextBox tb_ST = new TextBox();  //样品类型
            try
            {
                if (SiTV.SelectedNode.Level == 2)
                {
                    SiDV.DataSource = null;
                    SiDV.Rows.Clear();
                    tb_SN.Text = SiTV.SelectedNode.Parent.Text.Trim(); //样品名称  氧化腓
                    tb_ST.Text = SiTV.SelectedNode.Text.Trim().Substring(0, SiTV.SelectedNode.Text.Trim().IndexOf("+")); //021035
                    ProductControl myclass = new ProductControl();
                    myclass.GetType(SiDV, tb_SC, tb_SN.Text, tb_ST.Text);
                    try
                    {
                        //if (snControl.Text == "")
                        //{
                            snControl.Text = SiTV.SelectedNode.Parent.Text.Trim();
                        //}
                        //if (stControl.Text == "/")
                        //{
                            stControl.Text = SiTV.SelectedNode.Text.Trim();
                        //}
                        //if (sgControl.Text == "/")
                        //{
                            //string tmp = SiTV.SelectedNode.Text.Trim().Substring(SiTV.SelectedNode.Text.Trim().IndexOf("+") + 1);
                            //if (tmp == "") tmp = "/";
                            //sgControl.Text = tmp;
                        //}


                    }
                    catch (System.Exception)
                    {

                    }
                    
                }
            }
            catch
            { }



        }

    }
}
