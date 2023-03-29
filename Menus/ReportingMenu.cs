using static System.Console;

namespace InventorySystem.Menus
{
    public class ReportingMenu
    {
        public static void RunReportMenu()

        {
            
            string prompt = "Please use the UP (↑) and DOWN (↓) arrow keys to select the report you want to run and press Enter. \n";
            string[] options =
            {
                "All Inventory",
                "All Items",
                "All Livestock",
                "Low Items",
                "Out of Stock Items",
                "Return to Main Menu"

            };
            
            Menu reportMenu = new Menu(prompt, options);
            int selectedIndex = reportMenu.Run();

            switch (selectedIndex)
            {

                //    case 4:
                //        ErrorLog.Error();
                //        break;

                case 5:
                    MainMenu.Start();
                    break;

                    //    case 6:
                    //        Exit();
                    //        break;
                    //
            }
        }
    }
}
