namespace BookingSystem.Entities
{
    public class RoomPremium :RoomBasic, IInventoryPremium, IInventoryBasic
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
        public bool Safe { get; set; } = true;


        public override string ToString() => base.ToString() + "(This is Room Premium)";
    }
}