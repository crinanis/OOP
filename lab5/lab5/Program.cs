using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    interface ICloneable
    {
        bool DoClone();
    }
    abstract class BaseClone { public abstract bool DoClone(); }
    class UserClass : BaseClone, ICloneable
    {
        bool ICloneable.DoClone()
        {
            Console.WriteLine("Object has been cloned\n");
            return true;
        }
        public override bool DoClone()
        {
            Console.WriteLine("Object hasn't been cloned\n");
            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            UserClass a = new UserClass();
            a.DoClone();
            ICloneable Ia = a;
            Ia.DoClone();


            Console.WriteLine("Работа с кругом:\n");
            Circle cir = new Circle();
            ICheckbox check = cir;
            cir.Start_Event();
            cir.show();
            cir.input();
            cir.TellingYou(10);
            cir.GettingSq();
            if (cir is Geometric_figure)
            {
                Console.WriteLine($"{cir} is Geometric figure"); // true
            }
            cir.GettingSq();
            check.GettingSq();
            Console.WriteLine("________________________________________\n");

            Console.WriteLine("Работа с прямоугольником:\n");
            Rectangle rec = new Rectangle();
            IButton but = rec;
            rec.Start_Event();
            rec.resize();
            rec.TellingYou(25);
            rec.GettingSq();
            if (but as Geometric_figure != null)
            {
                Console.WriteLine($"{but} as Geometric figure\n"); //true
            }
            Console.WriteLine("________________________________________\n");
        }
    }
}
