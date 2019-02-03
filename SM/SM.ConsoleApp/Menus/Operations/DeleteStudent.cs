using SM.Common.Interfaces;
using SM.Common.Models;
using System.Threading.Tasks;
using System;
namespace SM.ConsoleApp.Menus
{
    internal class DeleteStudent : IMenuOperation
    {
        private StudentsMenu _mainMenu;
        private IDataService<Student> _service;
        public bool AutomaticRun { get; set; }
        public string Name => "Delete";

        public DeleteStudent(StudentsMenu mainMenu, IDataService<Student> service)
        {
            _mainMenu = mainMenu;
            _service = service;
        }

        public async Task ExecuteOption()
        {
            Console.WriteLine();
            var studentId = InputManager.GetValidInteger("Enter the student Id: ");
            var toDelete = await _service.GetAsync(studentId);
            Console.WriteLine("The following student will be deleted:");
            Console.WriteLine($"{toDelete.Name} {toDelete.SchoolType} {toDelete.Gender} {toDelete.LastModifiedDate}");
            Console.WriteLine("Are you sure you want to delete it? yes(Y) / any other key to cancel: ");
            var confirmation = Console.ReadLine();
            if (confirmation.Equals("y", StringComparison.InvariantCultureIgnoreCase))
            {
                var deleteResult = await _service.DeleteAsync(studentId);
                if (deleteResult)
                {
                    Console.WriteLine("record deleted sucessfully. press any key to continue..");
                    Console.ReadKey();
                    return;
                }
            }
            Console.WriteLine("operation cancelled. press any key to continue..");
            Console.ReadKey();
        }
    }
}