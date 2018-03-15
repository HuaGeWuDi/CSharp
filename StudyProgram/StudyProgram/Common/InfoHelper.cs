using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace StudyProgram.Common
{
    public class InfoHelper
    {
        private static string LoginInfo = "LoginInfo";

        public static void SetLoginInfo(LoginModel loginInfo)
        {
            SSHelper.SetSession(LoginInfo, loginInfo);         
        }

        public static LoginModel GetLoginInfo()
        {
            object info = SSHelper.GetSession(LoginInfo);
            LoginModel loginModel = info as LoginModel;
            return loginModel;
        }
    }

    public class LoginModel
    {
        public string LoginNum { get; set; }
        public string LoginName { get; set; }
    }
}