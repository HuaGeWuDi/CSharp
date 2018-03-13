//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace stock.Domain
//{
//    public class Vault
//    {
////        public decimal Money => money;
////        public decimal InitialMoney => initialMoney;
////        public Transaction CurrentTransaction => currentTransaction;

////这些写法是 C# 6.0才支持的。如果你用vs2013或更早，需要修改为
////public decimal Money { get  { return money; } }


//          //public decimal Money => money;
//       public decimal Money { get  { return money; } }
//        public decimal InitialMoney { get  { return money; } }
//        //public decimal InitialMoney => initialMoney;
//        //public Transaction CurrentTransaction => currentTransaction;
//        public Transaction CurrentTransaction { get{return currentTransaction } }
//        private decimal money { get; set; }
//        private decimal initialMoney { get; set; }
//        private Transaction currentTransaction { get; set; }
//        readonly Func<decimal, decimal> computeBankFees;

//        private List<Transaction> transactions
//        {
//            get;
//            set;
//        }

//        public Vault(decimal initialAmount, Func<decimal, decimal> computeBankFees)
//        {
//            if (computeBankFees == null)
//                throw new ArgumentNullException("computeBankFees");

//            this.initialMoney = initialAmount;
//            this.computeBankFees = computeBankFees;
//            this.money = initialAmount;

//            this.transactions = new List<Transaction>();
//        }

//        public decimal GetMargin()
//        {
//            return this.Money - this.InitialMoney;
//        }

//        public void DisplaySummary()
//        {
//            Console.WriteLine("Summary - Current Position:{0:C2} - Margin:{1:C2}", this.Money, GetMargin());
//            Console.WriteLine();
//        }

//        public decimal GetTotalBankFees()
//        {
//            return transactions.Sum(t => t.BankFee);
//        }

//        public int GetTransactionCount()
//        {
//            return transactions.Count();
//        }

//        public bool Add(Transaction transaction)
//        {
//            transaction.BankFee = computeBankFees(transaction.GetAmount());

//            if (transaction is BuyTransaction)
//            {
//                //Have enough Money ?
//                if (this.currentTransaction == null && (transaction.GetAmount() + transaction.BankFee) <= money)
//                {
//                    this.transactions.Add(transaction);

//                    money -= transaction.GetAmount() + transaction.BankFee;
//                    currentTransaction = transaction;

//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            else if (transaction is SellTransaction)
//            {
//                //Have enough titles ?
//                if (this.currentTransaction != null && transaction.Count <= this.currentTransaction.Count)
//                {
//                    this.transactions.Add(transaction);

//                    money += transaction.GetAmount() - transaction.BankFee;
//                    transaction.LinkedTransaction = currentTransaction;
//                    currentTransaction = null;

//                    return true;
//                }
//                else
//                {
//                    return false;
//                }
//            }
//            else
//            {
//                return false;
//            }
//        }
//    }
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.IO;
using System.Diagnostics;
using StudyProgram.Common;
using System.Data;

namespace TempControl
{
    class Program
    {
        static void Main(string[] args)
        {
            //object a = null;
            //var b = "";
            //try
            //{
            //    if (a.ToString() != b)
            //    {

            //    }
            //}
            //catch (Exception e)
            //{

            //    Console.WriteLine(e);
            //}
            //Console.ReadKey();

            //Console.Write(DateTime.Now.ToString());

            //var sayStr="Hellow,Word!";
            //var str=$"hauge,{sayStr}";//C#6.0 可以使用与string.formart差不多


            //Stopwatch swatch = new Stopwatch();
            //swatch.Start();
            //var path = @"D:\程序文件\VS2010学习\StudyProgram\TempControl\专业学位上报照片";
            //var path1 = @"D:\程序文件\VS2010学习\StudyProgram\TempControl\学历博士学位上报照片";
            //Console.WriteLine(GetPhotoCount(path));
            //Console.WriteLine(GetPhotoCount(path1));
            //swatch.Stop();
            //Console.WriteLine("读取两个文件夹所需时间："+swatch.ElapsedMilliseconds+"毫秒");

            //swatch.Restart();
            //Console.WriteLine("***********c#一个&符号的作用是***********");
            //Console.WriteLine("输入这个两个方法的结果是:{0}", Method1() & Method2());

            //Console.WriteLine("***********c#一个&符号的作用是***********");
            //Console.WriteLine("输入这个两个方法的结果是:{0}", Method1() && Method2()); 
            //swatch.Stop();
            //Console.WriteLine("查看两个方法所需时间：" + swatch.ElapsedMilliseconds + "毫秒");


            var a = fnGetList(2, 8);

            foreach (var b in a)
            {
                Console.WriteLine(b);
            }


            var te = "";
            object t = null;
            var res = te ?? "0";
            var r = t ?? "0";

            //Stopwatch stw = new Stopwatch();
            //stw.Start();

            //var pros_m = typeof(Model).GetProperties();
            //var pros_d = typeof(DangAn).GetProperties();
            //var connStr = "server=.;database=AnHuiYKD;user id=sa;pwd=123";
            //for (var i = 0; i < pros_m.Length; i++)
            //    DBHelper.ExecuteNonQuery(connStr, CommandType.Text, string.Format(" insert into DA_Data select '{0}','{1}' ", pros_m[i].Name, pros_d[i].Name));

            //stw.Stop();

            //Console.WriteLine("运行成功总时间" + stw.Elapsed);
            Console.ReadKey();
        }

