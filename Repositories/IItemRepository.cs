using InventorySystem.Entities;

namespace InventorySystem.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item?>> GetAllItems();
        Task<Item?> GetItemById(Guid itemId);
        Task<Item?> GetItemByName(string itemName);
    };

   







}
