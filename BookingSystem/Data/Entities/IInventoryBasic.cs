namespace BookingSystem.Data.Entities
{
    public interface IInventoryBasic
    {
        public int Id { get; set; }
        public int NumberOfBeds { get; set; }
        public bool PrivateBathroom { get; set; }
        public bool Kettle { get; set; }
        public bool Tv { get; set; }
        public bool Tea_Coffe { get; set; }
        public bool StreetView { get; set; }

    }
}
