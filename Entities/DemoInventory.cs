using System;


namespace InventorySystem.Entities
{
    public class DemoInventory : Item
    {
        public static readonly Dictionary<string, Item> demoInventory = new Dictionary<string, Item>
        {
            {"hay", new Item
                { ItemId = Guid.NewGuid(), ItemName = "Hay",  ItemAmt = 6, ItemPar = 10 } 
            },

            { "dieselfuel", new Item
                { ItemId = Guid.NewGuid(), ItemName = "Diesel Fuel", ItemAmt = 25, ItemPar = 10}
            },

            {"unleadedfuel", new Item
                { ItemId = Guid.NewGuid(), ItemName = "Unleaded Fuel", ItemAmt = 12, ItemPar = 10 }
            },
        };
            
    };
}
