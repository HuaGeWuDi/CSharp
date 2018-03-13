using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;

namespace StudyProgram.Controllers
{
    public static class RouteControl
    {
        public static void RegisterRouters(RouteCollection routes)
        {
            //routes.MapPageRoute(
            //    "Controller",
            //    "{Controller}/{parameter}",
            //    "~/{Controller}/{webform}.aspx"
            //   );
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}/{id}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );
        }
    }
}