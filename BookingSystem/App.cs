using BookingSystem.DataProvider;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data;

namespace BookingSystem
{
    public class App : IApp
    {
        private readonly BookingSystemContext _bookingSystemcontext;
        private readonly ICsvReader _csvReader;
        
        public App(BookingSystemContext bookingSystemcontext, ICsvReader csvReader)
        {
            //_roomBasicRepository = roomBasicRepository;
            _csvReader = csvReader;
            _bookingSystemcontext = bookingSystemcontext;
            _bookingSystemcontext.Database.EnsureCreated();
        }

        public void Run()
        {
                var rooms = _csvReader.ReadRoomData("Resource\\rooms_data.csv");
                foreach (var room in rooms)
                {
                    _bookingSystemcontext.Rooms.Add(new RoomBasic()
                    {
                        
                        NumberOfBeds = room.NumberOfBeds,
                        PrivateBathroom = room.PrivateBathroom,
                        Balcony = room.Balcony,
                        GymAccess = room.GymAccess,
                        PoolAccess = room.PoolAccess,
                        Kettle = room.Kettle,
                        Tv = room.Tv,
                        Tea_Coffe = room.Tea_Coffe,
                        GardenView = room.GardenView,
                        StreetView = room.StreetView,
                        Safe = room.Safe,
                        Price = room.Price
                    });
                }
               
                var records = _csvReader.ReadRestaurantInfo("Resource\\restaurant_data.csv");
                foreach (var restaurant in records)
                {
                    _bookingSystemcontext.Restaurant.Add(new Restaurant()
                    {
                       
                        Price = restaurant.Price,
                        Breakfast = restaurant.Breakfast,
                        BreakfastDescription = restaurant.BreakfastDescription,
                        Brunch = restaurant.Brunch,
                        BrunchDescription = restaurant.BrunchDescription,
                        Dinner = restaurant.Dinner,
                        DinnerDescription = restaurant.DinnerDescription
                    });
                }
                _bookingSystemcontext.SaveChanges();
            
        }
    }
    
}
