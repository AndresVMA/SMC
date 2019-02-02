using SM.ConsoleApp.Menus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SM.ConsoleApp
{
    internal class MenuManager
    {
        private string _fileNameArg;
        private ICollection<string> _searchArguments;
        internal async Task Render(string[] args)
        {
            SetupUserArguments(args);
            IMenu currentMenu = new StudentsMenu(_fileNameArg, _searchArguments);
            IMenuOperation menuOption;
            Console.WriteLine();
            Console.WriteLine("==================================  Student Manager (SM) 1.0 =======================================");
            do
            {
                Console.Clear();
                if (currentMenu.AutomaticRunOperation != null)
                {
                    menuOption = currentMenu.AutomaticRunOperation;
                }
                else
                {
                    currentMenu.Display();
                    menuOption = currentMenu.ProcessInput();
                }

                if (menuOption != null)
                {
                    await menuOption.ExecuteOption();
                    menuOption.AutomaticRun = false;
                }
            } while (!(menuOption is Exit));
        }

        private void SetupUserArguments(string[] args)
        {
            _searchArguments = new List<string>();
            for (int i = 0; i < args.Length; i++)
            {
                if (i == 0)
                {
                    _fileNameArg = args[i];
                    continue;
                }
                _searchArguments.Add(args[i]);
            }
        }

    }
}
