using Microsoft.EntityFrameworkCore;
using InventorySystem.DatabaseContext;
using InventorySystem.Entities;

namespace InventorySystem.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly InvContext _context;

        public ItemRepository()
        {
            _context = new InvContext();
        }

        public async Task<List<Item?>> GetAllItems()
        {
            var items = await _context.Items.ToListAsync();

            return items.OrderBy(i => i.ItemName).ToList();
        }

        public async Task<Item?> GetItemByName(string itemName)
        {
            return await _context.Items.FirstOrDefaultAsync(i => i.ItemName == itemName);
        }
                
        public async Task<Item?> GetItemById(Guid itemId)
        {
            return await _context.Items.FindAsync(itemId);
        }
              
    }
}
