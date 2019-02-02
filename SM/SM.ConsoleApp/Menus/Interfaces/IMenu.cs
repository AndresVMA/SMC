using System;
using System.Collections.Generic;
using System.Text;

namespace SM.ConsoleApp.Menus
{
    public interface IMenu
    {
        string Name { get; }
        void Display();
        IMenuOperation ProcessInput();
    }
}
