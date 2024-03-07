using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text;

namespace BookingSystem.Data.Entities
{
    public class RoomBasic : IInventoryBasic
    {
        
        
        private static int instanceCount = 0;
        public int Id { get; set; }
        public int NumberOfBeds { get; set; }
        public bool PrivateBathroom { get; set; } = true;
        public bool Balcony { get; set; } = false;
        public bool GymAccess { get; set; } = false;
        public bool PoolAccess { get; set; } = false;
        public bool Kettle { get; set; } = false;
        public bool Tv { get; set; } = true;
        public bool Tea_Coffe { get; set; } = true;
        public bool GardenView { get; set; } = false;
        public bool StreetView { get; set; } = false;
        public bool Safe { get; set; } = false;
        public int Price { get; set; } = 100;


        public RoomBasic()
        {
            instanceCount++;
            Id = instanceCount;
        }
        public static int Count
        {
            get { return instanceCount; }
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"    Room Number: {Id}    Number of beds: {NumberOfBeds}");
            sb.AppendLine($"    Private bathroom {(PrivateBathroom ? "yes" : "no")}  Balcony {(Balcony ? "yes" : "no")}");
            sb.AppendLine($"    Gym access {(GymAccess ? "yes" : "no")}  Pool access {(PoolAccess ? "yes" : "no")}");
            sb.AppendLine($"    Kettle {(Kettle ? "yes" : "no")}  Tv {(Tv ? "yes" : "no")}");
            sb.AppendLine($"    Tea/Coffe {(Tea_Coffe ? "yes" : "no")}  Garden view {(GardenView ? "yes" : "no")}    Street view {(StreetView ? "yes" : "no")}");

            return sb.ToString();
        }
    }
}


