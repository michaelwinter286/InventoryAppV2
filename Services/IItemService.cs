using InventorySystem.Entities;

namespace InventorySystem.Services
{
    public interface IItemService
    {
        //Task<List<Item>> GetAllItems();
        //Task<List<Item>> GetEmptyItems();
        //Task<List<Item>> GetLowItems();
        //Task<Item?> GetItemById(Guid itemId);
        Task<Item?> GetItemByNameService(string itemName);
        Task AddItemService(Item addItem);
        Task UpdateItemService(Item updateItem);
        Task DeleteItemService(Item deleteItem);
    }
}
