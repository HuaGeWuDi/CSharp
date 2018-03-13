using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task学习
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建一个任务，不调用不执行，表示创建
            Task task = new Task((object obj) => { },null);
            Console.WriteLine(task.Status);

            //创建一个任务 执行  状态为 WaitingToRun
            Task task1 = new Task(() => { });
            task1.Start();//对于安排好的任务，就算调用Start方法也不会立马启动 此时任务的状态为WaitingToRun
            Console.WriteLine(task1.Status);

            //创建一个主线任务
            Task mainTask  = new Task(() =>
            {
                SpinWait.SpinUntil(() =>
                {
                    return false;
                },30000);
            });

            //将子任务加入到主任务完成之后执行
            Task subTask = mainTask.ContinueWith((t1) =>
            {

            });
            //启动主任务
            mainTask.Start();

            Console.WriteLine(subTask.Status);

            Console.Read();
        }
    }
}
