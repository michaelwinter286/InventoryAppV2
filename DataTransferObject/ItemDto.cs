using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace InventorySystem.DataTransferObject
{
    public class ItemDto
    {
        public Guid ItemId { get; set; }
        public string? ItemName { get; set; }
        public int ItemAmount { get; set; }
        public int ItemPar { get; set; }
    }

    public class ItemRequestDto
    {
        [JsonIgnore] public Guid ItemId { get; set; }
        public string? ItemName { get; set; }
        public int ItemAmount { get; set; }
        public int ItemPar { get; set; }
    }
}
