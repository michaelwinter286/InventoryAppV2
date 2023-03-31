using System;
using Serilog;
using System.Globalization;
using static System.Console;
using InventorySystem.Entities;
using InventorySystem.Services;


namespace InventorySystem.Actions
{
    public class ItemAdd
    {
        
        public static async Task AddItem(ItemService itemService)
        {
            Clear();

            var item = new Item();
            string? titleCaseItemName = "";
            int shuMinValue;
            

            while (true)
            {
                
                WriteLine("What new Item would you like to add into the Inventory?");
                string? itemName = ReadLine();
                
                if (string.IsNullOrEmpty(itemName))
                {
                    WriteLine("Oops Sorry! Items must have a name. Cannot be left blank!");
                    Log.Error("Null Value: Item Name left blank.");
                    MainMenu.Start();
                }
                else
                {
                    TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                    item.ItemName = textInfo.ToTitleCase(itemName.ToLower());

                    item.ItemName = titleCaseItemName;
                }

                
                while (true)
                {
                    WriteLine("How much of the " + itemName + " do you have?");
                    string? userShuMinInput = ReadLine();

                    if (int.TryParse(userShuMinInput, out shuMinValue))
                    {
                        item.ItemAmount = shuMinValue;
                        break;
                    }
                    else
                    {
                        WriteLine("Amounts must be a number.");
                        Log.Error("Incorrect Input: Item Amounts must be an Integer.");
                    }
                }

                
                while (true)
                {
                    WriteLine("What is the minimum amount of " + itemName + " that you would like to keep in stock?");
                    string? userShuMaxInput = ReadLine();

                    if (int.TryParse(userShuMaxInput, out int shuMaxValue))
                    {
                        item.ItemPar = shuMaxValue;

                        try
                        {
                            await itemService.AddItemServiceAsync(item);
                            WriteLine($"You added {item.ItemName} to the database");
                            MainMenu.Start();
                        }
                        catch (ArgumentException ex)
                        {
                            WriteLine(ex.Message);
                            MainMenu.Start();
                        }
                    }
                    else
                    {
                        WriteLine("Invalid input. Please enter a number.");
                        Log.Error("Incorrect Input: Minimum Amounts must be an Integer.");
                    }
                }
            }
        }
    }
}
