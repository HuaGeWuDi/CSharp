using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zip压缩与解压
{
    class Program
    {
        static void Main(string[] args)
        {

            var str = @"\学籍导入模板.xls";
            //var arr=str.Split('\\');

            var filePath = @"D:\程序文件\VS2010学习\StudyProgram\zip压缩与解压\File\学籍导入模板.xls";
            //ZipHelper.ZipFile(filePath, @"D:\程序文件\VS2010学习\StudyProgram\zip压缩与解压\File\test.zip", 6, "123");
            var dirPath = @"D:\程序文件\VS2010学习\StudyProgram\zip压缩与解压";
            //ZipHelper.ZipDir(dirPath + @"\File", dirPath + @"\File.zip", 6, "huage");

            ZipHelper.UnZip(dirPath + @"\File.zip", dirPath + @"\test", "huage");

            Console.ReadKey();
        }
    }
}
