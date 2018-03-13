using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Collections;
using System.Data;

namespace Temp
{
    class Program
    {
        static void Main(string[] args)
        {

            #region 线程测试
            Thread t1 = new Thread(() =>
            {
                Console.Write("pa");
            });
            Thread t2 = new Thread(() =>
            {
                Console.Write("ra");
            });
            t1.Start();
            t2.Start();
            Console.WriteLine();
            #endregion

            #region 循环测试
            List<string> list = new List<string> { "A", "B", "C" };
            List<string> list1 = new List<string> { "A1", "B1", "C1", "A2", "B2", "C2" };
            List<string> list2 = new List<string> { "A11", "B11", "C11", "A12", "B12", "C12", "A21", "B21", "C21", "A22", "B22", "C22" };
            var fl = new List<string>();

            //第一次
            foreach (var o in list)
            {
                //第二次
                fl = list1.FindAll(d => d.Contains(o));
                foreach (var one in fl)
                {
                    //第三次
                    fl = list2.FindAll(d => d.Contains(one));
                    foreach (var two in fl)
                    {
                        Console.Write(two + "    ");
                    }
                    Console.WriteLine("\n");
                }
            }
            #endregion

            #region C#中的GUID
            Guid guid = Guid.NewGuid();
            var res = guid.ToString();
            Console.WriteLine("Guid:{0},长度是{1}", res, res.Length);

            var res1 = res.Replace("-", "").ToUpper();
            Console.WriteLine("改变过后的GUID：{0},长度是{1}", res1, res1.Length);
            Console.WriteLine();


            var uuid = guid.ToString(); // 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
            Console.WriteLine("1:{0},长度：{1}", uuid, uuid.Length);

            var uuidN = guid.ToString("N"); // e0a953c3ee6040eaa9fae2b667060e09 
            Console.WriteLine("2:{0},长度：{1}", uuidN, uuid.Length);

            var uuidD = guid.ToString("D"); // 9af7f46a-ea52-4aa3-b8c3-9fd484c2af12
            Console.WriteLine("3:{0},长度：{1}", uuidD, uuid.Length);

            var uuidB = guid.ToString("B"); // {734fd453-a4f8-4c5d-9c98-3fe2d7079760}
            Console.WriteLine("4:{0},长度：{1}", uuidB, uuid.Length);

            var uuidP = guid.ToString("P"); //  (ade24d16-db0f-40af-8794-1e08e2040df3)
            Console.WriteLine("5:{0},长度：{1}", uuidP, uuid.Length);

            var uuidX = guid.ToString("X"); // {0x3fa412e3,0x8356,0x428f,{0xaa,0x34,0xb7,0x40,0xda,0xaf,0x45,0x6f}}
            Console.WriteLine("6:{0},长度：{1}", uuidX, uuid.Length);
            Console.WriteLine();

            #endregion

            #region MD5
            MD5 md5 = new MD5CryptoServiceProvider();
            var md5Str = BitConverter.ToString(md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes("huage wudi")));
            var strRes = md5Str.Replace("-", "");
            Console.WriteLine();
            #endregion

            #region 判断集合数组中是否存在重复值
            var ss = new string[] { "a", "c", "b", "d", "e", "f", "g", "h", "i", "j", "k", "c" };

            var r1 = ss.GroupBy(a => a).Where(b => b.Count() > 1);

            Stopwatch watch = new Stopwatch();
            watch.Start();
            var r2 = ss.GroupBy(c => c).Where(a => a.Count() >= 1).Count() >= 1;
            watch.Stop();
            Console.WriteLine("Linq 所用时间为 ：{0} ", watch.Elapsed);


            watch.Reset();
            watch.Start();
            bool r3 = ss.Distinct().Count() < ss.Count();
            watch.Stop();
            Console.WriteLine("Linq Distinct 所用时间为 ：{0} ", watch.Elapsed); //这个速度更快


            watch.Reset();
            watch.Start();
            var r4 = ss.Where(c => ss.Contains(c)).Count() > 0;
            watch.Stop();
            Console.WriteLine("Linq Contains 所用时间为 ：{0} ", watch.Elapsed); //这个速度更快

            watch.Reset();
            watch.Start();
            IsExist(ss);
            watch.Stop();
            Console.WriteLine("方法 所用时间为 ：{0} ", watch.Elapsed);
            Console.WriteLine();

            //总的来说，Linq方法简单试用范围广
            //方法运行速度较快，但是但是不适用其他的集合

            #endregion

            #region 测试题
            A aa = new A();
            B bb = new B();

            aa.Fun2(bb);
            bb.Fun2(aa);
            Console.WriteLine();

            //C cc = new C();
            //D dd = new D();
            //dd.ConsoleStr();


            Console.WriteLine("X;{0},Y:{1}", C.X, D.Y);//这边是一个一个初始化

            D.ConsoleStr();//这个是先初始化D
           
            F.MainLine();
            #endregion

            Console.ReadKey();
        }

        static bool IsExist(string[] strArr)
        {
            Hashtable ht = new Hashtable();

            foreach (var s in strArr)
            {
                if (ht.Contains(s))
                {
                    return true;
                }
                else
                {
                    ht.Add(s, s);
                }
            }
            return false;
        }



        public class A
        {
            public virtual void Fun1(int i)
            {
                Console.WriteLine(i);
            }

            public void Fun2(A a)
            {
                a.Fun1(1);  //以传递进来的对象选择哪个Fun1

                Fun1(5);    //以调用此方法的对象选择哪个Fun1
            }
        }

        public class B : A
        {
            public override void Fun1(int i)
            {
                base.Fun1(i + 1);
            }

            //public static void Main()

            //{
            //    B b = new B();

            //    A a = new A();

            //    a.Fun2(b); //输出2,5

            //    b.Fun2(a);//1,6
            //}
        }

        public class C
        {
            public static int X;
            static C()
            {
                X = D.Y + 1;
            }
        }

        public class D
        {
            public static int Y = C.X + 1;
            static D() { }

            public static void ConsoleStr()
            {
                Console.WriteLine("X;{0},Y:{1}", C.X, D.Y);
            }
        }


        class E
        {
            public static int X;

            static E()
            {
                X = F.Y + 1;
            }
        }

        class F
        {
            public static int Y = E.X + 1;

            static F() { }

            public static void MainLine()
            {
                Console.WriteLine("X={0},Y={1}", E.X, F.Y);
                Console.WriteLine("Y:{0},X:{1}", F.Y, E.X);
            }
        }
    }
}
