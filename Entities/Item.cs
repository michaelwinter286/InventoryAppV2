using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities
{
    public class Item : IItem
    {
        public Guid ItemId { get; set; }
        public string? ItemName { get; set; }
        public int ItemAmount { get; set; }
        public int ItemPar { get; set; }
    }

   
}
