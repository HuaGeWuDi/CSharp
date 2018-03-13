using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Text.RegularExpressions;
using StudyProgram.Controllers;
using System.Web.Routing;
using System.Web.Mvc;

namespace StudyProgram
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            Application["starttime"] = DateTime.Now;//在程序初始化的时候执行。在Web应用程序的生命周期里就执行一次，这里只能放一些公用的信息，比如HttpApplicationState。 

            //MVC路由设置
            AreaRegistration.RegisterAllAreas();
            RouteControl.RegisterRouters(RouteTable.Routes);
        }

        void Application_End(object sender, EventArgs e)
        {
            //  在应用程序关闭时运行的代码

        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码

        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码

        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。 
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer 
            // 或 SQLServer，则不会引发该事件。

        }

        void Application_BeginRequest(object sender, EventArgs e)
        {
            var request = Request;//BeginRequest是在收到Request时第一个触发的事件，这个方法第一个执行
            //1.BeginRequest 2.AuthenticateRequest 3.AuthorizeRequest 
            //4.ResolveRequestCache 5.AcquireRequestState 6.PreRequestHandlerExecute 
            //7.PostRequestHandlerExecute 8.ReleaseRequestState 9.UpdateRequestCache 10.EndRequest 

            Match match = Regex.Match(Context.Request.Path, @"^/Pages/testurl\-(\d+)\.aspx$");
            if (match.Success)
            {
                string id = match.Groups[1].Value;//拿到（\d+）就是id 的值   
                Context.RewritePath("/Pages/testurl.aspx?id=" + id);
            }
        }


        #region Global事件详解
        //         protected void Application_Start(object sender, EventArgs e)
        //           {
        //               //不是每次请求都调用
        //               //在Web应用程序的生命周期里就执行一次
        //               //在应用程序第一次启动和应用程序域创建事被调用
        //               //适合处理应用程序范围的初始化代码
        //           }
        // 
        //          void Application_End(object sender, EventArgs e)
        //          {
        //              //不是每次请求都调用
        //              //在应用程序关闭时运行的代码，在最后一个HttpApplication销毁之后执行
        //              //比如IIS重启，文件更新，进程回收导致应用程序转换到另一个应用程序域
        //          }
        //  
        //          void Session_Start(object sender, EventArgs e)
        //          {
        //              //不是每次请求都调用
        //              //会话开始时执行
        //          }
        //  
        //          void Session_End(object sender, EventArgs e)
        //          {
        //              //不是每次请求都调用
        //              //会话结束或过期时执行
        //              //不管在代码中显式的清空Session或者Session超时自动过期，此方法都将被调用
        //          }
        //  
        //          void Application_Init(object sender, EventArgs e)
        //          {
        //              //不是每次请求都调用
        //              //在每一个HttpApplication实例初始化的时候执行
        //          }
        //  
        //          void Application_Disposed(object sender, EventArgs e)
        //          {
        //              //不是每次请求都调用
        //              //在应用程序被关闭一段时间之后，在.net垃圾回收器准备回收它占用的内存的时候被调用。
        //              //在每一个HttpApplication实例被销毁之前执行
        //          }
        //  
        //          void Application_Error(object sender, EventArgs e)
        //          {
        //              //不是每次请求都调用
        //              //所有没有处理的错误都会导致这个方法的执行
        //          }
        //  
        //  
        //          /*********************************************************************/
        //          //每次请求都会按照顺序执行以下事件
        //          /*********************************************************************/
        //  
        //          void Application_BeginRequest(object sender, EventArgs e)
        //          {
        //              //每次请求时第一个出发的事件，这个方法第一个执行
        //          }
        //  
        //          void Application_AuthenticateRequest(object sender, EventArgs e)
        //          {
        //              //在执行验证前发生，这是创建验证逻辑的起点
        //          }
        //  
        //          void Application_AuthorizeRequest(object sender, EventArgs e)
        //          {
        //              //当安全模块已经验证了当前用户的授权时执行
        //          }
        //  
        //          void Application_ResolveRequestCache(object sender, EventArgs e)
        //          {
        //              //当ASP.NET完成授权事件以使缓存模块从缓存中为请求提供服务时发生，从而跳过处理程序（页面或者是WebService）的执行。
        //              //这样做可以改善网站的性能，这个事件还可以用来判断正文是不是从Cache中得到的。
        //          }
        //  
        //          //------------------------------------------------------------------------
        //          //在这个时候，请求将被转交给合适程序。例如：web窗体将被编译并完成实例化
        //          //------------------------------------------------------------------------
        //  
        //          void Application_AcquireRequestState(object sender, EventArgs e)
        //          {
        //              //读取了Session所需的特定信息并且在把这些信息填充到Session之前执行
        //          }
        //  
        //          void Application_PreRequestHandlerExecute(object sender, EventArgs e)
        //          {
        //              //在合适的处理程序执行请求前调用
        //              //这个时候，Session就可以用了
        //          }
        //  
        //          //-------------------------------------------------
        //          //在这个时候，页面代码将会被执行，页面呈现为HTML
        //          //-------------------------------------------------
        //  
        //          void Application_PostRequestHandlerExecute(object sender, EventArgs e)
        //          {
        //              //当处理程序完成对请求的处理后被调用。
        //          }
        //  
        //         void Application_ReleaseRequestState(object sender, EventArgs e)
        //         {
        //             //释放请求状态
        //         }
        // 
        //         void Application_UpdateRequestCache(object sender, EventArgs e)
        //         {
        //             //为了后续的请求，更新响应缓存时被调用
        //         }
        // 
        //         void Application_EndRequest(object sender, EventArgs e)
        //         {
        //             //EndRequest是在响应Request时最后一个触发的事件
        //             //但在对象被释放或者从新建立以前，适合在这个时候清理代码
        //         }
        // 
        //         void Application_PreSendRequestHeaders(object sender, EventArgs e)
        //         {
        //             //向客户端发送Http标头之前被调用
        //         }
        // 
        //         void Application_PreSendRequestContent(object sender, EventArgs e)
        //         {
        //             //向客户端发送Http正文之前被调用
        //         }
        #endregion
    }
}
