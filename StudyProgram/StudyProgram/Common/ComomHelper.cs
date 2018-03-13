using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace StudyProgram.Common
{

    public class ComomHelper
    {
        public static string ConnectionString = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];

        public static DataSet ExecuteDataset(string sql)
        {
            DataSet my_ds = null;
            if (!string.IsNullOrEmpty(sql))
            {
                my_ds = new DataSet();
                using (SqlConnection my_conn = new SqlConnection(ConnectionString))
                {
                    my_conn.Open();
                    SqlCommand my_cmd = my_conn.CreateCommand();
                    my_cmd.CommandText = sql;
                    SqlDataAdapter my_adapter = new SqlDataAdapter(my_cmd);
                    my_adapter.Fill(my_ds);
                }
            }
            return my_ds;
        }     
        public static int ExecuteNonQuery(string sqlStr, SqlParameter[] my_params)
        {
            int i=default(int);
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = sqlStr;
                    cmd.Parameters.AddRange(my_params);
                    i = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {                
                throw e;
            }
            return i;
        }


        //缓存
        public static string GetCache()
        {
            var res = "";                   
            //var aa =System.Web.Caching.Cache()         
            return res;
        }
    }
}