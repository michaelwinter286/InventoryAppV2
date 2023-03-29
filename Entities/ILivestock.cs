using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities
{
    public interface ILivestock
    {
        Guid LivestockId { get; set; }
        string? LivestockName { get; set; }
        string? LivestockTag { get; set; }
        
    }
}
