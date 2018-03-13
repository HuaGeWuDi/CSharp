using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Redis缓存
{
    class Program
    {
        public static string connStr = "server=.;database=Study;uid=sa;pwd=123";
        static void Main(string[] args)
        {
            DataTable ds = null;
            var test = ReHelper.Get<string>("test");
            if (!ReHelper.Exists("test"))
            {
                ReHelper.Add("test", JsonConvert.SerializeObject(GetTestDS()), DateTime.Now.AddDays(1));
                test = ReHelper.Get<string>("test");
            }
            Console.WriteLine(test);
            Console.ReadKey();
            //Console.WriteLine("Redis写入缓存：zhong");

            //ReHlper.Add("zhong", "zhongzhongzhong", DateTime.Now.AddDays(1));

            //Console.WriteLine("Redis获取缓存：zhong");

            //string str3 = ReHlper.Get<string>("zhong");

            //Console.WriteLine(str3);

            //Console.WriteLine("Redis获取缓存：nihao");
            //string str = ReHlper.Get<string>("nihao");
            //Console.WriteLine(str);


            //Console.WriteLine("Redis获取缓存：wei");
            //string str1 = ReHlper.Get<string>("wei");
            //Console.WriteLine(str1);

            //Console.ReadKey();




        }

        public static DataTable GetTestDS()
        {
            DataSet _ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql=" select * from t_student ";
                SqlDataAdapter _adtap = new SqlDataAdapter(sql, conn);
                _adtap.Fill(_ds, "my_ds");
            }
            return _ds.Tables[0];
        }
    }
}
