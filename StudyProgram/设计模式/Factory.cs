using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /* --------工厂模式 (Factory Pattern) 【创建型】----------      
     * 1、动机 在软件系统的构建过程中，经常面临着“某个对象”的创建工作：由于需求的变化，这个对象（的具体实现）经常面临着剧烈的变化，但是它却拥有比较稳定的接口。
　　    如何应对这种变化？如何提供一种“封装机制”来隔离出“这个易变对象”的变化，从而保持系统中“其他依赖对象的对象”不随着需求改变而改变？
     * 2、意图： 定义一个用于创建对象的接口，让子类决定实例化哪一个类。Factory Method使得一个类的实例化延迟到子类。   
     * 3、工厂方法模式的结构图有以下角色：
    （1）、抽象工厂角色（Creator）: 充当抽象工厂角色，定义工厂类所具有的基本的操作，任何具体工厂都必须继承该抽象类。

    （2）、具体工厂角色（ConcreteCreator）：充当具体工厂角色，该类必须继承抽象工厂角色，实现抽象工厂定义的方法，用来创建具体产品。

    （3）、抽象产品角色（Product）：充当抽象产品角色，定义了产品类型所有具有的基本操作，具体产品必须继承该抽象类。

    （4）、具体产品角色（ConcreteProduct）：充当具体产品角色，实现抽象产品类对定义的抽象方法，由具体工厂类创建，它们之间有一一对应的关系。
     */

    #region 抽象产品----抽象汽车类

    public abstract class Car
    {
        public abstract void Go();

        public string GoTo(string str)
        {
            return str;
        }
    }

    #endregion

    #region    具体产品----具体汽车

    public class HongQiCar : Car
    {
        public override void Go()
        {
            Console.WriteLine("我是一辆红旗车");
        }
    }

    public class BenChiCar : Car
    {

        public override void Go()
        {
            Console.WriteLine("我是一辆奔驰车");
        }
    }

    #endregion

    #region 抽象工厂----抽象工厂类
    public abstract class Factory
    {
        public abstract Car ProductCar();

        public string GetProductDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd:HHmmss");
        }
    }
    #endregion

    #region 具体工厂----具体汽车工厂
    public class HQ_CarFactory : Factory
    {
        public override Car ProductCar()
        {
            return new HongQiCar();
        }
    }

    public class BC_CarFactory : Factory
    {
        public override Car ProductCar()
        {
            return new BenChiCar();
        }
    }
    #endregion
}
