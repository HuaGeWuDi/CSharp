using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Reflection;
using Newtonsoft.Json;

namespace StudyProgram.Pages
{
    public partial class testWebMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var request = Request;
            //var method = Request["method"];          
            ////var a = Request.QueryString;//get方式的集合
            ////var b = Request.Form;//post方式的集合
            ////var c = Request.Cookies;//cookies方式的集合
            ////var d = Request.Params;//所有方式包括cookie        
            //if (method != null)
            //{
            //    ////var args = a.GetValues(null);
            //    ////获取URL中的传值
            //    //var parmStr = "";
            //    //foreach (var rq in a.AllKeys)
            //    //    parmStr += Request[rq] + ",";

            //    //parmStr = parmStr.TrimEnd(',');
            //    //string[] parms = parmStr.Split(',');

            //    var nameSpace = MethodBase.GetCurrentMethod().DeclaringType.Namespace;//获取当前类的命名空间
            //    var className = MethodBase.GetCurrentMethod().DeclaringType.FullName;//取得当前方法类全名 包括命名空间                 
            //    Type testType = Type.GetType(className);//这边字符串必须是命名空间+'.'+类名（也就是类的全名）

            //    var type = GetType().GetMethod(method, BindingFlags.Instance | BindingFlags.Public).Invoke(this, null);//这里的意思是使用的时候,一定要同BindingFlag.Public 或者 BindingFlag.NonPublic 配合 BindingFlags.Instance 或者 BindingFlags.Static
            //    if (testType != null)
            //    {
            //        object instance = Activator.CreateInstance(testType);//使用指定类型来创建该类型的实例，以便于调用实例下面的方法
            //        MethodInfo methodInfo = testType.GetMethod(method);
            //        var res = methodInfo.Invoke(method, null) + "";
            //        if (res != "")
            //        {
            //            Response.Write(res);
            //            ////将当前所有缓冲的输出发送到客户端，停止该页的执行，如果没有这一步的话，程序还会往后执行，除了把data输出到客户端之外，还会将webForm1.aspx里面的html代码都输出到页面。
            //            Response.End();
            //        }
            //    }
            //}

            #region  映射Ajax请求方法
            //var method = Request["method"];
            //if (method != null)
            //{
            //    try
            //    {
            //        var res = this.GetType().GetMethod(method, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).Invoke(this, null);//指定public修饰的静态成员和实例成员
            //        if (res != null)
            //            Response.Write(res);
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write(JsonConvert.SerializeObject(ex));
            //    }
            //    Response.End();//将当前所有缓冲输出到客户端，停止该页的执行
            //}
            #endregion

            //等于上述代码，写成通用方法
            Common.Common.GetJsonByPage(this, "method");
        }

        [WebMethod]
        public static string GetMsgByWeb()
        {           
            return  "Hello Word";
        }

        public string GetMsgByWeb1()
        {
            var id = Request["id"];
            return (id ?? "") + " Hello Word";
        }
    }
}