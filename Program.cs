using System;
using InventoryAppV2.Menus;

namespace InventoryAppV2
{
    class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Program";
        Logos.TitleLogo();
        Console.WriteLine();
        Console.WriteLine("What can we help with today? (Press any Key to continue.)");
        Console.ReadKey(true);
        MainMenu.Start();
    }
}
}
   
