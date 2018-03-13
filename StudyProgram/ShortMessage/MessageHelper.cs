using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace ShortMessage
{
    public class MessageHelper
    {
        private string url = @"http://utf8.api.smschinese.cn/";
        private string userid = "hualintianxia";
        private string key;
        private string smsMob;
        private string smsText;
        public MessageHelper(bool isMD5, string userid, string key, string mob, string text)
        {
            this.userid = "/?Uid=" + userid;
            this.key = isMD5 ? "&KeyMD5=" + GetMD5Str(key) : "&Key=" + key;
            this.smsMob = "&smsMob=" + mob;
            this.smsText = "&smsText=" + text;
        }

        //MD5加密
        private string GetMD5Str(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            StringBuilder sbStr = new StringBuilder();
            byte[] buffer = Encoding.Default.GetBytes(str);
            byte[] dataBuff = md5.ComputeHash(buffer);//计算指定字符数组的哈希值

            foreach (byte d in dataBuff)
                sbStr.Append(d.ToString("x2"));

            return (sbStr + "").ToUpper();
        }

        public void Send()
        {
            var targetUrl = url + userid + key + smsMob + smsText;
            //HttpCurrent
            //详细见StudyProgram/LeiKu/MessageHelper.cs            
        }


        private struct m_Struct
        {
            public static string huage1 = "huage1";
            public static string huage2 = "huage2";
            public static string huage3 = "huage3";

        }



        private enum Result
        {
            没有该用户账户 = -1,
            接口密钥不正确 = -2,
            MD5接口密钥加密不正确 = -21,
            短信数量不足 = -3,
            该用户被禁用 = -11,
            短信内容出现非法字符 = -14,
            手机号格式不正确 = -4,
            手机号码为空 = -41,
            短信内容为空 = -42,
            短信签名格式不正确 = -51,
            IP限制 = -6
        }
    }
}
