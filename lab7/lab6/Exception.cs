using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lab6
{
    class InvalidLifeTimeException : ArgumentException
    {
        public int Value { get; }
        public InvalidLifeTimeException(string message, int life)
            : base(message)
        {
            Value = life;
            Data.Add("Время возникновения", DateTime.Now);
        }
    }

    class InvalidFigureNameException : ArgumentException
    {
        public string Value { get;}
        public InvalidFigureNameException(string message, string name)
            :base(message)
        {
            Value = name;
            Data.Add("Время возникновения", DateTime.Now);
        }
    }


    class InvalidElementNameException : InvalidFigureNameException
    {
        public InvalidElementNameException(string message, string name)
            :base (message, name)
        {
            Data.Add("Время возникновения", DateTime.Now);
        }
    }
}
