using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    class Printer
    {
        public static void IAmPrinting(Geometric_figure someObj)
        {
            if (someObj is Geometric_figure)
                Console.WriteLine("Тип объекта = " + someObj.ToString());
            else
            {
                Circle tempCir = someObj as Circle;
                if (tempCir != null)
                    Console.WriteLine("Тип объекта = " + tempCir.ToString());
            }
        }
    }
}
