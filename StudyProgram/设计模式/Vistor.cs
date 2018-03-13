using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*访问者模式（Visitor Pattern）【行为型】
     1、动机（Motivate）
        在软件构建过程中，由于需求的改变，某些类层次结构中常常需要增加新的行为（方法），如果直接在基类中做这样的更改，将会给子类带来很繁重的变更负担，甚至破坏原有设计。
        如何在不更改类层次结构的前提下，在运行时根据需要透明地为类层次结构上的各个类动态添加新的操作，从而避免上述问题？

     2、意图（Intent）
        表示一个作用于某对象结构中的各个元素的操作。它可以在不改变各元素的类的前提下定义作用于这些元素的新的操作。　　　　     ——《设计模式》GoF

     3、模式的组成
        （1）、抽象访问者角色（Vistor）: 声明一个包括多个访问操作，多个操作针对多个具体节点角色（可以说有多少个具体节点角色就有多少访问操作），使得所有具体访问者必须实现的接口。

        （2）、具体访问者角色（ConcreteVistor）：实现抽象访问者角色中所有声明的接口，也可以说是实现对每个具体节点角色的新的操作。

        （3）、抽象节点角色（Element）：声明一个接受操作，接受一个访问者对象作为参数，如果有其他参数，可以在这个“接受操作”里在定义相关的参数。

        （4）、具体节点角色（ConcreteElement）：实现抽象元素所规定的接受操作。

        （5）、结构对象角色（ObjectStructure）：节点的容器，可以包含多个不同类或接口的容器。

     */
    class Vistor
    {
        //访问者模式（Visitor Pattern）【行为型】

        //该类型主要是在抽象定义的时候注入一个访问者（visitor）
        //在新增一个具体结构者 （AppStructure）来执行新的操作

    }

    //抽象图形定义--相当于“抽象节点角色”Element
    public abstract class Shape
    {
        //画图形
        public abstract void Draw();

        //外界注入具体访问者
        public abstract void Accept(ShapeVisitor visitor);
    }

    //抽象访问者 Visitor
    public abstract class ShapeVisitor
    {
        //这里有一点要说：Visit方法的参数可以写成Shape吗？
        //就是这样 Visit(Shape shape)，当然可以，但是ShapeVisitor子类Visit方法就需要判断当前的Shape是什么类型，是Rectangle类型，是Circle类型，或者是Line类型。

        public abstract void Visit(Rectangle shape);

        public abstract void Visit(Circle shape);

        public abstract void Visit(Line shape);
    }

    //具体访问者 ConcreteVisitor
    public sealed class CustomVisitor : ShapeVisitor
    {
        //针对Rectangle对象
        public override void Visit(Rectangle shape)
        {
            Console.WriteLine("针对Rectangle新的操作");
        }

        //针对Circle对象
        public override void Visit(Circle shape)
        {
            Console.WriteLine("针对Circle新的操作");
        }

        //针对Line对象
        public override void Visit(Line shape)
        {
            Console.WriteLine("针对Line新的操作");
        }
    }

    //矩形--相当于“具体节点角色” ConcreteElement
    public sealed class Rectangle : Shape
    {

        public override void Draw()
        {
            Console.WriteLine("矩形画好了");
        }

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    //圆形--相当于“具体节点角色” ConcreteElement
    public sealed class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("圆形画好了");
        }

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    //直线--相当于“具体节点角色” ConcreteElement
    public sealed class Line : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("直线画好了");
        }

        public override void Accept(ShapeVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    //结构对象角色
    internal class AppStructure
    {
        private ShapeVisitor _visitor;

        public AppStructure(ShapeVisitor visitor)
        {
            this._visitor = visitor;
        }

        public void Process(Shape shape)
        {
            shape.Accept(this._visitor);
        }
    }
}
