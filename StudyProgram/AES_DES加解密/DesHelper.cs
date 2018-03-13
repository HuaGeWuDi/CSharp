using System

;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace AES_DES加解密
{
    public class DesHelper
    {
        private static string desKey = "huage";
        public static string DesEncrypt(string text)
        {
            return DesEnc(text, desKey);
        }
        private static string DesEnc(string text, string dkey)
        {
            using (DESCryptoServiceProvider descry = new DESCryptoServiceProvider())
            {
                byte[] txtBytes = Encoding.Default.GetBytes(text);
                byte[] keyBytes = ASCIIEncoding.ASCII.GetBytes(dkey);
                descry.Key = keyBytes;
                descry.IV = keyBytes;  //获取或设置对称算法的初始化向量,这边默认向量为key
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, descry.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(txtBytes, 0, txtBytes.Length);
                        cs.FlushFinalBlock();
                    }
                        //StringBuilder ret = new StringBuilder();
                        //foreach (byte b in ms.ToArray())
                        //{
                        //    ret.AppendFormat("{0:X2}", b);
                        //}
                    return Convert.ToBase64String(ms.ToArray());
                }
            }            
        }

        //private static string DesDes(string text, string dkey)
        //{
        //    using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        //    {
        //        byte[] txtBytes = Convert.FromBase64String(text);
        //        //des.Key=ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.
        //        //        HashPasswordForStoringInConfigFile(dkey, "MD5").Substring(0, 8))
        //    }
        //}

        #region base64字符串互转
        //        c#中 base64字符串与普通字符串互转

        //转成 Base64 形式的 System.String:
        //    string a = "base64字符串与普通字符串互转";  
        //    byte[] b = System.Text.Encoding.Default.GetBytes(a);      
        //    //转成 Base64 形式的 System.String  
        //    a = Convert.ToBase64String(b);  
        //    Response.Write(a);  

        //转回到原来的 System.String:


        //    byte[] c = Convert.FromBase64String(a);  
        //    a = System.Text.Encoding.Default.GetString(c);  
        //    Response.Write(a); 
        #endregion
    }
}
