using static System.Console;

namespace ConsoleApp.Inventory
{
    public class ProgramInfo
    {
        public static void AboutMyProgram()
        {
            Clear();

            WriteLine(@$"Sampley Farms IMS is an Inventory Management System that was designed and developed for tracking farm inventory and animals.");

            MainMenu.StartOver();
        }
    }
}