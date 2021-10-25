using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;


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
        public int lifeTime;
        public double square;
        public string type = "Geometric figures";

        public Figures(string _name, int _lifetime, Colour col)
        {
            if (_name.Length > 10)
                throw new InvalidFigureNameException("Длина названия фигуры не может превышать 10 символов", _name);
            else name = _name;

            if (_lifetime > 5)
                throw new InvalidLifeTimeException("Время существования объекта не может превышать 5 лет", _lifetime);
            else lifeTime = _lifetime;

            radius = (int)col;
        }

        void Elements.Info()
        {
            Console.WriteLine($"Название: {name}\tЦвет: {radius}\tТип: {type}\t Время жизни: {lifeTime}");
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

        public ControlElem(string _name, int _lifetime, Colour col, bool _controlBut = true)
            : base(_name, _lifetime, col)
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
                        Elements soldierH = new Figures(names[r.Next() % names.Length], 1, (Colour)(1 + (r.Next() % 5)));
                        Add(soldierH);
                        break;
                    case (1):
                        Elements soldierT = new ControlElem(names[r.Next() % names.Length], 1, (Colour)(1 + (r.Next() % 5)), isBut);
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
            //Figures a = new Figures("Rectangle", 1, Colour.BLUE);
            //ControlElem b = new ControlElem("Сircle", 3, Colour.BROWN);

            UI first = new UI("12345", false);
            first.AddAnyElem(100);

            UI second = new UI("qwerty", true);
            second.AddAnyElem(125);

            first.Show();
            second.Show();

            Console.WriteLine("\n--------------------------------------Исключения---------------------------------");
            try
            {
                Figures ex1 = new Figures("triangle", 25, Colour.PURPLE);
            }
            catch(InvalidLifeTimeException exc)
            {
                Logger.Log(exc, true, true);
            }
            finally
            {
                Console.WriteLine("Блок finally---------------------------------------------------------------------");
            }

            try
            {
                Figures ex2 = new Figures("triangleeeee", 2, Colour.RED);
            }
            catch (InvalidFigureNameException exc)
            {
                Logger.Log(exc, true, true);
            }
            finally
            {
                Console.WriteLine("Блок finally---------------------------------------------------------------------");
            }

            try
            {
                UI ex3 = new UI("123123212325345345132", true);
            }
            catch (InvalidFigureNameException exc)
            {
                Logger.Log(exc, true, true);
            }
            finally
            {
                Console.WriteLine("Блок finally---------------------------------------------------------------------");
            }

            // другие ошибки

            try
            {
                int p = 64;
                int c = 0;
                if (c == 0) throw new DivideByZeroException("Делить на ноль нельзя");
                else p /= c;
            }
            catch(DivideByZeroException exc)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine($"Сообщение: {exc.Message}");
                Console.WriteLine("-> Место возникновения: {0}", exc.TargetSite);
            }
            finally
            {
                Console.WriteLine("Блок finally---------------------------------------------------------------------");
            }
            

            bool flag = true;
            try
            {
                Char ch = Convert.ToChar(flag);
                Console.WriteLine("Преобразование прошло успешно");
            }
            catch (InvalidCastException exc)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine("Сообщение: Невозможно преобразовать boolean в char");
                Console.WriteLine("-> Место возникновения: {0}", exc.TargetSite);
            }
            finally
            {
                Console.WriteLine("Блок finally---------------------------------------------------------------------");
            }

            int[] arr = { 1, 2, 3, 4, 5 }; // массив размером 5
            try
            {
                int length = 10;
                if (length > arr.Length) throw new IndexOutOfRangeException("С таким length будет выход за массив arr!");
                for (int i = 0; i < length; i++)
                    arr[i] += arr[i];
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("\n\tОшибка");
                Console.WriteLine($"Сообщение: {ex.Message}");
                Console.WriteLine("-> Место возникновения: {0}", ex.TargetSite);
            }
            finally
            {
                Console.WriteLine("Блок finally---------------------------------------------------------------------");
            }


            Debug.Assert(1 == 0, "Check");
        }
    }
}
