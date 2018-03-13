
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
#pragma warning disable 1591
namespace StudyProgram.Common
{
    /// <summary>
    /// 执行数据库操纵
    /// </summary>
    public sealed class DBHelper
    {
        /// <summary>
        /// 执行不带参的Sql或存储过程 查询语句
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string sqlConnection, CommandType commandType, string commandText)
        {
            DataSet my_ds = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(commandText, conn);
                    cmd.CommandType = commandType;//这边是指是调用存储过程还是Sql语句
                    SqlDataAdapter my_adapter = new SqlDataAdapter(cmd);
                    my_ds = new DataSet();
                    my_adapter.Fill(my_ds);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return my_ds;
        }
        /// <summary>
        ///  执行带参的Sql或存储过程 查询语句
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static DataSet ExecuteDataset(string sqlConnection, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {
            DataSet my_ds = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandType = commandType;//这边是指是调用存储过程还是Sql语句
                    cmd.CommandText = commandText;
                    cmd.Parameters.AddRange(sqlParameters);
                    SqlDataAdapter my_adapter = new SqlDataAdapter(cmd);
                    my_ds = new DataSet();
                    my_adapter.Fill(my_ds);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return my_ds;
        }
        /// <summary>
        /// 执行不带参的Sql或存储过程 影响行数
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlConnection, CommandType commandType, string commandText)
        {
            var result = 0;
            try
            {
                using (var conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = commandType;
                    cmd.CommandText = commandText;
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 执行带参的Sql或存储过程 影响行数
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string sqlConnection, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {
            var result = 0;
            try
            {
                using (var conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = commandType;
                    cmd.CommandText = commandText;
                    cmd.Parameters.AddRange(sqlParameters);
                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return result;
        }
        /// <summary>
        /// 执行不带参的Sql或存储过程 SqlDataReader
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <returns></returns>
        public static SqlDataReader ExecuteReader(string sqlConnection, CommandType commandType, string commandText)
        {
            SqlDataReader dtreader = null;
            try
            {
                using (var conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = commandType;
                    cmd.CommandText = commandText;
                    dtreader = cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return dtreader;
        }
        /// <summary>
        /// 执行带参的Sql或存储过程 SqlDataReader
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="commandType"></param>
        /// <param name="commandText"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>

        public static SqlDataReader ExecuteReader(string sqlConnection, CommandType commandType, string commandText, params SqlParameter[] sqlParameters)
        {
            SqlDataReader dtreader = null;
            try
            {
                using (var conn = new SqlConnection(sqlConnection))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandType = commandType;
                    cmd.CommandText = commandText;
                    cmd.Parameters.AddRange(sqlParameters);
                    dtreader = cmd.ExecuteReader();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return dtreader;
        }

        //查找数据库中的一个值
        public static object ExecuteScalar(string sqlConnection, CommandType commandtype, string commandText, SqlParameter[] sqlParameters = null)
        {
            object obj = null;
            using (var conn = new SqlConnection(sqlConnection))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandtype;
                    if (sqlParameters != null) cmd.Parameters.AddRange(sqlParameters);
                    conn.Open();//记得要打开连接，不然执行不了语句
                    obj = cmd.ExecuteScalar();
                }
            }
            return obj;
        }
    }
}