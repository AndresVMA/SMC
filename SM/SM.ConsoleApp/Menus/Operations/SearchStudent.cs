using SM.Common.Interfaces;
using SM.Common.Models;
using System.Threading.Tasks;
using System;
using SM.DataService.CSV.Adapters;
using System.Collections.Generic;
using SM.DataService.CSV.Helpers;
using SM.Common.Enums;

namespace SM.ConsoleApp.Menus
{
    internal class Search : IMenuOperation
    {
        private StudentsMenu _mainMenu;
        private IDataService<Student> _service;
        public bool AutomaticRun { get; set; }
        public string Name => "Search";
        public IEnumerable<string> SearchArguments { get; internal set; }

        public Search(StudentsMenu mainMenu, IDataService<Student> service)
        {
            _mainMenu = mainMenu;
            _service = service;
        }

        public async Task ExecuteOption()
        {
            IEnumerable<Student> students = await _service.GetAllAsync();
            if (SearchArguments != null && AutomaticRun)
            {
                students = FilterHelper.FilterStudents(students, SearchArguments);
            }
            else
            {
                var searchArguments = PromptSearchCriteria();
                students = FilterHelper.FilterStudents(students, searchArguments);
            }
            Console.WriteLine("Search results:");
            Console.Write($"{nameof(Student.Id)}\t");
            Console.Write($"{nameof(Student.SchoolType)}\t");
            Console.Write($"{nameof(Student.Name)}\t\t");
            Console.Write($"{nameof(Student.Gender)}\t");
            Console.Write($"{nameof(Student.LastModifiedDate)}\t");
            Console.WriteLine();
            foreach (var student in students)
            {
                var space = student.SchoolType == SchoolType.Elementary ? "\t" : "\t\t";
                var nameSpace = student.Name.Length <= 7 ? "\t\t" : "\t";
                Console.Write($"{student.Id}\t");
                Console.Write($"{student.SchoolType}{space}");
                Console.Write($"{student.Name}{nameSpace}");
                Console.Write($"{student.Gender}\t");
                Console.Write($"{student.LastModifiedDate}\t");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private IEnumerable<string> PromptSearchCriteria()
        {
            Console.WriteLine("Please enter a search criteria, e.g. type=High");
            Console.WriteLine("Multiple search criterias can be specified separated by one space.");
            var searchCriteria = InputManager.GetValidSearchCriteria("Search Criteria: ");
            return searchCriteria.Split(" ");
        }
    }
}