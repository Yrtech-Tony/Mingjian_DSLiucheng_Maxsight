using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data.SQLite;

namespace XHX.Common
{
    public static class SqliteHelper
    {
        static string _dbConnectionString = null;

        /// <summary>
        /// 设置ConnectionString
        /// </summary>
        /// <returns></returns>
        public static void SetConnectionString(string dbConnectionString, string password)
        {
            dbConnectionString += ";Version=3";
            if (password != null && password != string.Empty)
            {
                dbConnectionString += ";Password=" + password;
            }
            _dbConnectionString = dbConnectionString;
        }

        public static List<String> Search(string commandText)
        {
            try
            {
                List<String> dataList = new List<string>();
                DbProviderFactory factory = SQLiteFactory.Instance;
                using (DbConnection conn = factory.CreateConnection())
                {
                    conn.ConnectionString = _dbConnectionString;
                    conn.Open();
                    DbCommand cmd = conn.CreateCommand();
                    cmd.CommandText = commandText;
                    DbDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        if (dr.HasRows)
                        {
                            String data = String.Empty;
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                data += dr.GetValue(i) + "$";
                            }
                            //String data = dr.GetValue().GetString(0) + ";" + dr.GetString(1) + ";" + dr.GetString(2) + ";" + dr.GetInt32(3) + ";" + dr.GetString(4) + ";" + dr.GetString(5) + ";" + dr.GetString(6) + ";" + dr.GetString(7) + ";" + dr.GetString(8) + ";" + dr.GetDateTime(9);
                            dataList.Add(data);
                        }
                    }
                }
                return dataList;
            }
            catch (Exception ex)
            {
                CommonHandler.ShowMessage(MessageType.Information, ex.Message);
                throw;
            }
        }

        public static void InsertOrUpdata(List<String> commandTextList)
        {
            DbProviderFactory factory = SQLiteFactory.Instance;
            using (DbConnection conn = factory.CreateConnection())
            {
                conn.ConnectionString = _dbConnectionString;
                conn.Open();
                DbTransaction tran = conn.BeginTransaction();
                try
                {
                    foreach (String commandText in commandTextList)
                    {
                        DbCommand cmd = conn.CreateCommand();
                        cmd.CommandText = commandText;
                        cmd.ExecuteNonQuery();
                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    CommonHandler.ShowMessage(MessageType.Information, ex.Message);
                    throw;
                }
            }
        }
    }
}
