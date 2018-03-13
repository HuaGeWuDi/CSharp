using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;
using System.Data;
using System.Data.SqlClient;

namespace StudyProgram.Pages
{
    public partial class 缓存Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var a = getData("wudi");
                getObjectDT("test");
            }
        }

        //判断缓存存不存在
        private object getObjectDT(string cKey)
        {
            var caCahe = GetCache(cKey);
            if (caCahe == null)
            {
                var ds = GetData();
                if (ds != null)
                {
                    SqlCacheDependency dep = new SqlCacheDependency("testCache", "t_student");
                    SetCache(cKey, ds, dep);
                    caCahe = GetCache(cKey);
                }
                else caCahe = null;
            }
            return caCahe;
        }

        //获取缓存
        private object GetCache(string cacheKey)
        {
            System.Web.Caching.Cache objCache = HttpRuntime.Cache;
            return objCache[cacheKey];
        }

        //添加缓存
        private void SetCache(string cacheKey, object objObject, CacheDependency dep)
        {
            var objCache = HttpRuntime.Cache;
            //objCache.Add()
            objCache.Insert(cacheKey, objObject
                , dep//该项的文件依赖项或缓存键依赖项
                , Cache.NoAbsoluteExpiration //从不过期
                , Cache.NoSlidingExpiration//禁用可调过期
                , CacheItemPriority.Default
                , null);
        }

        public DataSet GetData()
        {
            var conStr1 = System.Configuration.ConfigurationManager.AppSettings["ConnectionString"];
            var conStr2 = System.Configuration.ConfigurationManager.ConnectionStrings["connStr"].ToString();
            DataSet ds = new DataSet();
            using (var conn = new SqlConnection(conStr1))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = " select * from t_student ";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds, "test");
            }
            return ds;
        }


        public object getData(string key)
        {
            return LeiKu.CacheUse.getCache(key);
        }
    }
}