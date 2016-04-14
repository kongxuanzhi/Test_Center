using Code;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace TRESystem2011.Code
{
    class FileToDB
    {
        public void SaveToDB(string sno, string fileName)
        {
            try
        {
                FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                BinaryReader br = new BinaryReader(fs);
                byte[] buf = br.ReadBytes((int)fs.Length);//全部读入bytes中
                OleDbConnection conn = DB.getConn();
                OleDbCommand cmd = new OleDbCommand("update Sampletable set TestDoc=? where sno='" + sno + "'", conn);
                cmd.Parameters.Add("?", OleDbType.VarBinary).Value = buf;
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    MessageBox.Show("保存失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件打开失败！可能因为权限不够！");
            }
        }
        public void show(string sno, string fileName)
        {
            try
            {
                string sql = "select TestDoc from Sampletable where sno='" + sno + "'";
                OleDbDataReader reader = DB.ExecuteReader(sql);
                byte[] buffByte = null;
                if (reader.Read())
                {
                    buffByte = (byte[])reader[0];
                }
                reader.Close();
                FileStream fs1;
                FileInfo fi = new FileInfo(fileName);
                fs1 = fi.OpenWrite();
                fs1.Write(buffByte, 0, buffByte.Length);
                fs1.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开失败！");
            }
        }
        public static bool IsFileOpen(string filePath)
        {
            bool result = false;
            System.IO.FileStream fs = null;
            try
            {
                fs = File.OpenWrite(filePath);
                fs.Close();
            }
            catch (Exception ex)
            {
                result = true;
            }
            return result;//true 打开 false 没有打开
        }
    }
}
