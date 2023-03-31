using System;
using InventorySystem.Menus;
using InventorySystem.Actions;
using InventorySystem.Services;
using Serilog;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using Console = Colorful.Console;


namespace InventorySystem

{

    public class MainMenu

    {
        private static readonly ItemService _itemService = new ItemService();

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
                "View an Item's details",
                "Remove Item from Inventory",
                "Reports",
                "Program Information",
                "Exit"
            };

            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    AddItem(_itemService);
                    break;

                case 1:
                    UpdateItem(_itemService);
                    break;

                //case 2:
                //    ViewItem(_itemService);
                //    break;

                case 3:
                    DeleteItem(_itemService);
                    break;

                case 4:
                    ReportingMenu.RunReportMenu();
                    break;

                case 5:
                    ProgramInfo.AboutMyProgram();
                    break;

                case 6:
                    Exit();
                    break;
            }
        }


        //private static void AboutMyProgram()
        //{
        //    ProgramInfo.AboutMyProgram();


        //}

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
                    Environment.Exit(0);
                    break;
                case 1:
                    Start();
                    break;
            }
        }

        private static void AddItem(ItemService itemService)
        {
            _ = ItemAdd.AddItem(itemService);
        }

        private static void UpdateItem(ItemService itemService)
        {
            _ = EditItem.UpdateItem(itemService);
        }

        private static void DeleteItem(ItemService itemService)
        {
            _ = ItemDelete.DeleteItem(itemService);
        }

        //private static void ViewItem(ItemService itemService)
        //{
        //    _ = PepperView.ViewAPepper(pepperService);
        //}

        // Recycles to the main menu when user is finished
        public static void MenuReturn()
        {
            Console.WriteLine("\nPress enter to return to the main menu.");
            Console.ReadKey(true);
            MainMenu.Start();
        }
    }
}
