using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Assembly学习v;
#pragma warning disable 1591
namespace StudyProgram.LeiKu
{

    public static class CacheUse
    {
        public static object getCache(string key)
        {
            //var conStr = ConfigurationManager.ConnectionStrings["Test"].ToString();

            XmlHelper xml = new XmlHelper();
            var conStr = xml.LinqToXml("appSettings", "add", "ConnectionString");
            var cName = xml.LinqToXml("appSettings", "add", "cache");
            var tName = xml.LinqToXml("appSettings", "add", "table");
            if (string.IsNullOrEmpty(conStr))
                throw new ApplicationException("未配置连接字符串节点");

            CacheHelper help = new CacheHelper(cName, tName, key, conStr);

            return help.GetCache();
        }
    }
}