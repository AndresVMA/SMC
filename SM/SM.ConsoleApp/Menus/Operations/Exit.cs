using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SM.ConsoleApp.Menus
{
    public class Exit : IMenuOperation
    {
        private StudentsMenu mainMenu;
        public Exit(StudentsMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }
        public string Name => "Exit";

        public async Task ExecuteOption()
        {
            Console.WriteLine("Exiting app.");
        }
    }
}
