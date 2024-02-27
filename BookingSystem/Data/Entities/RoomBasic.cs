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
        public bool IsBasic { get; set; } = true;

        public RoomBasic()
            {
            instanceCount++;
                Id = instanceCount;
            }
        public static int Count
        {
            get { return instanceCount; }
        }

        public override string ToString() => $"Room numer: {Id},\nNumber of beds {NumberOfBeds},\n" +
            $"Equipped with Tv: {(Tv ? "yes": "no")},\nEquipped with Tea/Coffe: {(Tea_Coffe ? "yes":"no")},\nHas a Garden View: {(GardenView ? "yes" : "no")},\n" +
            $"Has a StreetView: {(StreetView ? "yes" : "no")},\nHas a Balcony: {(Balcony ? "yes" : "no")},\nEquipped with Kettle: {(Kettle ? "yes" : "no")},\nHas a Private Bathroom: {(PrivateBathroom ? "yes" : "no")},\n" +
            $"Has a Pool access: {(PoolAccess ? "yes" : "no")},\nEquipped with Safe: {(Safe ? "yes" : "no")},\n Room type {(IsBasic ? "Basic" : "Premium")}.";
    }
}


