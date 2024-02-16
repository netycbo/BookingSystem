using BookingSystem.Data;
using BookingSystem.Entities;
using BookingSystem.Repositories;

var newBooking = new SqlRepository<RoomBasic>(new BookingSystemDb());
AddBooking(newBooking);
AddPremiumBooking(newBooking);
ShowInConsole(newBooking);
static void AddPremiumBooking(IWritetRepository<RoomPremium> repository)
{
    repository.Add(new RoomPremium { Id = 4 });
    repository.Save();
}
static void AddBooking(IRepository<RoomBasic> repository)
{
    repository.Add(new RoomBasic
    {
        Id = 7,
        NumberOfBeds = 6,
        Balcony = true,
        GymAccess = true,
        PoolAccess = true,
        GardenView = true,
        Kettle = true,
        PrivateBathroom = true,
        Safe = false,
        StreetView = false,
        Tea_Coffe = true,
        Tv = true

    });
    repository.Add(new RoomBasic
    {
        Id = 1,
        NumberOfBeds = 3,
        Balcony = false,
        GymAccess = false,
        PoolAccess = false,
        GardenView = false,
        Kettle = true,
        PrivateBathroom = false,
        Safe = false,
        StreetView = false,
        Tea_Coffe = true,
        Tv = true
    });
    repository.Save();

}
static void ShowInConsole(IReadRepository<IInventoryBasic> bookings)
{
    var items = bookings.GetAll();
    foreach (var item in items)
    {
        Console.WriteLine(item +"\n");
    }
}