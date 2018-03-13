using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Caching;
#pragma warning disable 1591
namespace StudyProgram.LeiKu
{
    public class CacheHelper
    {
        System.Web.Caching.Cache my_Cache = HttpRuntime.Cache;
        private string cacheName { get; set; }
        private string tableName { get; set; }
        private string myKey { get; set; }
        private string connStr { get; set; }
        public CacheHelper(string cName, string tName, string key, string cStr)
        {
            this.cacheName = cName;
            this.tableName = tName;
            this.myKey = key;
            this.connStr = cStr;
        }

        private bool Exist()
        {
            var my_obj = my_Cache.Get(myKey);
            return my_obj == null ? false : true;
        }

        public object GetCache()
        {
            object res = null;
            if (!Exist())
            {
                var data = GetData();
                AddCache(data);
                res = my_Cache[myKey];
            }
            else res = my_Cache[myKey];
            return res;
        }

        private void AddCache(object Obj)
        {
            if (Exist())
                my_Cache.Remove(myKey);

            SetCaChe(Obj);
        }

        private void SetCaChe(object Obj)
        {
            try
            {
                SqlCacheDependency dep = new SqlCacheDependency(cacheName, tableName);
                my_Cache.Add(myKey, Obj
                 , dep//该项的文件依赖项或缓存键依赖项
                 , Cache.NoAbsoluteExpiration //从不过期
                 , Cache.NoSlidingExpiration//禁用可调过期
                 , CacheItemPriority.Default
                 , null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, new Exception(ex.StackTrace));
            }
        }

        private DataTable GetData()
        {
            DataSet my_ds = new DataSet();
            //var connStr = System.Configuration.ConfigurationManager.ConnectionStrings["Test"];
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var sql = " select * from " + tableName;
                conn.Open();
                SqlDataAdapter m_Adapt = new SqlDataAdapter(sql, conn);
                m_Adapt.Fill(my_ds, "myds");
            }
            return my_ds == null ? null : my_ds.Tables[0];
        }
    }
}