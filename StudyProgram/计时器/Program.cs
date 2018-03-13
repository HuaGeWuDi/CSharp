using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;

namespace 计时器
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Timers.Timer my_Timer = new System.Timers.Timer();
            my_Timer.Elapsed += new System.Timers.ElapsedEventHandler(TimeEvent);
            my_Timer.Interval = 1000; // 设置引发时间的时间间隔　此处设置为１秒（１０００毫秒）
            my_Timer.Enabled = true;
            //Console.WriteLine();
            Console.ReadKey();
        }
        public static void TimeEvent(object source, ElapsedEventArgs e)
        {
            DateTime date = e.SignalTime;
            int Hour = 24;
            int Min = 00;
            int Sec = 00;
            if (date.Second == Sec && date.Minute == Min && date.Hour == Hour)
            {
                //24点开始执行什么工作

            }
            //fnStreamWriter(date.ToString("yyyy-MM-dd HH:mm:ss"));
            Console.WriteLine(date.ToString("yyyy-MM-dd HH:mm:ss"));            
        }
        public static void fnStreamWriter(string str)
        {

        
            var path = @"E:\VS2010学习\StudyProgram\计时器";
            var directoyName = "计时器记事本.txt";
            var conbineName = Path.Combine(path, directoyName);
            FileStream fs = new FileStream(conbineName, FileMode.Append);  
            StreamWriter streamWriter = new StreamWriter(fs);
            fs.Close();
            fs.Dispose();//各种流之间最好用using来使用
            streamWriter.WriteLine(str);        
            streamWriter.Close();//关闭流
            streamWriter.Dispose();//释放流


            FileStream filestream = new FileStream(conbineName,FileMode.OpenOrCreate,FileAccess.ReadWrite);
            filestream.Write(null, 0, 0);
            filestream.Seek(0, SeekOrigin.Begin);
            filestream.Close();            
            filestream.Dispose();
        }
    }
}
