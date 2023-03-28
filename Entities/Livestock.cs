using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Entities
{
    public class Livestock
    {
       
            public Guid AnimalId { get; set; }
            public string? AnimalTag { get; set; }
            public string? AnimalName { get; set; }
            public string? AnimalType { get; set; }
            public string? AnimalBreed { get; set; }
            public string? AnimalDob { get; set; }
            public string? AnimalDos { get; set; }
        
    }
}
