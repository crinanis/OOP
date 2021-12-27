using System;

namespace lab14
{
    interface Control
    {
        void Start_Event();
        void End_Event();
    }
    interface Figure
    {
        int Square { get; set; }
        string Name { get; set; }
    }

    [Serializable]
    public abstract class Geometric_Figure : Figure
    {
        protected int square;
        protected string name;
        
        public int Square
        {
            get => this.square;
            set => this.square = value;
        }
        public string Name
        {
            get => this.name;
            set => this.name = value;
        }

        public override string ToString()
        {
            return "Геометрическая фигура с заданной площадью";
        }
    }
    
    [Serializable]
    public sealed class Rectangle : Geometric_Figure, Control
    {
        public string color;

        public Rectangle()
        {
            this.color = "Black";
            this.name = "Rectangle";
            this.square = 555;
        }

        public Rectangle(string color, string name, int square)
        {
            this.color = color;
            this.name = name;
            this.square = square;
        }
        
        void Control.Start_Event()
        {
            Console.WriteLine("В качестве фигуры выбран прямоугольник");
        }
        void Control.End_Event()
        {
            Console.WriteLine("Мы закончили рассматривать прямоугольник");
        }
        
        public override string ToString()
        {
            return $"Название: {name} Цвет: {color} Площадь: {square} ";
        }
        
        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            Rectangle other = (Rectangle)obj;
            return (square == other.square);
        }

        public override int GetHashCode()
        {
            return DateTime.Now.DayOfYear;
        }
    }
}