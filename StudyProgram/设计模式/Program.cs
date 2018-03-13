using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Web.UI.WebControls;

namespace 设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.BackgroundColor = ConsoleColor.Blue; 设置控制台颜色
            //Console.ForegroundColor=ConsoleColor.White;

            #region 单例模式(Singleton Pattern)【创建型】
            //单线程中的单例模式
            var instance = Singleton.GetInstance();
            Console.WriteLine(instance.GetInfo());

            //多线程中的单例模式
            var instance1 = Singleton1.GetInstance();
            Console.WriteLine(instance1.GetInfo("无敌"));

            var s2 = Singleton1.GetInstance();
            Console.WriteLine();
            Console.WriteLine();
            #region 线程中调用
            ///ParameterizedThreadStart委托是允许传参数的，ThreadStart表示无参
            ///   //t2线程的实例   Thread t2 = new Thread(new ThreadStart(() => { }));
            Thread t1 = new Thread(new ParameterizedThreadStart((object obj) =>
            {
                var s1 = Singleton1.GetInstance();
                //Thread.Sleep(5000);
                Console.WriteLine(s1.GetInfo("我是t1线程的"));
            }));

            Thread t2 = new Thread(() =>
            {
                var ss2 = Singleton1.GetInstance();
                Console.WriteLine(ss2.GetInfo("我是t2线程的"));
                // Console.WriteLine("我是t2线程的" + ss2.GetInfo());
            });
            Thread t3 = new Thread(() =>
            {
                var ss3 = Singleton1.GetInstance();
                // Console.WriteLine("我是t2线程的" + ss2.GetInfo());
            });
            t1.Start(null);
            t2.Start();
            t3.Start();
            #endregion

            #endregion

            #region 设计模式原则_依赖倒置原则测试
            Animal animal = new Animal();
            var d_say = animal.GetSayThing(new Dog());
            var f_say = animal.GetSayThing(new Fish());
            Console.WriteLine(d_say);
            Console.WriteLine(f_say);
            Console.WriteLine(); Console.WriteLine();
            #endregion

            #region 工厂模式(Factory Method Pattern)【创建型】
            HQ_CarFactory hq_fact = new HQ_CarFactory();
            Car hq_car = hq_fact.ProductCar();
            Car hq_car1 = hq_fact.ProductCar();
            hq_car.Go();
            hq_car1.Go();
            Console.WriteLine("生产日期：" + hq_fact.GetProductDate());
            Console.WriteLine("将要去往" + hq_car.GoTo("北京"));

            BC_CarFactory bc_fact = new BC_CarFactory();
            Car bc_car = bc_fact.ProductCar();
            bc_car.Go();
            Console.WriteLine("生产日期：" + hq_fact.GetProductDate());
            Console.WriteLine("将要去往" + hq_car.GoTo("上海"));
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 建造模式(Build Pattern)【创建型】
            CarDirector director = new CarDirector();//指导者
            BmwBuild bmw_builder = new BmwBuild();//具体建造者--继承抽象建造者
            director.Construct(bmw_builder);// 构造一个使用Builder接口的对象即在指导者的调用下创建产品实例
            BCar baoma = bmw_builder.GetCar();//具体产品
            baoma.show();

            var BcBuilder = new BenChiBuild();
            director.Construct(BcBuilder);
            var benchi = BcBuilder.GetCar();
            benchi.show();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 原型模式中的深浅clone
            CopyClass c1 = new CopyClass();
            c1.i = 5; c1.str = "我是原对象";
            CopyClass c2 = c1.Clone1();
            CopyClass c3 = c1.Clone2();
            Console.WriteLine("原对象中的i={0},浅副本的i={1},深副本的i={2} ", c1.i, c2.i, c3.i);
            Console.WriteLine("原对象中的str={0},浅副本的str={1},深副本的str={2} ", c1.str, c2.str, c3.str);
            Console.WriteLine("修改原对象中i后");
            c1.i = 10;
            c1.str = "我是修改后的原对象";
            c1.arr[0] = 10;
            Console.WriteLine("原对象中的i={0},浅副本的i={1},深副本的i={2} ", c1.i, c2.i, c3.i);
            Console.WriteLine("原对象中的str={0},浅副本的str={1},深副本的str={2} ", c1.str, c2.str, c3.str);
            Console.WriteLine("原对象中的数组第一位={0},浅副本的数组第一位={1},深副本的数组第一位={2} ", c1.arr[0], c2.arr[0], c3.arr[0]);
            //上述三次修改的记录中只有 数组的修改，导致浅副本中的数组跟着修改
            //有人说值类型的属性不会修改，引用类型的属性会修改,但是string好像是个特例不能修改
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 适配器模式(Adapter Pattern)【结构型】
            ITwoHoleTarget twohole = new ThreeToTwoAdapter();
            twohole.Reqest();
            ITwoHoleTarget_1 twohole_1 = new ThreeToToAdapter_1();
            twohole_1.Request();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 桥接模式（Bridge Pattern）【结构型】
            PlatformImplementor SqlServer2000UinxImp = new SQLServer2000UnixImplementor();
            DataBase SqlServer2000Unix = new SQLServer2000(SqlServer2000UinxImp);
            SqlServer2000Unix.Create();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 装饰模式（Decorator Pattern）【结构型】
            House huageHouse = new HugeFengeGHouse();
            AirConditionerDecorator airCond = new AirConditionerDecorator(huageHouse);
            airCond.Renovation();

            #region C#中的具体实现
            Stream a = new MemoryStream();
            BufferedStream bs = new BufferedStream(a);
            #endregion

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 外观模式（Facade Pattern）【结构型】
            F_Facade facade = new F_Facade();
            facade.Method_C();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 代理模式（Proxy Pattern）【结构型】
            AgentPerson agentperson = new AgentPerson();
            agentperson.Speak("李小璐出轨。。。。");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 模板方法模式（Template Method Pattern）【行为型】
            ConcreteClass jiaozi = new ConcreteClass();
            jiaozi.EatingJiaoZi();//子类中new覆盖的吃饺子的方法
            Console.WriteLine();
            //这个才是模板方法模式的实现，上面的是覆盖的介绍
            AbstractClass jz = new ConcreteClass();
            jz.EatingJiaoZi();//父类中的吃饺子的方法
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 命令模式（Command Pattern）【行为型】
            HuaAndWife worker = new HuaAndWife();
            GMCommand command = new MakeDumplingCommand(worker);
            PaPaInoker papa = new PaPaInoker(command);
            papa.ExecuteCommand();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 迭代器模式（Iterator Pattern）【行为型】
            ConcreteTroopQueue troopqueue = new ConcreteTroopQueue();
            I_Iterator iterator = troopqueue.GetIterator();
            //I_Iterator iterator = new ConcreteIterator(troopqueue);//上面那个方式初始化，比这个好（）
            try
            {
                while (iterator.MoveText())
                {
                    Console.WriteLine(iterator.GetCurrent());
                    //iterator.Next();
                }
            }
            finally
            {
                iterator.Reset();
                Console.WriteLine("游标重置了。。。");
            }
            Console.WriteLine("流程结束");
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 观察者模式（Observer Pattern）【行为型】
            //观察者模式（Observer Pattern）【行为型】
            BankMessageSystem nanjingBankSystem = new NanJingBankMessageSystem();
            Depositor zhangs = new NanJingDepositor("zhangs", 4000);
            Depositor lisi = new NanJingDepositor("lisi", 3000);
            Depositor wangw = new NanJingDepositor("wangw", 2000);
            nanjingBankSystem.Add(zhangs);
            nanjingBankSystem.Add(lisi);
            nanjingBankSystem.Add(wangw);

            zhangs.GetMoney(500);
            nanjingBankSystem.Notify();

            #region 三个List比较,看看变化单个list会不会变化
            int i1 = 5;
            int i2 = 6;
            int i3 = 7;
            List<int> ll = new List<int>();
            ll.Add(i1);
            ll.Add(i2);
            ll.Add(i3);

            i1 = 5 - 3;
            foreach (var l in ll)
            {
                //if (l < 5)
                Console.WriteLine(l);//这边没变
            }

            Huage h_zhangs = new Huage("zhangs", 18, false);
            Huage h_lisi = new Huage("lisi", 19, false);
            Huage h_wangw = new Huage("wangw", 20, false);

            List<Huage> h_list = new List<Huage>();
            h_list.Add(h_zhangs);
            h_list.Add(h_lisi);
            h_list.Add(h_wangw);

            h_zhangs.Age = 20; h_zhangs.Sex = true;
            h_lisi.Name = "SB_lisi"; h_lisi.Sex = true;

            foreach (var h in h_list)
            {
                if (h.Sex)
                    Console.WriteLine(h.Name + ":您的信息变了");
            }

            // （这边应该适用于引用类型，不适用于值类型,但是引用类型的string也要除外） 这边list.add()方法只是添加的该对象的内存地址，如果该对象变了，但是内存地址没变，所以list也会因对象的改变而改变。。
            //  可以查看 ‘原型模式中的深浅clone’ 的学习
            string s_str1 = "huage1";
            string s_str2 = "huage2";
            string s_str3 = "huage3";

            List<string> s_list = new List<string>();
            s_list.Add(s_str1);
            s_list.Add(s_str2);
            s_list.Add(s_str3);

            s_str1 = "zhangs";

            foreach (var s in s_list)
                Console.WriteLine(s);//没有变。。。

            #endregion
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 中介者模式（Mediator Pattern）【行为型】
            President pre = new President();
            Development development = new Development(pre);
            Financial financial = new Financial(pre);

            pre.SetDevelopment(development);
            //pre.SetFinancial(financial);

            pre.Command();

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 状态模式（State Pattern）【行为型】
            Order order = new Order();

            order.Minute = 20;
            order.Action();

            Console.WriteLine("**********************************");

            order.Minute = 21;
            order.IsCancel = true;
            order.SetState(new WaitForAcceptance());
            order.Action();
            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 策略模式（Stragety Pattern）【行为型】

            SalaryContext context = new SalaryContext(new NormalPeopleSalary());
            context.GetSalary(1000.00);

            context.Salary = new ProgrammerSalary();
            context.GetSalary(5000.00);

            context.Salary = new CEOSalary();
            context.GetSalary(10000.00);

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 职责链模式（Chain of Responsibility Pattern）【行为型】
            PurchaseRequest requestJiaJu = new PurchaseRequest(1000, "家具");
            PurchaseRequest requestConputer = new PurchaseRequest(50000, "联想笔记本");
            PurchaseRequest requestCar = new PurchaseRequest(100000, "大众汽车");

            Approver manager = new Manger("部门经理_zhangs");
            Approver finmanager = new FinancialManager("财务经理_lisi");
            Approver ceo = new CEO("总裁_zhanghua");

            manager.ProcessRequest(requestJiaJu);

            finmanager.NextApprover = ceo;
            finmanager.ProcessRequest(requestCar);

            ceo.ProcessRequest(requestConputer);

            manager.NextApprover = finmanager;
            finmanager.NextApprover = ceo;
            manager.ProcessRequest(requestCar);

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            #region 访问者模式（Visitor Pattern）【行为型】
            ShapeVisitor visitor = new CustomVisitor();
            AppStructure app = new AppStructure(visitor);

            Shape shape = new Rectangle();
            shape.Draw();//执行自己的操作
            app.Process(shape);//执行新的操作
            //shape.Accept(visitor);

            #endregion

            #region 备忘录模式（Memento Pattern）【行为型】
                
            //这边需要理解一下，堆栈，值类型存放于堆中，引用类型存放于栈中

            List<ContactPerson> listCP = new List<ContactPerson>()
            {
                new ContactPerson(){Name="zhangs",MobileNum="123"},
                new ContactPerson(){Name="lisi",MobileNum="456"},
                new ContactPerson(){Name="wangw",MobileNum="789"}
            };

            //手机名单发起人
            MobileBackOriginator mbOriginator = new MobileBackOriginator(listCP);
            mbOriginator.Show();

            //创建被弯路并保存备忘录对象
            MementoManager memntoManager = new MementoManager();
            memntoManager.ContactPersonMemento = mbOriginator.CreateMemento();

            //更改发起人联系人列表
            Console.WriteLine("--------删除最后一位联系人--------");
            mbOriginator.List.RemoveAt(mbOriginator.List.Count - 1);
            mbOriginator.Show();

            //恢复到原始状态
            Console.WriteLine("--------恢复到原始状态--------");
            mbOriginator.RestoreMemento(memntoManager.ContactPersonMemento);
            mbOriginator.Show();

            Console.WriteLine();
            Console.WriteLine();
            #endregion

            Console.ReadKey();
        }
    }

    #region  设计模式六大原则

    //设计模式六大原则（1）：单一职责原则

    //设计模式六大原则（2）：里氏替换原则

    //设计模式六大原则（3）：依赖倒置原则

    //设计模式六大原则（4）：接口隔离原则

    //设计模式六大原则（5）：迪米特法则

    //设计模式六大原则（6）：开闭原则

    /*
   * 单一职责原则告诉我们实现类要职责单一；
   * 里氏替换原则告诉我们不要破坏继承体系；
   * 依赖倒置原则告诉我们要面向接口编程；
   * 接口隔离原则告诉我们在设计接口的时候要精简单一；
   * 迪米特法则告诉我们要降低耦合。
   * 而开闭原则是总纲，他告诉我们要对扩展开放，对修改关闭
   */
    #endregion

    #region 设计模式六大原则（3）：依赖倒置原则
    //核心：依赖倒置原则的核心就是要我们面向接口编程，理解了面向接口编程，也就理解了依赖倒置。
    public interface ISay
    {
        string GetSayThing();//接口里面的方法隐式public的，不允许有任何的访问修饰符，包括public
    }
    public class Dog : ISay
    {
        public string GetSayThing()
        {
            return "狗:我是陆地上的动物";
        }
    }
    public class Fish : ISay
    {

        public string GetSayThing()
        {
            return "鱼:我是水里的动物";
        }
    }
    public class Animal
    {
        public string GetSayThing(ISay say)
        {
            return say.GetSayThing();
        }
    }
    #endregion

    public class Huage
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        private bool _sex;

        public bool Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }

        public Huage(string name, int age, bool sex)
        {
            this._name = name;
            this._age = age;
            this._sex = sex;
        }
    }
}
