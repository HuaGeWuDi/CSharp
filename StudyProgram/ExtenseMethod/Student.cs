using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtenseMethod
{
    public class Student
    {
        public Student() { }
        public Student(string name, string sex, int age)
        {
            this.Name = name;
            this.Sex = sex;
            this.Age = age;
        }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int Age { get; set; }
    }

    public static class Test
    {
        public static int GetAge(this Student stu)
        {
            return stu.Age;
        }

        public static string ToV8(this string str)
        {
            return @"user:\" + str;
        }
    }
}
