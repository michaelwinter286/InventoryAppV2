using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using ConsoleApp.Inventory;
using Serilog;


namespace InventorySystem
{
    class ErrorLog
    {
        public static void Error()
        {
            try
            {
                Console.Clear();
                Console.Write("Here are your Errors thus far.\n\n");
                StreamReader sr = new StreamReader("ErrorLog.txt");
                string? error = sr.ReadLine();

                while (error != null)
                {
                    Console.WriteLine(error);
                    error = sr.ReadLine();
                }

                Console.ReadKey(true);
                sr.Close();
                MainMenu.RunMainMenu();
            }

            catch (FileNotFoundException ex)
            {

                Console.Clear();
                Logos.TitleLogo();
                
                Console.WriteLine("\n\n\n So.. Currently you have not had any errors to log. Congrats! But unfortunitly you have just created one! HAHA! Please run Error Log again to view. Press any key to return to Main Menu.\n\n" + "Error:" + ex);
                Log.Error("File Error: File Not Found (ErrorLog). Error generates file creation.");
                Log.CloseAndFlush();
                Console.Beep(1000, 1000); // Thanks Dave!!
                Console.ReadKey();
                MainMenu.RunMainMenu();
            }
        }
    }
}

//    else if (option == "6")
//{
//    ConsoleExit.Exit();
//}
//else
//{
//    Console.WriteLine("Error! Please select a valid option!");
//    Console.Beep(1000, 1000); // Thanks Dave!!
//    Thread.Sleep(2000);

    

