using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
#pragma warning disable 1591

namespace StudyProgram.WebService
{
    /// <summary>
    /// PageBaseWebservice 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class PageBaseWebservice : System.Web.Services.WebService
    {
        /// <summary>
        /// 
        /// </summary>
        public class MySoapHeader : System.Web.Services.Protocols.SoapHeader
        {           
            /// <summary>
            /// 
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string Password { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public MySoapHeader()
            {

            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="Name"></param>
            /// <param name="Password"></param>
            public MySoapHeader(string Name, string Password)
            {
                this.Name = Name;
                this.Password = Password;
            }
        }

        public MySoapHeader _MySoapHeader;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_MySoapHeader"></param>
        /// <returns></returns>
        [WebMethod(Description = "验证权限", CacheDuration = 0, BufferResponse = true)]       
        public bool Validation()
        {
            var res = false;
            if (_MySoapHeader != null)
            {
                if (_MySoapHeader.Name == "huage" && _MySoapHeader.Password == "123")
                    res = true;
            }
            return res;
        }
    }
}
