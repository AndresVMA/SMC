using SM.ConsoleApp.Menus;
using System;
using System.Threading.Tasks;

namespace SM.ConsoleApp
{
    internal class MenuManager
    {
        
        internal async Task Render()
        {
            IMenu currentMenu = new StudentsMenu();
            IMenuOperation menuOption;
            Console.WriteLine();
            Console.WriteLine("==================================  Student Manager (SM) 1.0 =======================================");
            do
            {
                Console.Clear();
                currentMenu.Display();
                menuOption = currentMenu.ProcessInput();
                if (menuOption != null)
                {
                    await menuOption.ExecuteOption();
                }
            } while (!(menuOption is Exit));
        }
    }
}
