using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace StudyProgram.WebService
{
    /// <summary>
    /// MyWebService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class MyWebService : PageBaseWebservice
    {
        public MySoapHeader _MySoapHeader;
        [WebMethod(Description = "验证测试", CacheDuration = 0, BufferResponse = true)]

  
        [System.Web.Services.Protocols.SoapHeader("_MySoapHeader")]
        public string HelloWorld()
        {
            var msg = "";
            if (Validation())
                msg = "Hello World";
            else
                msg = "你没有权限";
            return msg;
        }


        //WebService.MySoapHeader my_soap = new WebService.MySoapHeader();

        public WebService.MySoapHeader my_soap;
        [System.Web.Services.Protocols.SoapHeader("my_soap")]//必须要加上

        public string Test()
        {
            var msg = "";
            if (my_soap.Validation(my_soap)) msg = "验证通过";
            else msg = "您没有权限";
            return msg;
        }
    }
}
