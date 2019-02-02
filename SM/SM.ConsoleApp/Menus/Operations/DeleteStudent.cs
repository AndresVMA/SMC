﻿using SM.Common.Interfaces;
using SM.Common.Models;
using System.Threading.Tasks;

namespace SM.ConsoleApp.Menus
{
    internal class DeleteStudent : IMenuOperation
    {
        private StudentsMenu _mainMenu;
        private IDataService<Student> _service;
        public DeleteStudent(StudentsMenu mainMenu, IDataService<Student> service)
        {
            _mainMenu = mainMenu;
            _service = service;
        }

        public string Name => "Delete";

        public Task ExecuteOption()
        {
            throw new System.NotImplementedException();
        }
    }
}