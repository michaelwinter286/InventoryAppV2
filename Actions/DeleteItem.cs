using Serilog;
using static System.Console;
using InventorySystem.Services;





namespace InventorySystem.Actions
{
    public class ItemDelete
    {

        //    public static async Task DeleteItem(ItemService itemService)
        //    {
        //        Clear();

        //        WriteLine("Which Item needs to be removed from Inventory?");
        //        //string? itemName = ReadLine();

        //        var itemName = ReadLine();

        //        if (string.IsNullOrEmpty(itemName))
        //        {
        //            WriteLine("Item name cannot be blank.");
        //            Log.Error("Delete Failed: Item name cannot be null.");
        //            MainMenu.Start();
        //        }
        //        else
        //        {

        //            try
        //            {
        //                var updateItem = await itemService.GetItemByNameServiceAsync(itemName);

        //                await itemService.DeleteItemServiceAsync(updateItem!);
        //                WriteLine($"{itemName} has been removed from Inventory.");
        //                MainMenu.Start();
        //            }
        //            catch (ArgumentException ex)
        //            {
        //                WriteLine(ex.Message);
        //                MainMenu.Start();
        //            }
        //            catch (InvalidOperationException ex)
        //            {
        //                WriteLine(ex.Message);
        //                MainMenu.Start();
        //            }
        //        }
        //    }
    }
}
