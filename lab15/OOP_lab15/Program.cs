using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_lab15
{
    class Program
    {
        public static void someFunc()
        {
            DateTime beginTime = DateTime.Now;
            Thread thread = Thread.CurrentThread;

            //1. Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет, время запуска, текущее состояние, сколько всего времени использовал процессор и т.д.
            thread.Name = "someFunc";
            Console.WriteLine("------------------------------");
            Console.WriteLine($"Thread id: {thread.ManagedThreadId}");
            Console.WriteLine($"Thread name: {thread.Name}");
            Console.WriteLine($"Thread priority: {thread.Priority}");
            Console.WriteLine($"Thread start date: {beginTime.Hour}:{beginTime.Minute}:{beginTime.Second}:{beginTime.Millisecond}");
            Console.WriteLine($"Thread state: {thread.ThreadState}");
            for (char i = 'A'; i <= 'Z'; i++)
                Console.Write($"{i} ");
            Console.WriteLine($"\nTime of CPU using: {DateTime.Now.Hour- beginTime.Hour}:{DateTime.Now.Minute - beginTime.Minute}:{DateTime.Now.Second - beginTime.Second}:{DateTime.Now.Millisecond - beginTime.Millisecond}");
            Console.WriteLine("------------------------------");
            var domain = Thread.GetDomain();
            Console.WriteLine($"Domain name: {domain.FriendlyName}");
            Console.WriteLine($"Config datails: {domain.SetupInformation}");
            Console.WriteLine("Assemblies: ");
            foreach (var assembly in domain.GetAssemblies())
            {
                Console.WriteLine("Full name: " + assembly.FullName);
                Console.WriteLine("Locaiton: " + assembly.Location + '\n');
            }

            //2. Определите и выведите на консоль/в файл все запущенные процессы:id, имя, приоритет, время запуска, текущее состояние, сколько всего времени использовал процессор и т.д
            var d = AppDomain.CreateDomain("domain");
            d.Load(domain.GetAssemblies()[0].FullName);
            AppDomain.Unload(d);
            //3. Создайте в отдельном потоке следующую задачу расчета (можно сделать sleep для задержки) и записи в файл и на консоль простых чисел от 1 до n (задает пользователь).
            //Вызовите методы управления потоком (запуск, приостановка, возобновление и т.д.) Во время выполнения выведите информацию о статусе потока, имени, приоритете, числовой идентификатор и т.д.
            int n;
            Console.Write("Input n: ");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Thread.Sleep(100);
                Console.Write(" " + i);

                if (i == 5)
                {
                    thread.Suspend();
                }
            }
            Console.WriteLine();
        }

        //4. Создайте два потока. Первый выводит четные числа, второй нечетные до n и записывают их в общий файл и на консоль. Скорость расчета чисел у потоков – разная.
        static object locker = new object();
        static object mon = new object();
        public static void outputNumbers(object inputN)
        {
            lock (locker)
            {
                int n = (int)inputN;
                if(Thread.CurrentThread.Name == "1")
                    for (int i = 1; i <= n; i++)
                        if (i % 2 != 0)
                            Console.WriteLine($" {i} ");

                if (Thread.CurrentThread.Name == "2")
                    for (int i = 1; i <= n; i++)
                        if (i % 2 == 0)
                            Console.WriteLine($" {i} ");
            }
        }

        
        public static void even()
        {
            for (int i = 2; i < 100; i += 2)
            {
                mutex.WaitOne();
                {
                    Console.WriteLine(i);
                }
                mutex.ReleaseMutex();
                Thread.Sleep(50);
            }
        }
        public static void noteven()
        {
            for (int i = 1; i < 100; i += 2)
            {
                mutex.WaitOne();
                {
                    Console.WriteLine(i);
                }
                mutex.ReleaseMutex();
                Thread.Sleep(50);
            }
        }

        static Mutex mutex = new Mutex();
        public static void outputNumbersSinh(object inputN)
        {
            int n = (int)inputN;
            if (Thread.CurrentThread.Name == "1")
            {
                for (int i = 1; i <= n; i++)
                    if (i % 2 != 0)
                    {
                        mutex.WaitOne();
                        Console.WriteLine($" {i} ");
                        mutex.ReleaseMutex();
                    }
            }

            if (Thread.CurrentThread.Name == "2")
            {
                for (int i = 1; i <= n; i++)
                    if (i % 2 == 0)
                    {
                        mutex.WaitOne();
                        Console.WriteLine($" {i} ");
                        mutex.ReleaseMutex();
                    }
            }
        }

        public static void timerFunc(object a)
        {
            Console.WriteLine("\n-------------\n I'm a timer! \n-------------\n");
        }

        static void Main(string[] args)
        {
            TimerCallback tm = new TimerCallback(timerFunc);
            Timer timer = new Timer(tm, null, 0, 2000);

            Thread thread = new Thread(new ThreadStart(someFunc));
            thread.Start();

            while(true)
            if (thread.ThreadState == ThreadState.Suspended)
            {
                Thread.Sleep(500);
                thread.Resume();
                break;
            }


            Thread thread1 = new Thread(new ParameterizedThreadStart(outputNumbers)) { Name = "1", Priority = ThreadPriority.Highest };     //сначала чётные
            Thread thread2 = new Thread(new ParameterizedThreadStart(outputNumbers)) { Name = "2", Priority = ThreadPriority.AboveNormal }; //потом нечётные
            Console.WriteLine("\n----------------------------");
            thread1.Start(15);
            thread2.Start(15);


        }
    }
}
