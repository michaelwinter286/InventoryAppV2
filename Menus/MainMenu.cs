using System;
using Serilog;
using System.Text;
using System.Threading.Tasks;
using static System.Console;





namespace ConsoleApp.Inventory

{
  
    public class MainMenu
        
    {
                //private static readonly PepperService _pepperService = new PepperService();

        public static void Start()
        {
            var mainMenu = new MainMenu();
            RunMainMenu();
        }

        public static void RunMainMenu()

        {
            
            string prompt = "Please use the UP (↑) and DOWN (↓) arrow keys to select an option and then press enter. \n";
            string[] options =
            {
                "Add New Item",
                "Update Existing Item/Animal",
                "View an Item",
                "Remove Item from Inventory",
                "Reports",
                "Program Information",
                "Exit"
            };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                
                case 4:
                    ErrorLog.Error();
                    break;

                case 5:
                    AboutMyProgram();
                    break;

                case 6:
                    Exit();
                    break;
            }
        }

        //private static void ViewAllPeppers(PepperService pepperService)
        //{
        //    _ = PepperList.ListAllPeppersInDatabase(pepperService);
        //}

        //private static void ViewPeppersByHeatClass(PepperService pepperService)
        //{
        //    PepperByHeatClassList.DisplayHeatClassMenu();
        //}

        //private static void ViewAPepper(PepperService pepperService)
        //{
        //    _ = PepperView.ViewAPepper(pepperService);
        //}

        //private static void AddAPepper(PepperService pepperService)
        //{
        //    _ = PepperCreate.CreateNewPepper(pepperService);
        //}

        //private static void UpdateAPepper(PepperService pepperService)
        //{
        //    _ = PepperUpdate.UpdateAPepper(pepperService);
        //}

        //private static void RemoveAPepper(PepperService pepperService)
        //{
        //    _ = PepperDelete.RemoveAPepper(pepperService);
        //}

        //private static void SaveListOfPeppersToATextFile(PepperService pepperService)
        //{
        //    _ = PepperList.SaveAllPeppersToTextFile(pepperService);
        //}

        private static void AboutMyProgram()
        {
            ProgramInfo.AboutMyProgram();


        }

        private static void Exit()
        {
            string prompt = "\nAre you sure you wish to exit the program?";
            string[] options = { "\nYes", "No" };

            Menu exitMenu = new Menu(prompt, options);
            int selectedIndex = exitMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Console.WriteLine("\nHave a Great rest of your Day!!");
                    //Log.CloseAndFlush();
                    Environment.Exit(0);
                    break;
                case 1:
                    Start();
                    break;
            }
        }

        // Recycles to the main menu when user is finished
        public static void StartOver()
        {
            Console.WriteLine("\nPress enter to return to the main menu.");
            Console.ReadKey(true);
            MainMenu.Start();
        }
    }
}
