using InventorySystem.Entities;
using InventorySystem.DataTransferObject;

namespace InventorySystem.Services
{
    public interface IItemService
    {
        Task<List<Item>> GetAllItemsServiceAsync();
        //Task<List<Item>> GetEmptyItemsAsync();
        //Task<List<Item>> GetLowItemsAsync();
        //Task<Item?> GetItemByIdAsync(Guid itemId);
        Task<Item?> GetItemByNameServiceAsync(string itemName);
        Task AddItemServiceAsync(ItemDto itemDto);
        Task UpdateItemServiceAsync(ItemDto itemDto);
        Task DeleteItemServiceAsync(ItemDto deleteItem);
    }
}
