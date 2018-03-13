using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*模板方法模式（Template Method Pattern）【行为型】
     1、动机（Motivate）
       在软件构建过程中，对于某一项任务，它常常有稳定的整体操作结构，但各个子步骤却有很多改变的需求，或者由于固有的原因（比如框架与应用之间的关系）而无法和任务的整体结构同时实现。
     * 如何在确定稳定操作结构的前提下，来灵活应对各个子步骤的变化或者晚期实现需求？
      
    2、意图（Intent）
       定义一个操作中的算法的骨架，而将一些步骤延迟到子类中。Template Method使得子类可以不改变一个算法的结构即可重定义该算法的某些特定步骤。　　 ——《设计模式》GoF
   
    3、模式的组成
    
    模板方法模式参与者：

　　（1）、抽象类角色（AbstractClass）：定义一个模板方法（TemplateMethod），在该方法中包含着一个算法的骨架，具体的算法步骤是PrimitiveOperation1方法和PrimitiveOperation2方法，该抽象类的子类将重定义PrimitiveOperation1和PrimitiveOperation2操作。

　　（2）、具体类角色（ConcreteClass）：实现PrimitiveOperation1方法和PrimitiveOperation2方法以完成算法中与特定子类（Client）相关的内
     
     * 
     */
    class Template
    {
    }

    //该类型就是抽象类角色--AbstractClass，定义做饺子的算法骨架，这里有三步骤，当然也可以有多个步骤，根据实际需要而定
    public abstract class AbstractClass  //抽象方法只能在抽象类中定义，但是抽象类中可以有具体实现的方法
    {
        public AbstractClass() { }//抽象类也可以有构造函数

        public abstract void HuoMianPi();//和面皮

        public abstract void BaoJiaoZi();//包饺子

        public abstract void ZhuJiaoZi();//煮饺子

        public void EatingJiaoZi()  //抽象类中的具体实现的方法
        {
            HuoMianPi();

            BaoJiaoZi();

            ZhuJiaoZi();

            Console.WriteLine("父类：吃饺子。。。");
        }

        //public void Huage() //抽象类中的具体实现的方法
        //{
        //    Console.WriteLine("huage，无敌");
        //}
    }

    /// <summary>
    /// //该类型是具体类角色--ConcreteClass
    /// </summary>
    public sealed class ConcreteClass : AbstractClass
    {
        public ConcreteClass()
            : base()
        {

        }

        public override void HuoMianPi()
        {
            Console.WriteLine("面粉兑芹菜汁和成绿色的面皮");
        }

        public override void BaoJiaoZi()
        {
            Console.WriteLine("用猪肉加大葱做成的肉馅包饺子");
        }

        public override void ZhuJiaoZi()//实现基类中的抽象方法或者是虚函数
        {
            Console.WriteLine("用我家的大铁锅和木柴煮饺子");
        }

        public void ZhuJiaoZi(string tool, string fuel) //同一个类中有多个方法名相同的方法，但是参数不同 叫做方法的重载（返回值类型不同，不能区分方法）
        {
            Console.WriteLine(string.Format("工具：{0},燃料：{1}，开始煮饺子", tool, fuel));
        }

        public new void EatingJiaoZi() ///new覆盖基类方法，但是基类方法还是能调用的到
        {
            HuoMianPi(); BaoJiaoZi(); ZhuJiaoZi("大铁锅", "大木柴");
            Console.WriteLine("子类：好吃的饺子");
        }
    }

    #region overload,override,new 的介绍
    //overload：重载指的是同一个类中有两个或多个名字相同但是参数不同的方法，(注:返回值不能区别函数是否重载)，重载没有关键字。
    //override：过载也称重写是指子类对父类中虚函数或抽象函数的“覆盖”（这也就是有些书将过载翻译为覆盖的原因），但是这种“覆盖”和用new关键字来覆盖是有区别的。
    //new：覆盖指的是不同类中（基类或派生类）有两个或多个返回类型、方法名、参数都相同，但是方法体不同的方法。
    //但是这种覆盖是一种表面上的覆盖，所以也叫隐藏，被覆盖的父类方法是可以调用得到的。

    //重载、重写、覆盖的发生条件：
    //重载,必然发生在一个类中,函数名相同,参数类型或者顺序不同构成重载,与返回类型无关
    //重写,必然发生在基类和派生类中,其类函数用virtual修饰,派生类用override修饰
    //覆盖,在子类中写一个和基类一样名字(参数不同也算)的非虚函数,会让基类中的函数被隐藏,编译后会提示要求使用New关键字
    #endregion
}
