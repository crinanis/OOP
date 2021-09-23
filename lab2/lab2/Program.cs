using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            //ttypes();
            //strings();
            kortegi();
            task6_checked();
            task6_unchecked();

            (int max, int min, int sum, char firstLetter) tuple;
            int[] array = { 1, 2, 3, 4, 5, 813, 0, 738};
            string name = "Kotik";
            tuple = task5(array, name);
            Console.WriteLine($"Max num: {tuple.max}\n" +
                              $"Min num: {tuple.min}\n" +
                              $"Sum: {tuple.sum}\n" +
                              $"First letter: {tuple.firstLetter}");
        }
        static void ttypes()
        {
            //TYPES-------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Определите переменные всех возможных примитивных типов С# и проинициализируйте их. Осуществите ввод и вывод их значений используя консоль.
            bool a = true;

            byte b = 254;            //0 : 255
            sbyte c = 126;           //-128 : 127
            int h = 123123123;       //-2147483648 : 2147483647
            uint i = 11111111;       //0 : 4294967295
            long j = 91918191919;    //-9223372036854775808 : 9223372036854775807
            ulong k = 83172377124;   //0 : 18446744073709551615
            short l = 12312;         //-32768 : 32767
            ushort m = 12121;        //0 : 65535

            char d = 'M';            //Unicode

            decimal e = 123123;      //позволяет представить числа с точностью до 28 (а иногда и 29) десятичных разрядов. 1Е-28 : 7,9Е+28

            double f = 12.3213123;
            float g = (float)3.4;

            Console.WriteLine("Enter a string type... :");
            string n = Console.ReadLine();
            Console.WriteLine("[string] You'r string is : " + n);

            //Выполните 5 операций явного и 5 неявного приведения. Изучите возможности класса Convert.

            // явное привидение типов
            byte number = 128;
            Console.WriteLine("[byte] " + number + " -- to int --> " + (int)number);
            Console.WriteLine("[int] " + (int)number + " -- to long --> " + (long)number);
            Console.WriteLine("[byte] " + number + " -- to double --> " + (double)number);
            Console.WriteLine("[double] " + (double)number + " -- to float --> " + (float)number);
            Console.WriteLine("[byte] " + number + " -- to ulong --> " + (ulong)number);

            // неявное привидение типов
            int aa = 223;
            double bb = aa; // приводит int -> double
            float cc = aa; // приводит int -> float

            double dd = 23.32;
            double ee = dd + aa;

            // привидение с помощью класса Convert
            // вернёт True
            bool ff = System.Convert.ToBoolean(aa);
            Console.WriteLine("Convert.ToBoolean() : " + f);

            // вернёт строку "23.32"
            string gg = System.Convert.ToString(dd);
            Console.WriteLine("Convert.ToString() : " + g);



            //Выполните упаковку и распаковку значимых типов.

            /*Упаковка представляет собой процесс преобразования 
             * типа значения в тип object или в любой другой тип 
             * интерфейса, реализуемый этим типом значения. 
             * Когда тип значения упаковывается общеязыковой средой 
             * выполнения (CLR), он инкапсулирует значение внутри 
             * экземпляра System.Object и сохраняет его в управляемой 
             * куче. Операция распаковки извлекает тип значения из объекта. 
             * Упаковка является неявной; распаковка является явной
             * . Понятия упаковки и распаковки лежат в основе единой 
             * системы типов C#, в которой значение любого типа можно 
             * рассматривать как объект.
             */

            // упаковка
            int ik = 777;
            object ok = ik;

            // распаковка
            ok = 123;
            ik = (int)ok;

            // можно выполнять упаковку явно
            ok = (object)ik;

            //Продемонстрируйте работу с неявно типизированной переменной.

            var numm = 64;      // компилируется как int

            var name = "Ksesha"; // компилируется как string

            var night = true;    // компилируется как bool

            // операции с неявно типизированной переменной
            if (night) Console.WriteLine(name + " walks at night!");

            var array = new[] { 1, 2, 3 };
            foreach (var element in array) numm += element;

            //Продемонстрируйте пример работы с Nullable переменной

            int? x1 = null;
            if (x1.HasValue) Console.WriteLine(x1.Value);
            else
                Console.WriteLine("x1 равен null");

            int? x2 = 4;
            if (x2.HasValue) Console.WriteLine(x2.Value);
            else
                Console.WriteLine("x2 равен null");

            //Определите переменную типа var и присвойте ей любое значение. Затем следующей инструкцией присвойте ей значение другого типа. Объясните причину ошибки.

            //var an = 123;
            //an = 23.32;

            //Этот код выдаст ошибку, т.к. при инициализации аn в первой строке, она получает тип int и уже остаётся int. Неявное привидение к другому типу не будет выполнено
        }

        static void strings()
        {
            //STRINGS--------------------------------------------------------------------------------------------------------------------------------------------------------------

            //Объявите строковые литералы. Сравните их.

            string str1 = "Hello";
            string str2 = "Ksesha";
            string str3 = "Hello";

            Console.WriteLine(str1 == str2); // false
            Console.WriteLine(str1 == str3); // true

            // Создайте три строки на основе String.Выполните: сцепление, копирование, выделение подстроки, разделение строки на слова,
            // вставки подстроки в заданную позицию, удаление заданной подстроки.

            string str4 = "Hello world";
            string str5 = "My name is Ksesha";
            string str6 = "This is C# language";

            str4 += str5;                               // сцепление

            string str7 = str4;                         // копирование

            string word = str4.Substring(0, 5);         // выделение подстроки и её копирование

            string[] words = str5.Split();              // разделение строки на слова
            Console.WriteLine(words[1]);                // output: name

            // вставка в определенную позицию
            string message = "Hello, ";
            // Insert(pos, str);
            Console.WriteLine(message.Insert(message.Length, str2));

            // удаление
            string question = "Hey man what's up";
            question.Remove(0, 3); // output: man what's up
                                   // или короче question.Replace("Robert ", "");

            // интерполирование строк
            Console.WriteLine($"Hello, {str2}! {str6}"); // output: Hello, Ksesha! This is C# language.

            //Создайте пустую и null строку. Продемонстрируйте использование метода string.IsNullOrEmpty. Продемонстрируйте что еще можно выполнить с такими строками

            string firstname = null;
            string lastname = String.Empty; // or string lastname = ""

            // простейший пример использования isNullOrEmpty
            // null вернет true, empty - false
            if (String.IsNullOrEmpty(firstname)) Console.WriteLine("This string is null");
            else Console.WriteLine("This string is empty");
            if (String.IsNullOrEmpty(lastname)) Console.WriteLine("This string is null");
            else Console.WriteLine("This string is empty");

            //Создайте строку на основе StringBuilder. Удалите определенные позиции и добавьте новые символы в начало и конец строки.

            var sb = new System.Text.StringBuilder();

            for (int ti = 0; ti < 10; ti++) sb.Append(ti);

            Console.WriteLine(sb.ToString()); // 0123456789

            sb[5] = sb[2];

            Console.WriteLine(sb.ToString()); // 0123426789

            //Создайте целый двумерный массив и выведите его на консоль в отформатированном виде (матрица).

            int[,] array1 = { { 1, 0, 1 }, { 0, 1, 0 }, { 1, 0, 1 } };
            for (int ij = 0; ij < 3; ij++)
            {
                for (int o = 0; o < 3; o++)
                {
                    Console.Write($"{array1[ij, o]}\t");
                }
                Console.Write("\n");
            }

            //Создайте одномерный массив строк. Выведите на консоль его содержимое, длину массива. Поменяйте произвольный элемент (пользователь определяет позицию и значение).

            string[] str_array = { "Hello", "My name is", "Ksusha" };
            Console.WriteLine("Содержание массива:");
            for (int i = 0; i < str_array.Length; i++)
                Console.WriteLine($"[{i}]. {str_array[i]}");

            Console.WriteLine("Выберите номер строки, которую хотите заменить: ");
            int aka = System.Convert.ToInt32(Console.ReadLine());

            if (aka < str_array.Length)
            {
                Console.WriteLine("Напишите предложение: ");
                string answer = Console.ReadLine();
                str_array[aka] = answer;
                for (int i = 0; i < str_array.Length; i++)
                    Console.WriteLine($"[{i}]. {str_array[i]}");
            }
            else Console.WriteLine("Вы ввели неправильное число");

            //Создайте ступечатый (не выровненный) массив вещественных чисел с 3 - мя строками, в каждой из которых 2, 3 и 4 столбцов соответственно.Значения массива введите с консоли.

            byte arraySize = 4;
            int[][] arr = new int[arraySize][];

            for (int i = 0; i < arraySize; i++)
            {
                arr[i] = new int[i + 1];
                Console.WriteLine($"заполните массив {i} из {arraySize - 1}");
                for (int j = 0; j < arr[i].Length; j++)
                {
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }
            }

            for (int i = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write($"{arr[i][j]}\t");
                }
                Console.Write("\n");
            }

            //Создайте неявно типизированные переменные для хранения массива и строки.

            var array2 = new[] { 1, 2, 3, 4 };       // неявно типизированный массив чисел
            var str = new[] { "lol", "ffgf" };       // неявно типизированная строка
        }
        static void kortegi()
        {
            //КОРТЕЖИ----------------------------------------------------------------------------------------------------------------------------------------------------------------

            // Задаём кортеж из 5 элементов с типами...
            (int, string, char, string, ulong) tuple = (18, "STR", 'm', "ASDASDASD", 888888);
            // Выводим кортеж целиком и выборочно
            Console.WriteLine(tuple + " ");
            Console.Write($"{tuple.Item1} {tuple.Item3} {tuple.Item4}");
            // Выполняем распаковку кортежа в переменные
            string nam;
            int age;

            (string nam, ushort age) woman = ("Ksenya Budanowa", 18);

            nam = woman.nam;
            age = woman.age; // конвертируем в int без потери

            (nam, _, _) = tuplesReturn(); // deconstruction of tuple

            Console.WriteLine(" ");
            Console.WriteLine(woman == ("Ksenya Budanowa", 18)); // true
            Console.WriteLine(woman == ("Ksenya Budanowa", 20)); // false        
        }
        static (string, ushort, char) tuplesReturn() // return info (string name, ushort age, char sex)
        {
            return ("Vovik", 9, 'm');
        }

        static (int max, int min, int sum, char firstLetter) task5(int[] a, string str)
        {

            if ((a is null || a.Length == 0) || (str is null || str.Length == 0))
            {
                throw new ArgumentException("Массив или строка пуста");
            }

            int min = int.MaxValue;
            int max = int.MinValue;
            int sum = 0;

            foreach (int i in a)
            {
                sum += i;

                if (i < min)
                {
                    min = i;
                }

                if (i > max)
                {
                    max = i;
                }
            }

            char letter = str[0];

            return (max, min, sum, letter);
        }

        static void task6_checked()
        {
            checked
            {
                int i = int.MaxValue;
            }
        }

        static void task6_unchecked()
        {
            unchecked
            {
                int i = int.MaxValue + 1;
            }
        }
    }
}


//static void pers()
//{
//      Person person = new Person();
//      person.age = 28;
//      fixed(int* p = $person.age)
//          {
//                if (*p < 30)
//                    {
//                        *p = 30;
//                    }
//          }
//      Console.WriteLine(person.age);
//}