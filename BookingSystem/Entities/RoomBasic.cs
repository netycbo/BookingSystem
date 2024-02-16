
namespace BookingSystem.Entities
{
    public class RoomBasic : IInventoryBasic
    {
        public int Id { get; set; }
        public int NumberOfBeds { get; set; }
        public bool PrivateBathroom { get; set; } = true;
        public bool Balcony { get; set; } = true;
        public bool GymAccess { get; set; } = true;
        public bool PoolAccess { get; set; } = true;
        public bool Kettle { get; set; } = true;
        public bool Tv { get; set; } = true;
        public bool Tea_Coffe { get; set; } = true;
        public bool GardenView { get; set; } = true;
        public bool StreetView { get; set; } = true;
        public bool Safe {  get; set; } = true;
        
        public override string ToString() => $"Room numer: {Id},\nNumber of beds {NumberOfBeds},\n" +
            $"Equipped with Tv: {Tv},\nEquipped with Tea/Coffe: {Tea_Coffe},\nHas a Garden View: {GardenView},\n" +
            $"Has a StreetView: {StreetView},\nHas a Balcony: {Balcony},\nEquipped with Kettle: {Kettle},\nHas a Private Bathroom: {PrivateBathroom},\n" +
            $"Has a Pool access: {PoolAccess},\nEquipped with Safe: {Safe}. ";
    }
}


