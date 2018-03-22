using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace StudyProgram.Common
{
    public class AESHelper
    {
        public static string AESEncrypt(string text)
        {
            return AESEnc(text, KeyStruct.strKey);
        }

        public static string AESDecrypt(string text)
        {
            return AESDes(text, KeyStruct.strKey);
        }
        //加密
        private static string AESEnc(string text, string mkey)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Mode = CipherMode.ECB;
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.KeySize = 128;
                rijndael.BlockSize = 128;
                byte[] pwdBytes = Encoding.Default.GetBytes(mkey);
                byte[] keyBytes = new byte[16];
                int len = pwdBytes.Length > keyBytes.Length ? keyBytes.Length : pwdBytes.Length;
                Array.Copy(pwdBytes, keyBytes, len);
                rijndael.Key = keyBytes;
                using (ICryptoTransform tranform = rijndael.CreateEncryptor())
                {
                    byte[] txtBytes = Encoding.Default.GetBytes(text);                 
                    return Convert.ToBase64String(tranform.TransformFinalBlock(txtBytes, 0, txtBytes.Length));
                }
            }          
        }
        //解密
        private static string AESDes(string text, string key)
        {
            using (RijndaelManaged rijndael = new RijndaelManaged())
            {
                rijndael.Mode = CipherMode.ECB;
                rijndael.Padding = PaddingMode.PKCS7;
                rijndael.KeySize = 128;
                rijndael.BlockSize = 128;
                byte[] encryptedData = Convert.FromBase64String(text);
                byte[] pwdBytes = Encoding.Default.GetBytes(key);
                byte[] keyBytes = new byte[16];
                int len = pwdBytes.Length > keyBytes.Length ? keyBytes.Length : pwdBytes.Length;
                Array.Copy(pwdBytes, keyBytes, len);
                rijndael.Key = keyBytes;
                using (ICryptoTransform tranform = rijndael.CreateDecryptor())
                {
                    var a = tranform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                    return Encoding.Default.GetString(a);
                }
            }   
        }


        private  struct KeyStruct
        {
            public static string strKey = "huage";
        }
    }
}
