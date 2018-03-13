using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AES_DES加解密
{
    class Program
    {
        static void Main(string[] args)
        {
            #region AES加解密
            var aesEncryptStr = AESHelper.AESEncrypt("wudi");
            Console.WriteLine("AES加密后字符串：{0}", aesEncryptStr);
            Console.WriteLine("AES解密后字符串：{0}", AESHelper.AESDecrypt(aesEncryptStr)); 
            #endregion


            #region DES加解密
            var desEncryptStr = StudyProgram.LeiKu.DesHelper.DesEncrypt("huage");
            Console.WriteLine("DES加密后字符串：{0}", desEncryptStr);
            Console.WriteLine("DES解密后字符串：{0}", StudyProgram.LeiKu.DesHelper.DesDescript(desEncryptStr)); 
            #endregion

            Console.ReadKey();
        }
    }
}
