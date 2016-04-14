using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Forms;
using System.IO;

/// <summary>
///DB静态类 BY 小葱
/// </summary>
/// 

namespace Code
{
    public static class DB
    {
        public static string m_linkstr="";
        public static OleDbConnection m_conn;
        public static OleDbCommand m_cmd;

        public static OleDbDataAdapter m_dataAdapter;  //默认的适配器
        

        static DB()
        {

        }


        /// <summary>
        /// 初始化操作
        /// </summary>
        /// <param name="connstr"></param>
        public static void init(string connstr)
        {
            try
            {
                m_linkstr = connstr;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("服务器连接数据无效！" + ex.Message);
            }
            m_linkstr += "Connect Timeout=5;"; //设置超时时间

            m_conn = new OleDbConnection(m_linkstr);
            m_cmd = new OleDbCommand();
        }

        public static void init(string connstr, bool isOfficial)
        {
            try
            {
                m_linkstr = connstr;
                if(isOfficial)
                {
                    //m_linkstr += "User ID=cat_jxust_user;Password=cat_jxust_user2016;";
                    m_linkstr += "User ID=sa;Password=123;";
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("服务器连接数据无效！" + ex.Message);
            }
            m_linkstr += "Connect Timeout=5;"; //设置超时时间

            m_conn = new OleDbConnection(m_linkstr);
            m_cmd = new OleDbCommand();
        }


        public static void Open()
        {
            try
            {
                if (m_conn.State==ConnectionState.Closed)
                {
                    m_conn.Open();
                }
                m_cmd.Connection = m_conn;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public static bool Close()
        {
            try
            {
                m_conn.Close();
            }
            catch (System.Exception)
            {
                return false;
            }
            return true;
        }

        public static OleDbConnection getConn()
        {
            return m_conn;
        }




        /// <summary>
        /// 获取带所有语句的配适器
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static OleDbDataAdapter getAdapterByTableName(string tbname)
        {
            string sql = "select * from " + tbname;
            OleDbDataAdapter oda = new OleDbDataAdapter(sql, m_conn);
            OleDbCommandBuilder odcb = new OleDbCommandBuilder(oda);
            oda.InsertCommand = odcb.GetInsertCommand();
            oda.UpdateCommand = odcb.GetUpdateCommand();
            oda.DeleteCommand = odcb.GetDeleteCommand();
            return oda;
        }

        /// <summary>
        /// 根据表名获取一个空的表架构
        /// </summary>
        /// <param name="tbname"></param>
        /// <returns></returns>
        public static DataTable getEmptyTableByTableName(string tbname)
        {
            string sql = "select * from " + tbname + " where 1=0";  //查询一个空值
            return getDataTable(sql);
        }

        /// <summary>
        /// 直接更新某表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="tbname"></param>
        public static int UpdateDataTable(DataTable dt,string tbname)
        {
            OleDbDataAdapter oda = getAdapterByTableName(tbname);
            return oda.Update(dt);
        }


        public static DataTable getDataTable(string sql)
        {
            return getDataSet(sql, "tmptable").Tables[0];
        }

        public static List<object> getList(string sql)
        {
            DataTable dt = getDataTable(sql);
            List<object> olist = new List<object>();
            foreach (DataRow dr in dt.Rows)
            {
                olist.Add(dr[0]);
            }
            return olist;
        }


        public static DataRow getDataRow(string sql)
        {
            DataSet ds = getDataSet(sql, "tmptable");
            if (ds.Tables[0].Rows.Count == 0)
            {
                return null;
            }
            return ds.Tables[0].Rows[0];
        }

        public static DataSet getDataSet(string sql, string tablename)
        {
            Open();
            m_dataAdapter = new OleDbDataAdapter(sql, m_conn);
            OleDbCommandBuilder odcb = new OleDbCommandBuilder(m_dataAdapter);
            DataSet ds = new DataSet();
            m_dataAdapter.Fill(ds, tablename);
            return ds;
        }



        public static void fillDataSet(DataSet ds, string tablename, string sql)
        {
            Open();
            m_dataAdapter = new OleDbDataAdapter(sql, m_conn);
            OleDbCommandBuilder odcb = new OleDbCommandBuilder(m_dataAdapter);
            m_dataAdapter.Fill(ds, tablename);
        }

        public static int ExecuteNonQuery(string sql)
        {
            Open();
            m_cmd.CommandText = sql;
            return m_cmd.ExecuteNonQuery();
        }

        public static string ExecuteScalar(string sql)
        {
            Open();
            m_cmd.CommandText = sql;
            if(m_cmd.ExecuteScalar()==null)
            {
                return "";
            }
            return m_cmd.ExecuteScalar().ToString();
        }

        public static object ExecuteObject(string sql)
        {
            Open();
            m_cmd.CommandText = sql;
            return m_cmd.ExecuteScalar();
        }

        public static OleDbDataReader ExecuteReader(string sql)
        {
            Open();
            m_cmd.CommandText = sql;
            return m_cmd.ExecuteReader();
        }
    }
}
