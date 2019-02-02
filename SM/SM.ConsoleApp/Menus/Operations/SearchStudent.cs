using SM.Common.Interfaces;
using SM.Common.Models;
using System.Threading.Tasks;

namespace SM.ConsoleApp.Menus
{
    internal class Search : IMenuOperation
    {
        private StudentsMenu _mainMenu;
        private IDataService<Student> _service;

        public Search(StudentsMenu mainMenu, IDataService<Student> service)
        {
            _mainMenu = mainMenu;
            _service = service;
        }

        public string Name => "Search";

        public Task ExecuteOption()
        {
            throw new System.NotImplementedException();
        }
    }
}