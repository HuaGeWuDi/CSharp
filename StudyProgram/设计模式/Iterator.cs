using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*迭代器模式（Iterator Pattern）【行为型】
     1、动机（Motivate）
       在软件构建过程中，集合对象内部结构常常变化各异。但对于这些集合对象，我们希望在不暴露其内部结构的同时，可以让外部客户代码透明地访问其中包含的元素；
     * 同时这种“透明遍历”也为“同一种算法在多种集合对象上进行操作”提供了可能。
     * 使用面向对象技术将这种遍历机制抽象为“迭代器对象”为“应对变化中的集合对象”提供了一种优雅的方式。
     
     2、意图（Intent）
        提供一种方法顺序访问一个聚合对象中的各个元素，而又不暴露该对象的内部表示。　           ——《设计模式》GoF
      
     3、模式的组成    
      从迭代器模式的结构图可以看出，它涉及到四个角色，它们分别是：
    （1）、抽象迭代器(Iterator)：抽象迭代器定义了访问和遍历元素的接口，一般声明如下方法：用于获取第一个元素的first()，用于访问下一个元素的next()，用于判断是否还有下一个元素的hasNext()，用于获取当前元素的currentItem()，在其子类中将实现这些方法。

    （2）、具体迭代器(ConcreteIterator)：具体迭代器实现了抽象迭代器接口，完成对集合对象的遍历，同时在对聚合进行遍历时跟踪其当前位置。

    （3）、抽象聚合类(Aggregate)：抽象聚合类用于存储对象，并定义创建相应迭代器对象的接口，声明一个createIterator()方法用于创建一个迭代器对象。

    （4）、具体聚合类(ConcreteAggregate)：具体聚合类实现了创建相应迭代器的接口，实现了在抽象聚合类中声明的createIterator()方法，并返回一个与该具体聚合相对应的具体迭代器ConcreteIterator实例。
     * 
     */
    class Iterator
    {
        //迭代模式，差不多就是循环。。。
    }

    public interface ITroopQueue
    {
        I_Iterator GetIterator();
    }

    public interface I_Iterator
    {
        bool MoveText();
        Object GetCurrent();
        void Next();
        void Reset();
    }

    public sealed class ConcreteTroopQueue : ITroopQueue
    {
        private string[] collection;

        public ConcreteTroopQueue()
        {
            collection = new string[] { "zhangs", "lisi", "wangw", "zhaol", "tianq" };
        }

        public I_Iterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Length
        {
            get { return collection.Length; }
        }

        public string GetElemet(int index)
        {
            return collection[index];
        }
    }

    public sealed class ConcreteIterator : I_Iterator
    {
        private ConcreteTroopQueue _list;
        private int _index;

        public ConcreteIterator(ConcreteTroopQueue list)
        {
            this._list = list;
            this._index = -1;
        }

        public bool MoveText()
        {
            this._index++;
            return this._index < this._list.Length;
        }

        public object GetCurrent()
        {
            return _list.GetElemet(this._index);
        }

        public void Next()
        {
            //this._index++;
        }

        public void Reset()
        {
            this._index = -1;
        }
    }
}
