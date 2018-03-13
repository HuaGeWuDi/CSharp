using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace MVC中映射表
{
    public class TestDbContext : DbContext
    {
        public TestDbContext()
            : base("DataConnection")
        {
            //详情见StudyProgram中的LeiKu
        }
    }
}
