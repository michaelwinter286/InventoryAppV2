using InventorySystem.Entities;
using InventorySystem.Services;
using System.Globalization;
using Serilog;
using static System.Console;


namespace InventorySystem.Actions
{
    public class EditItem
    {
        public static async Task UpdateItem(ItemService itemService)
        {
            Clear();

            WriteLine("Which Item would you like to update?");

            var updateItem = new Item();

            string? itemName = ReadLine();

            if (string.IsNullOrEmpty(itemName))
            {
                WriteLine("Item Name cannot be blank.");
                Log.Error("Unable to Update: Item Name cannot be Null.");
                MainMenu.Start();
            }

            // Convert input string to Title case
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            updateItem.ItemName = textInfo.ToTitleCase(itemName!.ToLower());

            try
            {
                var currentItem = await itemService.GetItemByNameService(updateItem.ItemName!);

                if (currentItem == null)
                {
                    WriteLine($"Sorry item was not found in inventory please check spelling and current inventory stock.");
                    Log.Error($"Unable to Update: Item Not Found.");
                    MainMenu.Start();
                }
                
                WriteLine($"Item was updated '{updateItem.ItemName}':");

                // Update Item Name
                WriteLine($"Current name: {currentItem.ItemName}");
                WriteLine("Enter new name (or leave blank to keep current name):");
                string? newName = ReadLine();
                if (!string.IsNullOrEmpty(newName))
                {
                    string? titleCaseNewItemName;

                    
                    TextInfo textInfo2 = new CultureInfo("en-US", false).TextInfo;
                    titleCaseNewItemName = textInfo2.ToTitleCase(newName.ToLower());

                    currentItem.ItemName = titleCaseNewItemName;
                }

                //Update Item Amount
                WriteLine($"Current item amount: {currentItem.ItemAmount}");
                while (true)
                {
                    WriteLine("Enter new then new amount or leave blank if amount is staying the same.");
                    string? userShuMinInput = ReadLine();

                    if (string.IsNullOrEmpty(userShuMinInput))
                    {
                        break;
                    }
                    else if (int.TryParse(userShuMinInput, out int shuMinValue))
                    {
                        currentItem.ItemAmount = shuMinValue;
                        break;
                    }
                    else
                    {
                        WriteLine("Unable to update. Item Amount must be a number.");
                        Log.Error("Unable to update. Item Amount must be an integer.");
                    }
                }

                //Updating Item's Par Level for Minimum Stocking.
                WriteLine($"Current Minimum Allowed: {currentItem.ItemPar}");
                while (true)
                {
                    WriteLine("Enter the new minimum allowed or leave blank if staying the same.");
                    string? userShuMaxInput = ReadLine();

                    if (string.IsNullOrEmpty(userShuMaxInput))
                    {
                        break;
                    }
                    else if (int.TryParse(userShuMaxInput, out int shuMaxValue))
                    {
                        currentItem.ItemPar = shuMaxValue;
                        break;
                    }
                    else
                    {
                        WriteLine("The minimum allowed for stocking must be a number.");
                        Log.Error("Unable to update. Item Amount must be an integer.");
                    }
                }

                await itemService.UpdateItemService(currentItem);
                WriteLine($"You updated '{currentItem.ItemName}'within your current inventory.");
                MainMenu.Start();
            }
            catch (ArgumentException ex)
            {
                WriteLine(ex.Message);
                MainMenu.Start();
            }
            catch (InvalidOperationException ex)
            {
                WriteLine(ex.Message);
                MainMenu.Start();
            }
        }
    }
}

