using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookingSystem.Data.Entities
{
    public class RoomBasic : IInventoryBasic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
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
        
        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"    Room Number: {RoomId} Number of beds: {NumberOfBeds}");
            sb.AppendLine($"    Private bathroom {(PrivateBathroom ? "yes" : "no")}  Balcony {(Balcony ? "yes" : "no")}");
            sb.AppendLine($"    Gym access {(GymAccess ? "yes" : "no")}  Pool access {(PoolAccess ? "yes" : "no")}");
            sb.AppendLine($"    Kettle {(Kettle ? "yes" : "no")}  Tv {(Tv ? "yes" : "no")}");
            sb.AppendLine($"    Tea/Coffe {(Tea_Coffe ? "yes" : "no")}  Garden view {(GardenView ? "yes" : "no")}    Street view {(StreetView ? "yes" : "no")}");

            return sb.ToString();
        }
    }
}


