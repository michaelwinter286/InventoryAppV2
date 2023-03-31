using System;


namespace InventorySystem.Entities
{
    public interface IItem
    {
        Guid ItemId { get; set; }
        string? ItemName { get; set; }
        public int ItemAmount { get; set; }
        public int ItemPar { get; set; }
    }
}
