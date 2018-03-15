using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace StudyProgram.Common
{
    public class SSHelper
    {
        private static HttpSessionState _session = HttpContext.Current.Session;

        //新增或修改
        public static void SetSession(string key, object value)
        {
            _session[key] = value;
        }

        //删除指定key
        public static void RemoveSession(string key)
        {
            _session.Remove(key);
        }

        //获取指定key的Session
        public static object GetSession(string key)
        {
            return _session[key];
        }

        //清空Session
        public static void Clear()
        {
            _session.Clear();
        }
    }
}