using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebFrom.MVC.Controllers
{
    public class TestController : Controller
    {
        public string GetMsg(string msg)
        {
            //var msg=Request[""]
            return msg+"测试成功";
        }
    }
}