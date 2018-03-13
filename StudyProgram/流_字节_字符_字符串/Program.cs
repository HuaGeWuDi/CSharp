using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace 流_字节_字符_字符串
{
    class Program
    {
        #region 简单介绍
        //流：二进制

        //字节：无符号整数

        //字符：Unicode编码字符

        //字符串：多个Unicode编码字符 
        #endregion
        static void Main(string[] args)
        {
            //byte a = 99;
            //byte b = 199;
            //byte c =(byte) (a + b);//这边溢出等于42
            //Console.WriteLine(c);

            string str = "huage1234";

            using (MemoryStream m_stream = new MemoryStream())
            {
                Console.WriteLine(string.Format("初始字符串:{0}", str));
                if (m_stream.CanWrite)//如果可写入
                {
                    byte[] strBytes = Encoding.Default.GetBytes(str);//string->byte[]
                    //从数组中的第一个位置开始写入，长度为3，写完之后stream里面有数据
                    m_stream.Write(strBytes, 0, 3);//byte[]->stream
                    Console.WriteLine("现在Stream.Postion在第{0}位置", m_stream.Position + 1);
                }
                byte[] resBytes = new byte[m_stream.Length];
                m_stream.Position = 0;//这边要设置一下stream的起始位置,不然读取的时候从不是起始位置读取到不全的数据
                var count = m_stream.Read(resBytes, 0, (int)resBytes.Length);//stream->byte[]
                var resStr = Encoding.Default.GetString(resBytes);//byte[]->字符串
                Console.WriteLine(resStr);
            }

            char[] charArr = str.ToCharArray();//string->char[]
            string res = new string(charArr);//char[]->stream

            string charStr = "";
            foreach (var a in charArr)  //char[]->stream
                charStr += a;

            byte[] charBytes = Encoding.Default.GetBytes(charArr);//char[]->byte[]
            char[] byteChar = Encoding.Default.GetChars(charBytes);//byte[]->char[]

            byte[] charBytes1 = new byte[charArr.Length];
            char[] byteChar1 = new char[charBytes1.Length];

            for (var i = 0; i < charArr.Length; i++)
                charBytes1[i] = Convert.ToByte(charArr[i]);//char[]->byte[]

            for (var j = 0; j < charBytes1.Length; j++)
                byteChar1[j] = Convert.ToChar(charBytes1[j]);//byte[]->char[]

            Console.ReadKey();
        }
    }
}
