using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace StudyProgram.Common
{
    public class CCHelper
    {
        private HttpCookie _cookie;
        private HttpResponse _response;
        private HttpRequest _request;

        public CCHelper(string CookieName)
        {
            _request = HttpContext.Current.Request;
            _response = HttpContext.Current.Response;

            var md5CN = MD5Str(CookieName);
            var Cookie = _request.Cookies[md5CN];
            if (Cookie != null)
                _cookie = Cookie;
            else
                _cookie = new HttpCookie(md5CN);
        }

        public CCHelper(string CookieName,E_Time eTime)
        {
            _request = HttpContext.Current.Request;
            _response = HttpContext.Current.Response;

            var md5CN = MD5Str(CookieName);
            var Cookie = _request.Cookies[md5CN];
            if (Cookie != null)
                _cookie = Cookie;
            else
                _cookie = new HttpCookie(md5CN);

            SetCookieDate(_cookie, eTime);
        }

        /// <summary>
        /// 新增，修改
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetCookie(string key, string value)
        {
            var md5Str = MD5Str(key);         
            if (!string.IsNullOrEmpty(_cookie.Values[md5Str]))
            {
                _cookie.Values.Set(md5Str, AESHelper.AESEncrypt(value));//存在即修改
                _response.SetCookie(_cookie);
            }
            else
            {
                _cookie.Values.Add(md5Str, AESHelper.AESEncrypt(value));//不存在即添加
                _response.AppendCookie(_cookie);
            }
        }

        /// <summary>
        /// 获取Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string GetCookie(string key)
        {
            var value = _cookie.Values[MD5Str(key)];
            return string.IsNullOrEmpty(value) ? "" : AESHelper.AESDecrypt(value);
        }

        /// <summary>
        /// 删除cookie
        /// </summary>
        /// <param name="key"></param>
        public void RemoveCookie()
        {
            _cookie.Expires = DateTime.Now.AddDays(-1);
            _response.SetCookie(_cookie);
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private static string MD5Str(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }

        /// <summary>
        /// 设置Cookie时间
        /// </summary>
        /// <param name="oCookie"></param>
        /// <param name="expires"></param>
        private static void SetCookieDate(HttpCookie oCookie, E_Time eTime)
        {
            switch (eTime + "")
            {
                case "一秒钟":
                    oCookie.Expires = DateTime.Now.AddSeconds(1); break;
                case "一分钟":
                    oCookie.Expires = DateTime.Now.AddMinutes(1); break;
                case "一小时":
                    oCookie.Expires = DateTime.Now.AddHours(1); break;
                case "一天":
                    oCookie.Expires = DateTime.Now.AddDays(1); break;
                case "一个月":
                    oCookie.Expires = DateTime.Now.AddMonths(1); break;
                case "一年":
                    oCookie.Expires = DateTime.Now.AddYears(1); break;
                case "永久":
                    oCookie.Expires = DateTime.MaxValue; break;
                default:
                    break;
            }
        }

        //public struct S_SetTime //结构
        //{
        //    private static string one = "一小时";
        //    private static string two = "一天";
        //}
    }

    public enum E_Time //枚举
    {
        一秒钟,
        一分钟,
        一小时,
        一天,
        一个月,
        一年,
        永久
    }
}