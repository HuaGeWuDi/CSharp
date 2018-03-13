using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Diagnostics;

namespace 输出一到一百的勾股数
{
    class Program
    {
        static void Main(string[] args)
        {
            //ccc();
            Stopwatch stopwathc = new Stopwatch();
            stopwathc.Start();
            ConsoleGGS();
            stopwathc.Stop();
            Console.WriteLine("运行时间" + stopwathc.Elapsed);
            Console.ReadKey();
            //MailMessage
        }

        public static void ConsoleGGS()
        {
            for (var a = 1; a <= 100; a++)
            {
                for (var b = 1; b <= 100; b++)
                {
                    for (var c = 1; c <= 100; c++)
                    {
                        if (a < b && b < c && (a * a + b * b) == c * c)
                        {
                            Console.WriteLine(string.Format("勾股数：{0}，{1}，{2}", a, b, c));
                        }
                    }
                }
            }
        }

        public static void ccc()
        {
            for (var i = 1; i < 100; i++)
            {
                for (var j = 1; j < 100; j++)
                {
                    for (var h = 1; h < 100; h++)
                    {
                        if (i < j && j < h && (i * i + j * j == h * h))
                        {
                            Console.WriteLine(string.Format("{0},{1},{2}", i, j, h));
                        }
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
