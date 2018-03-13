using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*策略模式（Stragety Pattern）【行为型】
     1、动机（Motivate）
       在软件构建过程中，某些对象使用的算法可能多种多样，经常改变，如果将这些算法都编码到对象中，将会使对象变得异常复杂；
       而且有时候支持不使用的算法也是一个性能负担。如何在运行时根据需要透明地更改对象的算法？将算法与对象本身解耦，从而避免上述问题？
     
     2、意图（Intent）
       定义一系列算法，把它们一个个封装起来，并且使它们可互相替换。该模式使得算法可独立于使用它的客户而变化。　　　　       ——《设计模式》GoF
     
     3、模式的组成
    （1）、环境角色（Context）：持有一个Strategy类的引用。

         需要使用ConcreteStrategy提供的算法。

         内部维护一个Strategy的实例。

         负责动态设置运行时Strategy具体的实现算法。

         负责跟Strategy之间的交互和数据传递

    （2）、抽象策略角色（Strategy）：定义了一个公共接口，各种不同的算法以不同的方式实现这个接口，Context使用这个接口调用不同的算法，一般使用接口或抽象类实现。

    （3）、具体策略角色（ConcreteStrategy）：实现了Strategy定义的接口，提供具体的算法实现。     
        
     */
    class Stragety
    {
        //策略模式（Stragety Pattern）【行为型】
        //以公司中不同职业的人薪资作为例子
        //将工资的算法抽象出来，每个职业的算法独立出来
        //符合模式的开闭原则
    }

    public sealed class SalaryContext
    {
        private ISalaryStrategy _salary;

        public ISalaryStrategy Salary
        {
            get { return _salary; }
            set { _salary = value; }
        }

        public SalaryContext(ISalaryStrategy salary)
        {
            this._salary = salary;
        }
        public void GetSalary(double income)
        {
            this._salary.CaculateSalary(income);
        }
    }

    public interface ISalaryStrategy
    {
        void CaculateSalary(double income);
    }

    public sealed class NormalPeopleSalary : ISalaryStrategy
    {
        public void CaculateSalary(double income)
        {
            Console.WriteLine("我的工资是:基本工资(" + income + ")+底薪(3000)+加班费");
        }
    }

    public sealed class ProgrammerSalary : ISalaryStrategy
    {
        public void CaculateSalary(double income)
        {
            Console.WriteLine("我的工资是:基本工资(" + income + ")+底薪(8000)+加班费+项目奖金（10%）");
        }
    }

    public sealed class CEOSalary : ISalaryStrategy
    {
        public void CaculateSalary(double income)
        {
            Console.WriteLine("我的工资是:基本工资(" + income + ")+底薪（20000）+加班费+项目奖金（20%）");
        }
    }
}
