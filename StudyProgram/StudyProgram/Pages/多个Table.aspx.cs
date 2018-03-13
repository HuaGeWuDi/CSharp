using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace StudyProgram.Pages
{
    public partial class 多个Table : System.Web.UI.Page
    {
        public static string pageTitle;
        public static string[] strArr;
        protected void Page_Load(object sender, EventArgs e)
        {
            pageTitle = "无敌";
            List<string> arrList = new List<string>();
            for (var i = 0; i < 10; i++)
            {
                var temp = (i + 1) > 10 ? (i + 1) + "" : "0" + i;
                arrList.Add("2017" + temp);
            }      
            strArr = arrList.ToArray();            
        }
    }
}