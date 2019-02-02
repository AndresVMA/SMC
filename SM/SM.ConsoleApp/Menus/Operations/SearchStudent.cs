using SM.Common.Interfaces;
using SM.Common.Models;
using System.Threading.Tasks;
using System;
using SM.DataService.CSV.Adapters;
using System.Collections.Generic;
using System.Linq;

namespace SM.ConsoleApp.Menus
{
    internal class Search : IMenuOperation
    {
        private StudentsMenu _mainMenu;
        private IDataService<Student> _service;
        private IModelAdapter<Student> _modelAdapter;
        public bool AutomaticRun { get; set; }
        public string Name => "Search";
        public IEnumerable<string> SearchArguments { get; internal set; }

        public Search(StudentsMenu mainMenu, IDataService<Student> service)
        {
            _mainMenu = mainMenu;
            _service = service;
            _modelAdapter = new StudentAdapter();
        }

        public async Task ExecuteOption()
        {
            IEnumerable<Student> students = await _service.GetAllAsync(_modelAdapter);
            if (SearchArguments != null)
            {
                students = FilteredStudents(students);
            }
            Console.WriteLine("Search results:");
            Console.Write($"{nameof(Student.SchoolType)}\t");
            Console.Write($"{nameof(Student.Name)}\t");
            Console.Write($"{nameof(Student.Gender)}\t");
            Console.Write($"{nameof(Student.LastModifiedDate)}\t");
            Console.WriteLine();
            foreach (var student in students)
            {
                Console.Write($"{student.SchoolType}\t\t");
                Console.Write($"{student.Name}\t");
                Console.Write($"{student.Gender}\t");
                Console.Write($"{student.LastModifiedDate}\t");
                Console.WriteLine();
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private IEnumerable<Student> FilteredStudents(IEnumerable<Student> studentList)
        {
            IEnumerable<Student> filterResult = studentList;
            foreach (var filter in SearchArguments)
            {
                var equalSignIndex = filter.IndexOf("=");
                var property = filter.Substring(0, equalSignIndex);
                var filterValue = filter.Substring(equalSignIndex + 1);
                filterResult = FilterByProperty(filterResult, property, filterValue);
            }

            return filterResult;
        }

        private IEnumerable<Student> FilterByProperty(
            IEnumerable<Student> studentList, 
            string propertyName, 
            string propertyValue)
        {
            IEnumerable<Student> filterResult = studentList;
            Func<Student, bool> predicate = null;
            switch (propertyName)
            {
                case "type":
                    predicate = s => s.SchoolType.ToString()
                        .Equals(propertyValue, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "name":
                    predicate = s => s.Name.ToString()
                        .Equals(propertyValue, StringComparison.InvariantCultureIgnoreCase);
                    break;
                case "gender":
                    predicate = s => s.Gender.ToString()
                        .Equals(propertyValue, StringComparison.InvariantCultureIgnoreCase);
                    break;
                default:
                    break;
            }
            if (predicate != null)
            {
                filterResult = studentList.Where(predicate).Select(s => s);
            }
            return filterResult;
        }
    }
}