using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 递归学习
{
    class Program
    {
        static void Main(string[] args)
        {
             //Dictionary<string, string> dict = new Dictionary<string, string>();
             //dict.Add("1", "huage");
             //dict.Add("2", "lisi");
             //dict.Add("3", "wangw");
             //var key = dict.Keys;//一个键的集合;
             //foreach (var k in key)
             //{                 
             //    Console.WriteLine(k);
             //    //if (dict.ContainsKey(k))
             //    //{
             //        var value="";
             //        dict.TryGetValue(k, out value);
             //        Console.WriteLine(value);
             //    //}
             //}

            for (var i = 0; i < 10; i++)
                Console.WriteLine(Fun(i));

            Console.ReadKey();
        }

        static int Fun(int x)
        {
            return x == 0 ? 0 : 2 * (Fun(x - 1)) + x * x;
        }
    }
}
