using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using StudyProgram.Model;

namespace StudyProgram.LeiKu
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
            : base("name=DataConnection")
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}