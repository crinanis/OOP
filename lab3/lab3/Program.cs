using System;

namespace lab3
{
    class Program
    {
        public partial class Airline
        {
            public static int NumOfFlights = 0;     //статичсеское поле, хранящее количество созданных объектов
            public readonly int id;                 //поле, доступное только для чтения
            private string Country;
            private int Flight_Number;              //закрытые поля
            private string Airplane_type;
            private DateTime Departure;
            private string Day;

            public string Destination                       //общедоступные свойства
            {
                get { return this.Country; }
                private set { this.Country = value; }
            }
            public int Flight
            {
                get { return this.Flight_Number; }        //ограничили доступ по set, т.е. свойство доступно только для чтения
            }
            public string Airplane
            {
                get { return this.Airplane_type; }
                set { this.Airplane_type = value; }
            }
            public DateTime Flight_Time
            {
                get { return this.Departure; }
                private set { this.Departure = value; }
            }
            public string Day_of_week
            {
                get { return this.Day; }
                set { this.Day = value; }
            }
        }

        public partial class Airline
        {
            //конструктор с параметрами по умолчанию
            public Airline()
            {
                this.id = Airline.NumOfFlights++;
                this.Country = "";
                this.Flight_Number = 0;
                this.Airplane_type = "";
                this.Departure = DateTime.MinValue;
                this.Day = "";
            }
            //конструктор базового класса
            public Airline(string Country, int Flight_Number, string Airplane_Type, DateTime Departure, string Day)
            {
                this.id = Airline.NumOfFlights++;
                this.Country = Country;
                this.Departure = Departure;
                this.Airplane_type = Airplane_Type;
                this.Day = Day;
                this.Flight_Number = Flight_Number;
            }
            //статический конструктор
            static Airline() { Console.WriteLine("Вызвался статический конструктор\n"); }
            ~Airline()
            {
                Airline.NumOfFlights--;
            }

            public override bool Equals(object obj)                 //переопределение метода Equals()
            {
                Airline temp = obj as Airline;
                if (temp == null)
                    return false;
                return (temp.Departure == this.Departure && temp.Day == this.Day && temp.Country == this.Country  && temp.Flight_Number == this.Flight_Number && temp.Airplane_type == this.Airplane_type);
            }
            public override int GetHashCode()                       //переопределение метода GetHashCode()
            {
                Console.WriteLine("Вызвался переопределенный метод GetHashCode");
                return base.GetHashCode();
            }
            public override string ToString()                       //переопределение метода ToString()
            {
                return ($"Пункт назначения: {this.Country}, День недели: {this.Day}, Номер рейса: {this.Flight_Number}, Тип самолёта: {this.Airplane_type}");
            }

            public static void sort_by_day(Airline[] arr, string dep_day)                  //статический метод вывода информации
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Day_of_week.Equals(dep_day))
                    {
                        Console.WriteLine($"Пункт назначения: {arr[i].Destination}");
                        Console.WriteLine($"Номер рейса: { arr[i].Flight}");
                        Console.WriteLine($"Тип самолёта: {arr[i].Airplane}");
                        Console.WriteLine($"День недели: { arr[i].Day_of_week}");
                        Console.WriteLine($"Время отлёта: { (arr[i].Flight_Time).ToLongTimeString()}");
                    }
                }
            }

            public static void sort_by_destination(Airline[] arr, ref string place)         //статический метод вывода информации + используем параметр ref (передаём параметр по ссылке)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Destination == place)
                    {
                        Console.WriteLine($"Пункт назначения: {arr[i].Destination}");
                        Console.WriteLine($"Номер рейса: { arr[i].Flight}");
                        Console.WriteLine($"Тип самолёта: {arr[i].Airplane}");
                        Console.WriteLine($"День недели: { arr[i].Day_of_week}");
                        Console.WriteLine($"Время отлёта: { (arr[i].Flight_Time).ToLongTimeString()}");
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Airline dep1 = new Airline();
            Airline dep2 = new Airline("Москва", 253, "Airbus A310", new DateTime(2000, 12, 08, 18, 30, 25), "Понедельник");

            Console.WriteLine("Проверяем два объекта на равенство:");
            if (dep2.Equals(dep1))                  //сравнение объектов
                Console.WriteLine("Равны\n");
            else
                Console.WriteLine("Не равны\n");

            Console.WriteLine("Определяем тип:\n" + dep2.GetType() + "\n");      //определение типа

            var flight = new { destination_adress = "Гонконг", flight_number = 2, typeofplane = "Boeing-777", flight_time = new DateTime(2021, 09, 03), day_week = "Воскресенье" }; //Создание анонимного типа

            Airline[] departures = new Airline[7] {new Airline("Минск",     162,    "Boeing-747",  new DateTime(2021, 09, 28, 19, 00, 00), "Суббота"),
                                                   new Airline("Гонконг",   3299,   "Boeing-777",  new DateTime(2021, 09, 22, 21, 45, 00), "Среда"),
                                                   new Airline("Шанхай",    557,    "Boeing-737",  new DateTime(2021, 09, 16, 15, 30, 35), "Четверг"),
                                                   new Airline("Гонконг",   13,     "Boeing-777",  new DateTime(2021, 09, 04, 22, 50, 00), "Вторник"),
                                                   new Airline("Чикаго",    27,     "Boeing-767",  new DateTime(2021, 09, 09, 16, 30, 55), "Суббота"),
                                                   new Airline("Гонконг",   27,     "Boeing-747",  new DateTime(2021, 09, 15, 06, 00, 00), "Пятница"),
                                                   new Airline("Сеул",      27,     "Airbus A320", new DateTime(2021, 09, 13, 15, 25, 00), "Суббота") };

            Console.WriteLine("Сортировка по пункту назначения:\n");
            string needed_place = "Гонконг";
            Airline.sort_by_destination(departures, ref needed_place); //передаём параметр по ссылке
            Console.WriteLine("\n");
            Console.WriteLine("Сортировка по дню недели рейса:\n");
            Airline.sort_by_day(departures, "Суббота");
            Console.WriteLine("\nЧисло созданных объектов: " + Airline.NumOfFlights + "\n");

            Console.WriteLine("press any key to exit :3");
            Console.ReadKey();
        }
    }
}

// Пример закрытого конструктора:
//class MyClass
//{
//    //Закрытый конструктор
//    private MyClass(){}
//    public static int MyPhoneNumber = 1239999;
//    public static int SomeNumber = 1;
//    public static int GetSomeNumber()
//    {
//     SomeNumber++;
//     return SomeNumber;
//    }
// }
//class Test
//{
//    public static void Main()
//    {
//        System.Console.WriteLine(MyClass.GetSomeNumber()); //Выведется 2
//        System.Console.WriteLine(MyClass.GetSomeNumber()); //Выведется 3
//        MyClass a=new MyClass(); //ошибка!!!
//    }
//}