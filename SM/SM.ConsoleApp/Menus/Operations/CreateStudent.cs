using SM.Common.Models;
using SM.Common.Enums;
using System;
using System.Collections.Generic;
using SM.Common.Interfaces;
using System.Threading.Tasks;

namespace SM.ConsoleApp.Menus
{
    internal class CreateStudent : IMenuOperation
    {
        private StudentsMenu _parentMenu;
        
        private IDataService<Student> _service;
        private const string GenderMessage = "Enter the student gender: (M) Male, F (Female): ";
        private const string SchoolTypeMessage = "Enter the student shool type: (H) High, E (Elementary), K (Kinder Garden): ";
        private readonly List<char> _validGenderTypes = new List<char> { 'M', 'F' };
        private readonly List<char> _validSchoolTypes = new List<char> { 'H', 'E', 'K' };
        public CreateStudent(StudentsMenu mainMenu, IDataService<Student> service)
        {
            _parentMenu = mainMenu;
            _service = service;
        }

        public string Name => "Create";

        public async Task ExecuteOption()
        {
            var student = new Student();
            var studentType = nameof(Student);
            student.Name = InputManager.GetValidStringEntry(studentType, nameof(Student.Name));
            var gender = InputManager.GetValidCharEntry(GenderMessage, _validGenderTypes);
            student.Gender = gender == 'M' ? GenderType.Male : GenderType.Female;
            var schoolType = InputManager.GetValidCharEntry(SchoolTypeMessage, _validSchoolTypes);
            student.SchoolType = schoolType == 'H' ? SchoolType.High : (schoolType == 'E'? SchoolType.Elementary : SchoolType.KinderGarden);
            var result = await _service.CreateAsync(student);
            if (result)
            {
                Console.WriteLine("Student Created Successfully. press any key to continue..");
                Console.ReadKey();
            }
        }
    }
}