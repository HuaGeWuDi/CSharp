using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StudyProgram.LeiKu;
using Newtonsoft.Json;

namespace Cache缓存
{
    class Program
    {
        static void Main(string[] args)
        {
            //控制台无法接受数据依赖，详细见StudyProgram>pages>缓存
            var test = CacheUse.getCache("huage");
            Console.WriteLine(JsonConvert.SerializeObject(test));
            Console.ReadKey();
        }
    }
}
