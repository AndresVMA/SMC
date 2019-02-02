using SM.Common.Interfaces;
using SM.Common.Models;
using SM.DataService.CVS;
using System;
using System.Collections.Generic;

namespace SM.ConsoleApp.Menus
{
    /// <summary>
    /// 
    /// </summary>
    public class StudentsMenu : IMenu
    {
        IList<IMenuOperation> _menuItems;
        public string Name => "Main Menu";
        /// <summary>
        /// 
        /// </summary>
        public StudentsMenu()
        {
            IDataService<Student> service = new CSVDataService<Student>();
            _menuItems = new List<IMenuOperation>()
            {
                new CreateStudent(this, service),
                new DeleteStudent(this, service),
                new Search(this, service),
                new Exit(this)
            };
        }
       
        /// <summary>
        /// 
        /// </summary>
        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("Students Options");
            Console.WriteLine();
            for (var i = 0; i < _menuItems.Count; i++)
            {
                Console.WriteLine($"{i+1}. {_menuItems[i].Name}");
            }
            Console.Write("Please enter an option: ");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMenuOperation ProcessInput()
        {
            var menuOption = Console.ReadLine();
            if (int.TryParse(menuOption.ToString(), out var option)
                && option > 0 && option <= _menuItems.Count)
            {
                return _menuItems[option - 1];
            }
            else
            {
                Console.WriteLine($"Option {menuOption} is not valid.");
                return null;
            }
        }
    }
}
