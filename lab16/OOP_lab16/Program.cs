using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_lab16
{
    class Program
    {
        public static void EratosthenesSieve_1(int n)       // решето Эратосфена
        {
            System.Threading.Thread.Sleep(100);
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                if (flags[i])
                {
                    j = i * 2;
                    while(j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                    i++;
            }

            Console.WriteLine($"Все простые числа до {n}:  ");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write($" {i} ");
                }
            }
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine($"Алгоритм занял {sw.ElapsedMilliseconds} мсек");
        }

        public static CancellationTokenSource tokenSource = new CancellationTokenSource();
        public static void EratosthenesSieve_2(int n)
        {
            System.Threading.Thread.Sleep(100);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            

            bool[] flags = new bool[n];

            for (int i = 0; i < flags.Length; i++)
                flags[i] = true;

            flags[1] = false;
            for (int i = 2, j = 0; i < n;)
            {
                Console.WriteLine($"Выполняется задача №{Task.CurrentId}.");
                System.Threading.Thread.Sleep(1000);
                if (flags[i])
                {
                    j = i * 2;
                    while (j < n)
                    {
                        flags[j] = false;
                        j += i;
                    }
                }
                i++;

                if (tokenSource.IsCancellationRequested)
                {
                    Console.WriteLine("\nПреждевревенная остановка!");
                    return;
                }
            }

            Console.WriteLine($"Все простые числа до {n}:  ");
            for (int i = 2; i < flags.Length; i++)
            {
                if (flags[i])
                {
                    Console.Write($" {i} ");
                }
            }
            Console.WriteLine();
            sw.Stop();
            Console.WriteLine($"Алгоритм занял {sw.ElapsedMilliseconds} мсек");
        }

        static void Main()
        {
            #region task_1 
            //Используя TPL создайте длительную по времени задачу


            //Console.Write("Введите n:");
            //int n;
            //n = Convert.ToInt32(Console.ReadLine());

            //Task task = new Task(() => EratosthenesSieve_1(n));
            //Console.WriteLine($"Task #{task.Id} status - {task.Status}");
            //task.Start();

            //while (true)
            //{
            //    System.Threading.Thread.Sleep(10);
            //    Console.WriteLine($"Task #{task.Id} status - {task.Status}");
            //    if (task.Status == TaskStatus.RanToCompletion)
            //        break;
            //    else
            //        Console.WriteLine($"Task #{task.Id} status - {task.Status}");
            //}

            //Console.WriteLine($"Task #{task.Id} status - {task.Status}");

            #endregion

            #region task_2
            //Реализуйте второй вариант этой же задачи с токеном отмены CancellationToken и отмените задачу.


            //Console.Write("Введите n:");
            //int n2;
            //n2 = Convert.ToInt32(Console.ReadLine());

            //Task task2 = new Task(() => EratosthenesSieve_2(n2));
            //Console.WriteLine($"Task #{task2.Id} status - {task2.Status}");
            //task2.Start();

            //Console.WriteLine("\nЧтобы остановить задачу нажмите 0:");
            //string s = Console.ReadLine();
            //if (s == "0")
            //    tokenSource.Cancel();

            //Console.WriteLine($"Task #{task2.Id} status - Completed");

            #endregion

            #region task_3
            //Создайте три задачи с возвратом результата и используйте их для выполнения четвертой задачи. Например, расчет по формуле.


            //Random rand = new Random();
            //Task<int> rand1 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 1 + 2; });
            //Task<int> rand2 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 3 + 4; });
            //Task<int> rand3 = new Task<int>(() => { Thread.Sleep(1000); return rand.Next(1, 10) / 5 + 6; });
            //rand1.Start(); rand2.Start(); rand3.Start();


            //int sum(int a, int b, int c) { return a + b + c; }

            //Task<int> result = new Task<int>(() => sum(rand1.Result, rand2.Result, rand3.Result));
            //result.Start();

            //Console.WriteLine("Result task3: " + result.Result);

            #endregion

            #region task_4
            //Создайте задачу продолжения(continuation task) в двух вариантах:


            //int Sum(int a, int b) => a + b;
            //void Display(int sum) { Console.WriteLine($"Sum: {sum}"); }

            //Task<int> task1 = new Task<int>(() => Sum(4, 5));

            //Task task2 = task1.ContinueWith(sum => Display(sum.Result));    //задача с продолжением
            //task1.Start();
            //Console.Read();
            #endregion

            #region task_5
            //Используя Класс Parallel распараллельте вычисления циклов For(), ForEach().

            //int factorial(int x)
            //{
            //    int result = 1;

            //    for (int i = 1; i <= x; i++)
            //    {
            //        result *= i;
            //    }
            //    return result;
            //}


            //int[][] arr_1 = new int[10][];
            //List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //Parallel.For(0, arr_1.Length, (int i) => { arr_1[i] = new int[100000]; });
            //Parallel.ForEach(list, (a) => Console.WriteLine("factorial of " + a + " " + factorial(a)));

            #endregion

            #region task_6
            //Используя Parallel.Invoke() распараллельте выполнение блока операторов.


            //Parallel.Invoke
            //(
            //    () => { Thread.Sleep(1000); Console.WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); },
            //    () => { Thread.Sleep(1000); Console.WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); },
            //    () => { Thread.Sleep(1000); Console.WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); },
            //    () => { Thread.Sleep(1000); Console.WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); },
            //    () => { Thread.Sleep(1000); Console.WriteLine($"Выполняется задача {Task.CurrentId}"); Thread.Sleep(3000); }
            //);

            #endregion

            #region task_7
            //Используя Класс BlockingCollection реализуйте следующую задачу:
            //Есть 5 поставщиков бытовой техники, они завозят уникальные товары на склад(каждый по одному) и 10 покупателей – покупают все подряд, если товара нет - уходят.В вашей задаче: cпрос превышает предложение.Изначально склад пустой.У каждого поставщика своя
            //скорость завоза товара.Каждый раз при изменении состоянии склада выводите наименования товаров на складе.

            //BlockingCollection<string> bc = new BlockingCollection<string>(5);
            //CancellationTokenSource ts = new CancellationTokenSource();

            //sellers
            //Task[] sellers = new Task[10]
            //{
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("potato"); } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("carrot"); } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("apple");  } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("limon");  } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("banana"); } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("potato"); } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("carrot"); } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("apple");  } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("limon");  } }),
            //    new Task(() => { while(true){Thread.Sleep(700); bc.Add("banana"); } })
            //};

            //consumers
            //Task[] consumers = new Task[5]
            //{
            //    new Task(() => { while(true){ Thread.Sleep(200);   bc.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(300);   bc.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(500);   bc.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(400);   bc.Take(); } }),
            //    new Task(() => { while(true){ Thread.Sleep(350);   bc.Take(); } })
            //};

            //foreach (var i in sellers)
            //    if (i.Status != TaskStatus.Running)
            //        i.Start();

            //foreach (var i in consumers)
            //    if (i.Status != TaskStatus.Running)
            //        i.Start();
            //int count = 0;
            //while (true)
            //{
            //    if (bc.Count != count && bc.Count != 0)
            //    {
            //        count = bc.Count;
            //        Thread.Sleep(1000);
            //        Console.WriteLine("----------Склад----------");

            //        foreach (var item in bc)
            //            Console.WriteLine(item);

            //        Console.WriteLine("-------------------------");
            //    }
            //}
            #endregion

            #region task_8
            //Используя async и await организуйте асинхронное выполнение любого метода.


            void Factorial()
            {
                int result = 1;
                for (int i = 1; i <= 6; i++)
                {
                    result *= i;
                }
                Thread.Sleep(5000);
                Console.WriteLine($"Факториал равен {result}");
            }

            async void FactorialAsync()
            {
                Console.WriteLine("Начало метода FactorialAsync");
                await Task.Run(() => Factorial());
                Console.WriteLine("Конец метода FactorialAsync");
            }

            FactorialAsync();
            Console.WriteLine("main продолжает свое выполнение");
            Console.ReadKey();
            #endregion

        }
    }
}
