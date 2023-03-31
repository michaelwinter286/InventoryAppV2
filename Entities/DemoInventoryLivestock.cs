
namespace InventorySystem.Entities
{
    public class DemoLivestock : Livestock
    {
        public static readonly Dictionary<string, Livestock> demoLivestock = new Dictionary<string, Livestock>
        {
            {"rambo", new Livestock
                { LivestockId = Guid.NewGuid(), LivestockName = "Rambo",  LivestockType = "Mentor Animal", LivestockBreed = "Black Angus", LivestockDob = "Unknown", LivestockDos = "n/a", LivestockComments = "Rambo is used to help rear new calves."}
            },

            {"gimpy", new Livestock
                { LivestockId = Guid.NewGuid(), LivestockName = "Gimpy", LivestockType = "Meat Steer", LivestockBreed = "Black Angus",  LivestockDob = "2019", LivestockDos = "TBD" }
            }
        };
    }
}
