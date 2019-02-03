using System;
using System.Threading.Tasks;

namespace SM.ConsoleApp.Menus
{
    internal class Exit : IMenuOperation
    {
        private StudentsMenu mainMenu;
        public string Name => "Exit";
        public bool AutomaticRun { get; set; }

        public Exit(StudentsMenu mainMenu)
        {
            this.mainMenu = mainMenu;
        }

        public async Task ExecuteOption()
        {
            Console.WriteLine("Exiting app.");
        }
    }
}
