using InventorySystem.Entities;

namespace InventorySystem.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItems();
        Task<List<Item>> GetEmptyItems();
        Task<List<Item>> GetLowItems();
        Task<Item?> GetItemById(Guid itemId);
        Task<Item?> GetItemByName(string itemName);
        Task AddItem(Item addItem);
        Task UpdateItem(Item updateItem);
        Task DeleteItem(Item deleteItem);
        void Dispose();
        
    };

   







}
