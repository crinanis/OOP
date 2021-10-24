using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;

namespace lab6
{
    public interface Elements
    {
        void Info();
    }

    public class Figures : Elements
    {
        public string name;
        public int radius;
        public double square;
        public string type = "Geometric figures";

        public Figures(string _name, Colour col)
        {
            name = _name;
            radius = (int)col;
        }

        void Elements.Info()
        {
            Console.WriteLine($"Название: {name}\tЦвет: {radius}\tТип: {type}");
        }

        public override string ToString()
        {
            string description = $"Название объекта: {nameof(Figures)}\n" +
                $"Имя: {name}";

            return description;
        }

    }

    public class ControlElem : Figures, Elements
    {
        private bool controlBut;
        public new string type = "Controlling element";

        public ControlElem(string _name, Colour col, bool _controlBut = true)
            : base(_name, col)
        {
            controlBut = _controlBut;
        }

        public bool isBut() => controlBut;

        void Elements.Info()
        {
            Console.WriteLine($"Название: {name}\tЦвет: {radius}\tТип: {type}");
        }

        public override string ToString()
        {
            string description = $"Имя объекта: {nameof(ControlElem)}\n" +
                $"Является кнопкой: {controlBut}";

            return description;
        }
    }

    public partial struct UI
    {

        public void Add(Elements elem)
        {
            radius = (elem as Figures).radius * (elem as Figures).radius;
            square = radius * Math.PI * 100;
            if (isBut)
            {
                if (elem is ControlElem) figures.Add(elem);
            }
            else if (!isBut)
            {
                if (elem is Figures) figures.Add(elem);
            }
        }

        public void Show()
        {
            Console.WriteLine($"\t\nИнформация об UI {name}");
            Console.WriteLine($"Управляющие элементы: {isBut}");
            Console.WriteLine($"Количество: {figures.Count}:");
            Console.WriteLine($"Площадь: {square}");
            if (figures.Count != 0)
            {
                foreach (Elements o in figures)
                    o.Info();
            }
        }

        public void AddAnyElem(int count = 1)
        {
            Random r = new Random();
            string[] names = { "Circle", "Square", "Rectangle"};

            for (int i = 0; i < count; i++)
            {
                switch (isBut ? 1 : r.Next() % 2)
                {
                    case (0):
                        Elements soldierH = new Figures(names[r.Next() % names.Length], (Colour)(1 + (r.Next() % 5)));
                        Add(soldierH);
                        break;
                    case (1):
                        Elements soldierT = new ControlElem(names[r.Next() % names.Length], (Colour)(1 + (r.Next() % 5)), isBut);
                        Add(soldierT);
                        break;
                    default:
                        break;
                }
            }
        }

        bool IsBut() => isBut;
    }
    public enum Colour
    {
        PURPLE = 25,
        BLUE = 30,
        RED = 40,
        YELLOW = 60,
        GREEN = 125,
        BROWN = 999
    }

    class Program
    {
        static void Main(string[] args)
        {
            Figures a = new Figures("Rectangle", Colour.BLUE);
            ControlElem b = new ControlElem("Сircle", Colour.BROWN);

            UI first = new UI("12345", false);
            first.AddAnyElem(100);

            UI second = new UI("qwerty", true);
            second.AddAnyElem(125);

            first.Show();
            second.Show();
        }
    }
}
