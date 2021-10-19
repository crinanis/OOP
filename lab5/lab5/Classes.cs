using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{

    abstract class Geometric_figure
    {
        protected int square = 0;
        public override string ToString() => "Геометрическая фигура";
        public Geometric_figure() { }
        public int GetSq() => square;
        public abstract void GettingSq();
        public virtual void TellingYou(int sq)
        {
            Console.WriteLine($"Пожалуйста, отдохните в течение {sq} минут");
        }
    }

    sealed class Circle : Geometric_figure, ICheckbox, IRadiobutton
    {
        public override string ToString() => "Круг";
        // методы интерфейса
        public void Start_Event() => Console.WriteLine("В качестве фигуры выбран круг");
        public void End_Event() => Console.WriteLine("Мы закончили рассматривать круг");
        public void show() => Console.WriteLine("Показываю вам круг");  // IRadiobutton : Control
        public void input() => Console.WriteLine("Вы добавили свой круг"); //ICheckbox : Control
        // одноименные методы
        public override void GettingSq() => Console.WriteLine("Вы хотите узнать площадь круга (abstract)");
        void ICheckbox.GettingSq() => Console.WriteLine("Вы хотите узнать площадь круга (interface)");

        // переопределение методов object (в 1 классе)

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType()) return false;
            Circle other = (Circle)obj;
            return (square == other.square);
        }

        public override int GetHashCode()
        {
            return DateTime.Now.DayOfYear;
        }
    }

    sealed class Rectangle : Geometric_figure, IButton
    {
        public override string ToString() => "Прямоугольник";
        public void Start_Event() => Console.WriteLine("В качестве фигуры выбран прямоугольник");
        public void End_Event() => Console.WriteLine("Мы закончили рассматривать прямоугольник");
        public void resize() => Console.WriteLine("Вы хотите изменить размер прямоугольника");
        public override void GettingSq() => Console.WriteLine("Площадь прямоугольника ", square += 10);
    }
}
