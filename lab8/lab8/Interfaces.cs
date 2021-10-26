using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    public interface Control
    {
        void Start_Event();
        void End_Event();
    }

    public interface ICheckbox : Control
    {
        void input();
        void GettingSq();
    }

    public interface IRadiobutton : Control
    {
        void show();
    }

    public interface IButton : Control
    {
        void resize();
    }

    public interface ISquare
    {
        int GetSq();
        void GettingSq(int s);
    }
}
