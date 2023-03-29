using System;
using InventorySystem.Services;

namespace InventorySystem
{
    class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Program";
        ErrorLogger.StartLogger();
        Logos.TitleLogo();
        Console.WriteLine();
        Console.WriteLine("What can we help with today? (Press any Key to continue.)");
        Console.ReadKey(true);
        MainMenu.Start();
    }
}
}
   
