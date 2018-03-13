using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*
     单例模式 (Singleton Model)【创建型】
     * 
     *1、动机：在软件系统中，经常有这样一些特殊的类，必须保证它们在系统中只存在一个实例，才能确保它们的逻辑正确性、以及良好的效率。
　　   如何绕过常规的构造器，提供一种机制来保证一个类只有一个实例? 这应该是类设计者的责任，而不是使用者的责任
     * 
     * 2、意图： 保证一个类仅有一个实例，并提供一个该实例的全局访问点。　
     * 
     * 总结：   它的一点弊端就是它不支持参数化的实例化方法。在.NET里静态构造器只能声明一个，而且必须是无参数的，私有的。因此这种方式只适用于无参数的构造器。
       需要说明的是：HttpContext.Current就是一个单例，他们是通过Singleton的扩展方式实现的，他们的单例也并不是覆盖所有领域，只是针对某些局部领域中，是单例的，
     * 不同的领域中还是会有不同的实例。
     * 
     */

    /// <summary>
    /// 单线程下的单例模式
    /// </summary>
    public sealed class Singleton //sealed 修饰符可阻止其他类继承自该类
    {
        private static Singleton _instance; // 定义一个静态变量来保存类的实例

        private Singleton() { } // 定义私有构造函数，使外界不能创建该类实例

        public string GetInfo()
        {
            return "单线程下的单例模式";
        }

        public static Singleton GetInstance() //提供一个全局访问点,同时你也可以定义公有属性来提供全局访问点
        {
            if (_instance == null)
                _instance = new Singleton();

            return _instance;
        }

    }


    public sealed class Singleton1
    {
        //volatile 关键字表示编译器在编译代码的时候会对代码的顺序进行微调，用volatile修饰保证了严格意义的顺序。
        //一个定义为volatile的变量是说这变量可能会被意想不到地改变，这样，编译器就不会去假设这个变量的值了。
        //精确地说就是，优化器在用到这个变量时必须每次都小心地重新读取这个变量的值，而不是使用保存在寄存器里的备份
        private static volatile Singleton1 s1_instance;

        /*
         lock(objectA){codeB} 看似简单，实际上有三个意思，这对于适当地使用它至关重要：
            1. objectA被lock了吗？没有则由我来lock，否则一直等待，直至objectA被释放。
            2. lock以后在执行codeB的期间其他线程不能调用codeB，也不能使用objectA。
            3. 执行完codeB之后释放objectA，并且codeB可以被其他线程访问。
         */
        private static readonly object locker = new object(); // // 定义一个标识确保线程同步且这个对象是在程序运行时创建的

        private Singleton1() { }
        public string result;

        public string GetInfo(string str)
        {
            result = str + "多线程下的单例模式";
            return str + "多线程下的单例模式";
        }

        public static Singleton1 GetInstance()
        {

            // 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
            // 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
            // lock语句运行完之后（即线程运行完之后）会对该对象"解锁"

            //lock (locker)
            //{
            //    if (s1_instance == null)
            //    {
            //        s1_instance = new Singleton1();
            //    }
            //}

            /*
             上面代码对于每个线程都会对线程辅助对象locker加锁之后再判断实例是否存在，
             * 对于这个操作完全没有必要的，因为当第一个线程创建了该类的实例之后，后面的线程此时只需要直接判断（uniqueInstance==null）为假，
             * 此时完全没必要对线程辅助对象加锁之后再去判断，所以上面的实现方式增加了额外的开销，损失了性能，为了改进上面实现方式的缺陷，
             * 我们只需要在lock语句前面加一句（uniqueInstance==null）的判断就可以避免锁所增加的额外开销，这种实现方式我们就叫它 “双重锁定（Double Check）
             */

            if (s1_instance == null)
            {
                lock (locker)
                {
                    ///这边的为空不能去掉,：两个线程进入了第一判断（if (uniqueInstance == null)），但是在Lock语句以前，这时，只有一个线程能进去执行，创建实例，Lock语句结束了执行，就会释放锁，
                    ///这时语句还没执行完，因为现在还在第一个判断的方法内，如果里面没有那个判断，第二个线程立刻又能获得锁，又会创建一个实例，所以两个为空的判断都不能去掉。
                    ///相当于两个为空都是为了保证该类只能有一个实例
                    if (s1_instance == null)
                        s1_instance = new Singleton1();
                }
            }

            return s1_instance;
        }
    }


}
