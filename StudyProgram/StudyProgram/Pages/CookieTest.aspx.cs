using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using StudyProgram.Common;
using System.Security.Cryptography;
using System.Text;

namespace StudyProgram.Pages
{
    public partial class CookieTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Add();
                Select();
                Update();
                Delete();
            }
        }

        private void Add()
        {
            CCHelper cookie = new CCHelper("user", E_Time.一天);
            cookie.SetCookie("huage", "wudi");
        }

        private void Select()
        {
            CCHelper cookie = new CCHelper("user");
            cookie.GetCookie("huage");
        }

        private void Update()
        {
            CCHelper cookie = new CCHelper("user");
            cookie.SetCookie("huage", "真是帅");
        }

        private void Delete()
        {
            CCHelper cookie = new CCHelper("user");
            cookie.RemoveCookie();

            var cook = Request.Cookies[MD5Str("user")];
        }

        private static string MD5Str(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            return BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(str))).Replace("-", "");
        }
    }
}