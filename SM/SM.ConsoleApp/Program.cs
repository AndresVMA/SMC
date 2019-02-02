using System;

namespace SM.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var mainUi = new MenuManager();
            mainUi.Render().Wait();
        }
    }
}
