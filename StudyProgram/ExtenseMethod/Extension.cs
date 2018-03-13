using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using ExtenseMethod.Student;

namespace ExtenseMethod
{
    public static class Extension
    {
        public static void GetStuInfo(this Student stu)
        {
            Console.WriteLine("我是{0}学生,今年{1},性别{2}", stu.Name, stu.Age, stu.Sex);
        }
    }
}
