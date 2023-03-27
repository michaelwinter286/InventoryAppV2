using System;
using InventorySystem.DatabaseContext;
using InventorySystem.DataTransferObject;
using Microsoft.EntityFrameworkCore;

namespace InventorySystem.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly InvContext _context;

        public ItemRepository()
        {
            _context = new InvContext();
        }

        public async Task<List<Item?>> GetAllItemsAsync()
        {
            var items = await _context.Items.ToListAsync();

            return items.OrderBy(x => x.ItemName).ToList();
        }

        public async Task<List<Item?>> GetItemsByNameAsync(string itemName)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.ItemName == itemName);
        }

        public async Task<List<Item?>> 
    }
}
