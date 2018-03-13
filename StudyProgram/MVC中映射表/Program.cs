using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudyProgram.Model;

namespace MVC中映射表
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new StudyProgram.LeiKu.TestDbContext())
            {
                //ctx.Database.Connection.Open();
                //var stu=ctx.Student.Where()   
                //Console.WriteLine(ctx.Database.Connection.ConnectionString);
                ctx.Students.Add(new Student()
                {
                    Name = "huage",
                    Age = 18,
                    Sex = "男神"
                });
                var temp = ctx.SaveChanges();
                if (temp > 0)
                    Console.WriteLine(ctx.Database.Connection.ConnectionString);

                var lst = from t in ctx.Students
                          select t;
                Console.ReadKey();
            }
        }
    }
}