        public static int GetPhotoCount(string url)
        {
            var files = Directory.GetFiles(url);
            return files.Count();
            
        }

        static bool Method1()
        {
            Console.WriteLine("这是方法一的输出");
            return true;
        }
        static bool Method2()
        {
            Console.WriteLine("这是方法二的输出");
            return false;
        }


        //yield关键字
        static IEnumerable<int> fnGetList(int a, int b)//IEnumerable  IEnumerator
        {
            int res=1;
            List<int> list = new List<int>();

            for (var i = 0; i < b; i++)
            {
                res = res * a;
                list.Add(res);
                //yield return res;
            }
            return list;
        }

        static bool IntTest(int start, int end)
        {
            return start < end;
        }
    }


    public class Model
    {
        public string 学号 { get; set; }
        public string 姓名 { get; set; }
        public string 录取类别 { get; set; }
        public string 中学 { get; set; }

        public string 大学_成绩单 { get; set; }
        public string 大学_毕业生登记表 { get; set; }//大学_高等学校毕业生登记表
        public string 大学_学生鉴定表 { get; set; }
        public string 大学_评奖评优 { get; set; }
        public string 大学_实习鉴定 { get; set; }
        public string 大学_其他 { get; set; }

        public string 硕士_录取登记表 { get; set; }
        public string 硕士_政审表 { get; set; }
        public string 硕士_派遣证 { get; set; }
        public string 硕士_评奖评优 { get; set; }
        public string 硕士_毕业生登记表 { get; set; }
        public string 硕士_学位申请材料 { get; set; }

        public string 博士录取材料 { get; set; }
        public string 博士_毕业生登记表 { get; set; }
        public string 博士_学位申请材料 { get; set; }

        public string 入团材料 { get; set; }
        public string 入党材料 { get; set; }
        public string 工作 { get; set; }
        public string 违纪材料 { get; set; }
        public string 备注 { get; set; }
    }

    public class DangAn
    {
        public string XH { get; set; }//学号
        public string XM { get; set; }//姓名
        public string LuQuLB { get; set; }//录取类别
        public string ZhongXue { get; set; }//中学

        public string DX_ChengJiD { get; set; }//成绩单(大学)
        public string DX_BiYeSDJB { get; set; }//高等学校毕业生登记表(大学)
        public string DX_JianDingB { get; set; }//学生鉴定表(大学)
        public string DX_PingJiangPY { get; set; }//评奖评优(大学)
        public string DX_ShiXiJD { get; set; }//实习鉴定(大学)
        public string DX_QiTa { get; set; }//其他(大学)

        public string SS_LuQuDJB { get; set; }//录取登记表(硕士)
        public string SS_ZhengShenB { get; set; }//政审表(硕士)
        public string SS_PaiQianZ { get; set; }//派遣证(硕士)
        public string SS_PingJiangPY { get; set; }//评奖评优(硕士)
        public string SS_BiYeSDJB { get; set; }//毕业生登记表(硕士)
        public string SS_XueWeiSQCL { get; set; }//学位申请材料(硕士)

        public string BS_BoShiLQCL { get; set; }//博士录取材料(博士)
        public string BS_BiYeSDJB { get; set; }//毕业生登记表(博士)
        public string BS_XueWeiSQCL { get; set; }//学位申请材料(博士)

        public string RuTuanCL { get; set; }//入团材料
        public string RuDangCL { get; set; }//入党材料
        public string GongZuo { get; set; }//工作
        public string WeiJiCL { get; set; }//违纪材料
        public string BeiZhu { get; set; }//备注
    }
}