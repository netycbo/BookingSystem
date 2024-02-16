using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Entities
{
    public interface IInventoryPremium
    {
        public bool Balcony { get; set; }
        public bool GymAccess { get; set; }
        public bool PoolAccess { get; set; }
        public bool GardenView { get; set; }
        public bool Safe { get; set; }
    }
}
