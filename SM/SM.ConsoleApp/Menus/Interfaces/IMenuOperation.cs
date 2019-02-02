using System.Threading.Tasks;

namespace SM.ConsoleApp.Menus
{
    public interface IMenuOperation
    {
        string Name { get; }
        Task ExecuteOption();
        bool AutomaticRun { get; set; }
    }
}
