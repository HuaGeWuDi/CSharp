using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyProgram.Controllers.Controller
{
    public class TestController : System.Web.Mvc.Controller
    {
        public string GetText()
        {
            var str =Request["value"] + "";

            this.Server.Transfer("");

            
           
            return str;           
        }
    }
}