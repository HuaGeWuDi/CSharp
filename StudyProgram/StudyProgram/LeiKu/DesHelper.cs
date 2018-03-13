using System

;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace StudyProgram.LeiKu
{
    public class DesHelper
    {
        private static string desKey = "huage";
        public static string DesEncrypt(string text)
        {
            return DesEnc(text, desKey);
        }
        public static string DesDescript(string text)
        {
            return DesDes(text, desKey);
        }
        private static string DesEnc(string text, string dkey)
        {
            using (DESCryptoServiceProvider descry = new DESCryptoServiceProvider())
            {
                byte[] txtBytes = Encoding.Default.GetBytes(text);
                byte[] keyBytes =ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.
                    HashPasswordForStoringInConfigFile(dkey, "MD5").Substring(0, 8));              
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

        private static string DesDes(string text, string dkey)
        {
            try
            {
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    byte[] txtBytes = Convert.FromBase64String(text);
                    des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.
                             HashPasswordForStoringInConfigFile(dkey, "MD5").Substring(0, 8));
                    des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.
                          HashPasswordForStoringInConfigFile(dkey, "MD5").Substring(0, 8));
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(txtBytes, 0, txtBytes.Length);
                            cs.FlushFinalBlock();
                            return Encoding.Default.GetString(ms.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}
