using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudyProgram.WebService
{
    public class MySoapHeader : System.Web.Services.Protocols.SoapHeader
    {
        private string username;
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public MySoapHeader() { }

        public MySoapHeader(string Name, string Pawd)
        {
            this.UserName = Name;
            this.Password = Pawd;
        }

        public bool Validation(MySoapHeader _MySoapHeader)
        {
            var res = false;
            if (_MySoapHeader.UserName == "huage" && _MySoapHeader.Password == "123")
                res = true;

            return res;
        }
    }
}