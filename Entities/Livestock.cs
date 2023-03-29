using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities
{
    public class Livestock : ILivestock
    {
       
        public Guid LivestockId { get; set; }
        public string? LivestockTag { get; set; }
        public string? LivestockName { get; set; }
        public string? LivestockType { get; set; }
        public string? LivestockBreed { get; set; }
        public string? LivestockDob { get; set; }
        public string? LivestockDos { get; set; }
        public string? LivestockComments { get; set; }
        
    }
}
