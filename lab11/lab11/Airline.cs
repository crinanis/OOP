using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public partial class Airline
    {
        public static int NumOfFlights = 0;             //статичсеское поле, хранящее количество созданных объектов
        public readonly int id;                         //поле, доступное только для чтения
        private string Country;
        private int Flight_Number;                      //закрытые поля
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
            get { return this.Flight_Number; }          //ограничили доступ по set, т.е. свойство доступно только для чтения
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
            return (temp.Departure == this.Departure && temp.Day == this.Day && temp.Country == this.Country && temp.Flight_Number == this.Flight_Number && temp.Airplane_type == this.Airplane_type);
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
    }

    class Passengers
    {
        public string Dest { get; set; }
        public int Amount_of_people { get; set; }
    }
    class Flights
    {
        public string Destination { get; set; }
        public int Number { get; set; }
    }
}
