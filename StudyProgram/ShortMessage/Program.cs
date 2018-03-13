using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShortMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            StudyProgram.LeiKu.MessageHelper msh = new StudyProgram.LeiKu.MessageHelper(true, "hualintianxia", "226d252a0453e1e6e044", "17626035642", "亲爱的达秀，您的宝贝花花向你说了声我爱你? 【华哥】");
            var res = msh.GetSendStr();
            Console.WriteLine(res);
            Console.ReadLine();
        }
    }
}
