﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace lab6
{
    public partial struct UI
    {
        public ArrayList figures { get; set; }
        public string name;
        public int count;
        public double square;
        public int radius;
        public bool isBut;
        

        public UI(string _name, bool controlBut)
        {
            figures = new ArrayList();
            isBut = controlBut;
            name = _name;
            count = 0;
            radius = 0;
            square = 1;
        }
    }
}
