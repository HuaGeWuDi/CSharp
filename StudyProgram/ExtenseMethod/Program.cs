using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtenseMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Student stu = new Student("huage","男神",18);
            stu.GetStuInfo();
            Console.WriteLine(stu.GetAge().ToString().ToV8());
            Console.ReadKey();
        }
    }
}
