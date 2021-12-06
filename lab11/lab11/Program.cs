using System;
using System.Collections.Generic;
using System.Linq;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Создать массив string 12 месяцев Запросы: длина = n, летние/зимние, по алфавиту, подсчет месяцев с буквой "u", длина>=4

            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            var selectedMonthN = from m in month
                                 where m.Length == 7
                                 select m;
            Console.WriteLine("Месяцы длинной 7:");
            foreach (string str in selectedMonthN)
                Console.Write(str + ",  ");


            var selectedMonthWinSum = from m in month
                                      where Array.IndexOf(month, m) < 2 ||
                                      Array.IndexOf(month, m) > 4 && Array.IndexOf(month, m) < 8 ||
                                      Array.IndexOf(month, m) == 11
                                      select m;
            Console.WriteLine("\n\nЗимние и летние месяцы:");
            foreach (string str in selectedMonthWinSum)
                Console.Write(str + ",  ");


            var selectedMonthAlfa = from m in month
                                    orderby m
                                    select m;
            Console.WriteLine("\n\nМесяцы по алфавиту:");
            foreach (string str in selectedMonthAlfa)
                Console.Write(str + ",  ");


            var selectedMonthU4 = from m in month
                                  where m.Contains('u') && m.Length > 3
                                  select m;
            Console.WriteLine("\n\nМесяцы с буквой 'u', длина >= 4:");
            foreach (string str in selectedMonthU4)
                Console.Write(str + ",  ");



            //2. Создайте коллекцию List<T> и параметризируйте ее типом (классом) из лабораторной №3 (при необходимости реализуйте нужные интерфейсы). Заполните ее минимум 8 элементами.


            Console.WriteLine("\n" + new String('-', 50));

            List<Airline> air = new List<Airline>();
            Airline one = new Airline("Москва", 15, "Airbus A310", new DateTime(2021, 12, 01, 08, 30, 25), "Понедельник");
            air.Add(one);
            Airline two = new Airline("Гонконг", 3, "Boeing-767", new DateTime(2021, 12, 16, 18, 30, 00), "Пятница");
            air.Add(two);
            Airline three = new Airline("Шанхай", 1, "Boeing-777", new DateTime(2021, 11, 21, 9, 15, 10), "Понедельник");
            air.Add(three);
            Airline four = new Airline("Чикаго", 155, "Boeing-737", new DateTime(2021, 11, 05, 22, 00, 00), "Пятница");
            air.Add(four);
            Airline five = new Airline("Сеул", 12, "Boeing-747", new DateTime(2021, 12, 12, 11, 00, 05), "Понедельник");
            air.Add(five);
            Airline sixth = new Airline("Москва", 16, "Airbus A320", new DateTime(2021, 11, 10, 18, 55, 15), "Понедельник");
            air.Add(sixth);




            //3. На основе LINQ сформируйте следующие запросы по вариантам. При необходимости добавьте в класс T (тип параметра) свойства.

            // список рейсов для заданного пункта назначения

            var Flights = from plane in air
                          where plane.Destination == "Москва"
                          select plane;
            Console.WriteLine("Рейсы в Москву: ");
            foreach (Airline str in Flights)
                Console.Write(str + ",  ");
                Console.Write("\n\n");

            // количество рейсов для заданного дня недели

            var Days = from plane in air
                       where plane.Day_of_week=="Понедельник"
                       select plane;
            Console.WriteLine("Рейсы в Понедельник: ");
            foreach (Airline str in Days)
                Console.Write(str + ",  ");
            Console.Write("\n\n");

            // рейс который вылетает в понедельник раньше всех

            var Monday = from plane in air
                         where plane.Day_of_week == "Понедельник"
                         orderby plane.Flight_Time.Hour
                         select plane;
            Console.WriteLine("Рейс, который вылетает в понедельник раньше всех:\n");
            Airline a = Monday.First();
            Console.Write(a.Destination + " " + a.Flight + " " + a.Airplane + " " +  a.Flight_Time + " " +  a.Day_of_week);
            Console.Write("\n\n");

            // рейс который вылетает в среду или пятницу позже всех

            var Friday = from plane in air
                         where plane.Day_of_week == "Пятница" || plane.Day_of_week == "Среда"
                         orderby plane.Flight_Time.Hour
                         select plane;
            Console.WriteLine("Рейс, который вылетает в среду или пятницу позже всех:\n");
            Airline b = Friday.Last();
            Console.Write(b.Destination + " " + b.Flight + " " + b.Airplane + " " + b.Flight_Time + " " + b.Day_of_week);
            Console.Write("\n\n");

            //Список рейсов, упорядоченных по времени вылета

            var Fl = from plane in air
                     orderby plane.Flight_Time.Hour
                     select plane;
            Console.WriteLine("Рейсы, упорядоченные по времени вылета: \n");
            foreach (Airline str in Fl)
                Console.Write(str + ",  ");
            Console.Write("\n\n");

            //Придумайте и напишите свой собственный запрос, в котором было бы не менее 5 операторов из разных категорий: условия, проекций, упорядочивания, группировки, агрегирования, кванторов и разбиения.

            var F = from plane in air
                    where plane.Flight <= 15 && plane.Flight > 1
                    orderby plane.Flight_Time.Hour descending
                    select plane;
            Console.WriteLine("Моя выборка: \n");
            foreach (Airline str in F)
                Console.Write(str + ",  ");
            Console.Write("\n\n");

            //5. Придумайте запрос с оператором Join

            List<Passengers> pass= new List<Passengers>()
            {
                new Passengers {Dest="Москва", Amount_of_people=600},
                new Passengers {Dest="Сеул", Amount_of_people=250}
            };
            List<Flights> flight = new List<Flights>()
            {
                new Flights {Destination="Сеул", Number=23},
                new Flights {Destination="Москва", Number=21}
            };

            var result = flight.Join(pass, p => p.Destination, t => t.Dest, (p, t) => new { Number = p.Number, Dest = t.Dest, Amount_of_people = t.Amount_of_people });
            foreach (var item in result) Console.WriteLine($"{item.Dest} - {item.Amount_of_people} {item.Number}");

           
        }
    }
}