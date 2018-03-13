using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 设计模式
{
    /*备忘录模式（Memento Pattern）【行为型】
     1、动机（Motivate）
       在软件构建过程中，某些对象的状态在转换的过程中，可能由于某种需要，要求程序能够回溯到对象之前处于某个点时的状态。
     * 如果使用一些公有接口来让其他对象得到对象的状态，便会暴露对象的细节实现。

　     如何实现对象状态的良好保存与恢复，但同时又不会因此而破坏对象本身的封装性？

     2、意图（Intent）
       在不破坏封装性的前提下，捕获一个对象的内部状态，并在该对象之外保存这个状态（如果没有这个关键点，其实深拷贝就可以解决问题）。
       这样以后就可以将该对象恢复到原先保存的状态。      ——《设计模式》GoF 
     
     3、模式的组成    
        （1）、发起人角色（Originator）：记录当前时刻的内部状态，负责创建和恢复备忘录数据。负责创建一个备忘录Memento，用以记录当前时刻自身的内部状态，并可使用备忘录恢复内部状态。Originator【发起人】可以根据需要决定Memento【备忘录】存储自己的哪些内部状态。

        （2）、备忘录角色（Memento）：负责存储发起人对象的内部状态，在进行恢复时提供给发起人需要的状态，并可以防止Originator以外的其他对象访问备忘录。备忘录有两个接口：Caretaker【管理角色】只能看到备忘录的窄接口，他只能将备忘录传递给其他对象。Originator【发起人】却可看到备忘录的宽接口，允许它访问返回到先前状态所需要的所有数据。

        （3）、管理者角色（Caretaker）：负责保存备忘录对象。负责备忘录Memento，不能对Memento的内容进行访问或者操作。      
     
     */
    class Memento
    {
        //备忘录模式（Memento Pattern）【行为型】
    }

    //联系人--需要备份的数据
    public sealed class ContactPerson
    {
        //姓名
        public string Name { get; set; }

        //电话号码
        public string MobileNum { get; set; }
    }

    //发起人--相当于【发起人角色】Originator
    public sealed class MobileBackOriginator
    {
        private List<ContactPerson> _list;

        public List<ContactPerson> List
        {
            get { return _list; }
            set { _list = value; }
        }

        //初始化需要备份的电话名单
        public MobileBackOriginator(List<ContactPerson> listPerson)
        {
            this._list = listPerson;
        }

        //创建备忘录对象实例，将当前要保存的联系人列表保存到备忘录对象中
        public ContactPersonMemento CreateMemento()
        {
            return new ContactPersonMemento(new List<ContactPerson>(List));
            //return new ContactPersonMemento(List);
            //这边用的是上面那个，在栈中新建一个内存地址
        }

        //备忘录还原
        public void RestoreMemento(ContactPersonMemento memento)
        {
            List = memento.list;
        }

        public void Show()
        {
            Console.WriteLine("联系人列表中共有{0}个人，他们是：", List.Count);
            foreach (var l in List)
            {
                Console.WriteLine("姓名：{0}，电话：{1}", l.Name, l.MobileNum);
            }
        }
    }

    //备忘录对象--用于保存数据 相当于【备忘录角色】Memento
    public sealed class ContactPersonMemento
    {
        public List<ContactPerson> list { get; private set; }

        public ContactPersonMemento(List<ContactPerson> listPerson)
        {
            list = listPerson;
        }
    }

    //管理角色，他可以管理【备忘录】对象，如果是多个【备忘录】对象，当然可以对保存的对象进行增、删等管理--相当于【管理者角色】Caretaker
    public sealed class MementoManager
    {
        //如果想保存多个【备忘录】对象，可以通过字典或者堆栈来保存，堆栈对象可以反映保存对象的先后顺序
        //比如：public Dictionary<string, ContactPersonMemento> ContactPersonMementoDictionary { get; set; }
     
        public ContactPersonMemento ContactPersonMemento { get; set; }
    }

}
