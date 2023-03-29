using Microsoft.EntityFrameworkCore;
using InventorySystem.DatabaseContext;
using InventorySystem.Entities;

namespace InventorySystem.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly InventoryContext _context;

        public ItemRepository()
        {
            _context = new InventoryContext();
        }

        public async Task<List<Item>> GetAllItems()
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

        public async Task<List<Item>> GetLowItems()
        {
            using (var context = new InventoryContext())
            {
                var lowItems = await context.Items.FromSqlRaw(@"
                    SELECT * FROM Items WHERE ItemPar <= 5 AND ItemPar > 0;")
                    .ToListAsync();
                return lowItems.OrderBy(x => x.ItemName).ToList(); ;
            }
        }

        public async Task<List<Item>> GetEmptyItems()
        {
            using (var context = new InventoryContext())
            {
                var missingItems = await context.Items.FromSqlRaw(@"
                    SELECT * FROM Items WHERE ItemPar = 0;")
                    .ToListAsync();
                return missingItems.OrderBy(x => x.ItemName).ToList(); ;
            }
        }
        public async Task AddItem(Item addItem)
        {
            await _context.Items.AddAsync(addItem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateItem(Item updateItem)
        {
             
            var currentItem = await _context.Items.SingleOrDefaultAsync(i => i.ItemId == updateItem.ItemId);

            if (currentItem == null)
            {
                throw new ArgumentException("Item does not exist. Please check spelling or Inventory and try again. Thank You!");
            }

            _context.Update(currentItem);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteItem(Item deleteItem)
        {
            var deletedItem = await _context.Items.SingleOrDefaultAsync(i => i.ItemName == deleteItem.ItemName);

            if (deletedItem != null)
            {
                _context.Items.Remove(deletedItem);
                await _context.SaveChangesAsync();
            }
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
