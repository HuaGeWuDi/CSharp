using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace 存储过程学习
{
    class Program
    {
        public static string connStr = "server=.;database=Study;user id=sa;pwd=123";
        static void Main(string[] args)
        {
            //var cType = CommandType.StoredProcedure;
            //var cText = "pro_study";
            //SqlParameter[] parm = new SqlParameter[]
            //{             
            //  new SqlParameter("@id",1)
            //};

            //var exres = DBExecuteScalar(cType, cText, parm);
            //Console.WriteLine(exres + "");
            //var outres = DBExecutepParmOutput(cType, "test_study");
            //Console.WriteLine(outres);
            //Console.WriteLine(GetMsgBySJ());


            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            DataTable dtTemp = new DataTable();
            DataColumn[] columns = new DataColumn[]
            {
             new DataColumn("Name",typeof(string)),
             new DataColumn("Age",typeof(Int32)),
             new DataColumn("Sex",typeof(string)),
             new DataColumn("test",typeof(string)),
            };
            dtTemp.Columns.AddRange(columns);
            //构造一个10000行的DataTable
            for (var i = 0; i < 100 * 100; i++)
            {
                var n_row = dtTemp.NewRow();
                var tt = i + 1;
                n_row["Name"] = "Name" + tt;
                n_row["Age"] = tt;
                n_row["Sex"] = "Sex" + tt;
                n_row["test"] = "test" + tt;
                dtTemp.Rows.Add(n_row);
            }
            stopWatch.Stop();
            Console.WriteLine("构造一万行的Datatable所需时间：" + stopWatch.Elapsed);

            Stopwatch stopwatcj = new Stopwatch();
            stopwatcj.Start();
            DtDrTable(dtTemp, "t_student");
            stopwatcj.Stop();
            Console.WriteLine("10000行数据批量插入表中所需时间：" + stopwatcj.Elapsed);
            Console.ReadKey();
        }

        public static string DBExecuteScalar(CommandType cType, string cText, SqlParameter[] parms)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = cType;
                cmd.CommandText = cText;
                cmd.Parameters.AddRange(parms);
                conn.Open();
                var res = cmd.ExecuteScalar() + "";
                return res;
            }
        }

        public static string DBExecutepParmOutput(CommandType cType, string cText)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = cType;
                cmd.CommandText = cText;
                SqlParameter[] parms ={
                    new SqlParameter("@name","hauge"),
                    new SqlParameter("@result",SqlDbType.VarChar,20)
                                     };
                parms[1].Direction = ParameterDirection.Output;
                cmd.Parameters.AddRange(parms);
                conn.Open();
                cmd.ExecuteScalar();
                return parms[1].Value + "";
            }
        }

        //批量将数据导入目的表
        public static void DtDrTable(DataTable dt, string tableName)
        {
            try
            {
                //这边可以使用事物回滚机制
                SqlBulkCopy bcp = new SqlBulkCopy(connStr);
                //指定目标数据库的表名
                bcp.DestinationTableName = tableName;
                //每一批次的行数
                bcp.BatchSize = 100 * 100;
                //建立数据源表字段和目标表中的列之间的映射
                //----既然dt的列名需要与表明完全一致，直接循环dt的列即可----//
                foreach (DataColumn dc in dt.Columns)
                    bcp.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);
                //写入数据库表 dt 是数据源DataTable
                bcp.WriteToServer(dt);
                //关闭SqlBulkCopy实例
                bcp.Close();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        //批量将数据导入目的表可回滚
        public static void TranBatchImportData(DataTable dt, string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();
                using (SqlBulkCopy sqlBC = new SqlBulkCopy(conn, SqlBulkCopyOptions.UseInternalTransaction, tran))
                {
                    sqlBC.BatchSize = 100 * 100;
                    //sqlBC.BulkCopyTimeout = 60;//超时之前操作完成所允许的秒数
                    sqlBC.DestinationTableName = tableName;
                    foreach (DataColumn dc in dt.Columns)
                        sqlBC.ColumnMappings.Add(dc.ColumnName, dc.ColumnName);

                    sqlBC.WriteToServer(dt);
                    tran.Commit();
                }
            }
        }

        //测试事物回滚
        public static string GetMsgBySJ()
        {
            var msg = "";
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = conn.CreateCommand();
            conn.Open();//打开之后开启事物
            SqlTransaction tran = conn.BeginTransaction();//开启事物
            cmd.Transaction = tran;//将事物应用于CMD
            try
            {
                cmd.CommandText = " INSERT into t_student VALUES ('huage1','11','男神') ";
                cmd.ExecuteNonQuery();
                cmd.CommandText = " INSERT into t_student VALUES ('huage','11','女神','') ";
                cmd.ExecuteNonQuery();
                tran.Commit();//提交事物（不提交不会回滚错误）
                msg = "插入成功";
            }
            catch (Exception ex)
            {
                tran.Rollback();
                msg = "插入失败，事物回滚";
            }
            finally
            {
                tran.Dispose();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();                      
            }
            return msg;
        }
    }
}
