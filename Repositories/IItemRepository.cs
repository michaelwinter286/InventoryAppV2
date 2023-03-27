using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Repositories
{
    public interface IItemRepository
    {
        Task<List<Item?>> GetAllItemsAsync();
    }
}
