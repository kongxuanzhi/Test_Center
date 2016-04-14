using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Code;
using System.Data.OleDb;

namespace Code
{
    class ProductControl
    {
        public ProductControl()
        {
        }
        public void GetProduct(TreeView TreeV)
        {
            TreeV.Nodes.Clear();
            string sqlstr = "select KindsName,i from SampleKinds order by i";

            OleDbDataReader myreader = DB.ExecuteReader(sqlstr);
            if (!myreader.HasRows)
            {
                myreader.Close();
                return;
            }
            while (myreader.Read())
            {
                TreeV.Nodes.Add(myreader.GetString(0).Trim());
            }
            myreader.Close();
            for (int i = 0; i < TreeV.Nodes.Count; i++)
            {
                sqlstr = "select ProductName,ProductIndex from ProductName where ProductKind='" + TreeV.Nodes[i].Text.Trim() + "' order by ProductIndex";

                myreader = DB.ExecuteReader(sqlstr);
                if (!myreader.HasRows)
                {
                    myreader.Close();
                    continue;
                }
                while (myreader.Read())
                {

                    TreeV.Nodes[i].Nodes.Add(myreader.GetString(0).Trim());
                }
                myreader.Close();
            }
            for (int i = 0; i < TreeV.Nodes.Count; i++)
            {
                for (int j = 0; j < TreeV.Nodes[i].Nodes.Count; j++)
                {
                    sqlstr = "select DISTINCT ProductType,ProductClass from ProductItem where ProductName='" + TreeV.Nodes[i].Nodes[j].Text.Trim() + "'";
                    myreader = DB.ExecuteReader(sqlstr);
                    if (!myreader.HasRows)
                    {
                        myreader.Close();
                        continue;
                    }
                    while (myreader.Read())
                    {

                        TreeV.Nodes[i].Nodes[j].Nodes.Add(myreader.GetString(0).Trim() + "+" + myreader.GetString(1).Trim());
                    }
                    myreader.Close();
                }
                
            }

        }
        public void AddProduct(string ProductName,string ProductKind,string According)
        {
            try
            {
                string sqlstr = "insert into ProductName(ProductName,ProductKind,According) values('" + ProductName + "','" + ProductKind + "','" + According + "')";
                DB.ExecuteNonQuery(sqlstr);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("该产品已存在！"+ex.Message);
                return;
            }
        }
        public void ModifyProduct(string ProductName, string ProductKind, string According)
        {
            try
            {

                string sqlstr = "update ProductName set ProductKind='" + ProductKind + "',According='" + According + "' where ProductName='" + ProductName + "'";
                DB.ExecuteNonQuery(sqlstr);

            }
            catch (OleDbException)
            {
                MessageBox.Show("连接错误！");
                return;
            }
        }
        public void DeleteProduct(string ProductName)
        {
            if (MessageBox.Show("是否删除产品？", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                return;
            try
            {
                string sqlstr = "delete from ProductName  where ProductName='" + ProductName + "'";
                DB.ExecuteNonQuery(sqlstr);
                sqlstr = "delete from ProductItem where ProductItem='" + ProductName + "'";
                DB.ExecuteNonQuery(sqlstr);
            }
            catch (OleDbException)
            {
                MessageBox.Show("连接错误！");
                return;
            }

        }
        public void AddType(string ProductName, string ProductType, string ProductClass, string[,] Item)
        {
            if (SelectType(ProductName, ProductType))
            {
                MessageBox.Show("该产品类型已存在，请用修改方式进行更新！");
                return;
            }
            try
            {
                string sqlstr = "";
                for (int i = 0; i < Item.GetLength(1); i++)
                {
                    sqlstr = "insert into ProductItem(ProductName,ProductType,ProductClass,ProductItem,ItemUnit,ItemValue,ItemIndex) values('"
                        + ProductName + "','" + ProductType + "','" + ProductClass + "','" + Item[0, i] + "','" + Item[1, i] + "','" + Item[2, i] + "'," + Convert.ToInt32(Item[3, i]) + ")";
                    DB.ExecuteNonQuery(sqlstr);
                }
            }
            catch (OleDbException)
            {
                MessageBox.Show("连接错误！");
                return;
            }
        }
        public void DeleteType(string ProductName, string ProductType)
        {
            try
            {
                string sqlstr = "";

                sqlstr = "delete from ProductItem where ProductName='" + ProductName + "' and ProductType='" + ProductType + "'";

                DB.ExecuteNonQuery(sqlstr);

            }
            catch (SqlException)
            {
                MessageBox.Show("连接错误！");
                return;
            }
        }
        public void ModifyType(string ProductName, string ProductType, string ProductClass, string[,] Item)
        {
            DeleteType(ProductName,ProductType);
            AddType(ProductName, ProductType, ProductClass, Item);
        }
        public bool SelectType(string ProductName, string ProductType)
        {

            string sqlstr = "select ProductName,ProductType from ProductItem where ProductName='" + ProductName + "' and ProductType='" + ProductType + "'";
            OleDbDataReader myreader = DB.ExecuteReader(sqlstr);
            if (!myreader.HasRows)
            {
                myreader.Close();

                return false;
            }
            else
            {
                myreader.Close();

                return true;
            }


        }
        public void GetType(DataGridView dv,TextBox tb1,string  ProductName,string ProductType)
        {

            string sqlstr = "select ProductName,ProductType,ProductClass,ProductItem,ItemUnit,ItemValue,ItemIndex from ProductItem where ProductName='" + ProductName + "' and ProductType='" + ProductType + "' order by ItemIndex";

            OleDbDataReader myreader = DB.ExecuteReader(sqlstr);
            if (!myreader.HasRows)
            {
                myreader.Close();

                return ;
            }
            while(myreader.Read())
            {
                tb1.Text = myreader.GetString(2).Trim();
                dv.Rows.Add(myreader.GetString(3).Trim(), myreader.GetString(4).Trim(), myreader.GetString(5).Trim(),"/");
            }
            myreader.Close();

        }
        public string[] Items()
        {
            string[] ArraryMetal ={ "La2O3/TREO", "CeO2/TREO", "Pr6O11/TREO", "Nd2O3/TREO", "Sm2O3/TREO", "Eu2O3/TREO", "Gd2O3/TREO", "Tb4O7/TREO", "Dy2O3/TREO", "Ho2O3/TREO", "Er2O3/TREO", "Tm2O3/TREO", "Yb2O3/TREO", "Lu2O3/TREO", "Y2O3/TREO", "TREO","L.O.I" ,"CaO", "Al2O3", "Cr2O3", "MnO2", "Fe2O3", "Co2O3", "NiO", "CuO", "ZnO", "PbO", "SiO2", "氯根", "硫酸根" ,"La/TRE", "Ce/TRE", "Pr/TRE", "Nd/TRE", "Sm/TRE", "Eu/TRE", "Gd/TRE", "Tb/TRE", "Dy/TRE", "Ho/TRE", "Er/TRE", "Tm/TRE", "Yb/TRE", "Lu/TRE", "Y/TRE", "TRE", "Ca", "Al", "Cr", "Mn", "Fe", "Co", "Ni", "Cu", "Zn", "Pb", "O", "C", "S", "Si","氯根"};
            return ArraryMetal;
        }
    }
}
