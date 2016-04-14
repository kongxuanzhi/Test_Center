using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
namespace Code
{
    class NewProductControl
    {
        /// <summary>
        /// 增加样品
        /// </summary>
        /// <param name="ProductName"></param>
        /// <param name="ProductKind"></param>
        /// <param name="According"></param>
        public static void AddProduct(string ProductName, string ProductKind, string According)
        {
            try
            {
                string sqlstr = "insert into ProductName(ProductName,ProductKind,According) values('" + ProductName + "','" + ProductKind + "','" + According + "')";
                DB.ExecuteNonQuery(sqlstr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("该产品已存在！" + ex.Message);
                return;
            }
        }

        public static void DeleteProduct(string ProductName)
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
            catch (Exception)
            {
                MessageBox.Show("出错了！");
                return;
            }

        }


        /// <summary>
        /// 增加子类型
        /// </summary>
        /// <param name="Pname"></param>
        /// <param name="Ptype"></param>
        /// <param name="Pclass"></param>
        /// <param name="itemsdt"></param>
        /// <returns></returns>
        public static int AddPtype(string Pname, string Ptype,string Pclass,DataTable itemsdt)
        {
            DataTable updt = DB.getEmptyTableByTableName("ProductItem");
            int i=1;
            foreach (DataRow dr in itemsdt.Rows)
            {
                DataRow updr = updt.NewRow();
                updr["ProductName"] = Pname;
                updr["ProductType"] = Ptype;
                updr["ProductClass"] = Pclass;
                updr["ProductItem"] = dr["ProductItem"].ToString();
                updr["ItemUnit"] = dr["ItemUnit"].ToString();
                updr["ItemValue"] = dr["ItemValue"].ToString();
                updr["ItemIndex"] = i;
                updt.Rows.Add(updr);
                i++;
            }
            OleDbDataAdapter oda = DB.getAdapterByTableName("ProductItem");
            return oda.Update(updt);

        }

        /// <summary>
        /// 删除子类型
        /// </summary>
        /// <param name="Pname"></param>
        /// <param name="Ptype"></param>
        /// <returns></returns>
        public static int DeletePtype(string Pname, string Ptype)
        {
            string sql = string.Format("delete from ProductItem where ProductName='{0}' and ProductType='{1}'",Pname,Ptype);
            return DB.ExecuteNonQuery(sql);

        }

        

    }
}
