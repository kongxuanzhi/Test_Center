using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using TRESystem2011;

namespace Code
{
    public static class Log
    {

        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="logType"></param>
        /// <param name="content"></param>
        public static int AddLog(string sno,string logType,string note)
        {
            string sql = string.Format("insert into SampleLog(Sno,LogType,Person,Note,dt) values('{0}','{1}','{2}','{3}','{4}')",
                sno, logType, User.name, note, Libs.getServerDate());
            return DB.ExecuteNonQuery(sql);

        }

        /// <summary>
        /// 采用数据集方式添加日志
        /// </summary>
        /// <param name="sno"></param>
        /// <param name="logType"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public static int AddLogEx(string sno, string logType, string note)
        {

            DataTable dt = DB.getEmptyTableByTableName("SampleLog");
            DataRow dr = dt.NewRow();
            dr["sno"] = sno;
            dr["LogType"] = logType;
            dr["Person"] = User.name;
            dr["note"] = note;
            dr["dt"] = Libs.getServerDate();
            dt.Rows.Add(dr);
            return DB.m_dataAdapter.Update(dt);
        }
    }
}
