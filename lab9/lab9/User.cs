using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9
{
    class User
    {
        public delegate void Events(string message);
        public event Events Replace;
        public event Events Squeeze;
        public event Events shakalaka;

        public User(string name, int moving, int bias)
        {
            Name = name;
            Moving = moving;
            Bias = bias;
        }

        public int Moving { get; private set; }
        public int Bias { get; private set; }
        public string Name { get; private set; }


        public void ChangingBias (int num)
        {
            Bias += num;
            Squeeze?.Invoke($"Сжатие изменилось на + {num}");             //В этом случае поскольку событие представляет делегат, то мы можем его вызвать с помощью метода Invoke(), передав в него необходимые значения для параметров.
            shakalaka?.Invoke("Anonimus");
        }

        public void ChangingMovement(int num)
        {
            Moving += num;
            Replace?.Invoke($"Перемещение изменилось на + {num}");
        }
    }
}