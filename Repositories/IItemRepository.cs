using InventorySystem.Entities;

namespace InventorySystem.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItemsAsync();
        //Task<List<Item>> GetEmptyItemsAsync();
        Task<List<Item>> GetLowItemsAsync();
        Task<Item?> GetItemByIdAsync(Guid itemId);
        Task<Item?> GetItemByNameAsync(string itemName);
        Task AddItemAsync(Item addItem);
        Task UpdateItemAsync(Item updateItem);
        Task DeleteItemAsync(Item deleteItem);
        void Dispose();
        
    };

   







}
