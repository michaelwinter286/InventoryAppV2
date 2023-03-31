using Serilog;
using System.Globalization;
using static System.Console;
using InventorySystem.Entities;
using InventorySystem.Services;



namespace InventorySystem.Actions
{
    public class ItemDelete
    {
        
        public static async Task DeleteItem(ItemService itemService)
        {
            Clear();

            WriteLine("Which Item needs to be removed from Inventory?");
            string? itemName = ReadLine();

            if (string.IsNullOrEmpty(itemName))
            {
                WriteLine("Item name cannot be blank.");
                Log.Error("Delete Failed: Item name cannot be null.");
                MainMenu.Start();
            }
            else
            {
                TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                string titleCaseItemName = textInfo.ToTitleCase(itemName.ToLower());

                var deleteItem = new Item
                {
                    ItemName = titleCaseItemName
                };
               
                try
                {
                    await itemService.DeleteItemServiceAsync(deleteItem);
                    WriteLine($"{deleteItem.ItemName} has been removed from Inventory.");
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
}
