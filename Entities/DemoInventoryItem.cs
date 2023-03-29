using System;


namespace InventorySystem.Entities
{
    public class DemoItem : Item
    {
        public static readonly Dictionary<string, Item> demoItem = new Dictionary<string, Item>
        {
            {"hay", new Item
                { ItemId = Guid.NewGuid(), ItemName = "Hay",  ItemAmount = 6, ItemPar = 10 } 
            },

            { "dieselfuel", new Item
                { ItemId = Guid.NewGuid(), ItemName = "Diesel Fuel", ItemAmount = 25, ItemPar = 10}
            },

            {"unleadedfuel", new Item
                { ItemId = Guid.NewGuid(), ItemName = "Unleaded Fuel", ItemAmount = 12, ItemPar = 10 }
            },
        };
            
    };

}
