using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Reflection;
using Newtonsoft.Json;

namespace StudyProgram.Common
{
    public static class Common
    {
        /// <summary>
        /// aspx用Ajax访问自己cs后面方法
        /// </summary>
        /// <param name="page"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        public static void GetJsonByPage(Page page,string method="act")
        { 
            var m_method = page.Request[method];
            if (m_method != null)
            {
                try
                {
                    var res = page.GetType().GetMethod(m_method, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).Invoke(page,null);                 
                    if (res != null)
                        page.Response.Write(res);
                }
                catch (Exception ex)
                {
                    page.Response.Write(JsonConvert.SerializeObject(ex));                    
                }
                page.Response.End();//将当前所有缓冲输出到客户端，停止该页的执行,否则页面HTML也会输出
            }
        }
    }
}