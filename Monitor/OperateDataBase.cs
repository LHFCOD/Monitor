using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;
namespace Monitor
{
    class OperateDataBase
    {
        public OleDbConnection con;
        public DataTable QueryTable(string strSql,OleDbConnection con)
        {
            OleDbCommand cmd = new OleDbCommand(strSql, con);
            DataSet set = new DataSet();
            OleDbDataAdapter adpCorro = new OleDbDataAdapter(cmd);
            adpCorro.Fill(set);
            DataTable temp_dt = set.Tables[0];//获取参数数据表格
            return temp_dt;
        }
       public OperateDataBase(OleDbConnection _con)
        {
            con = _con;
        }
        public OperateDataBase(string conStr)
        {
            con = new OleDbConnection(conStr);
            con.Open();
        }
    }
}
