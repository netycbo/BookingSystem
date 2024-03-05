using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.Components;
using BookingSystem.Components.CSV_Reader.Rooms;

namespace BookingSystem.DataProvider
{
    public class RoomProvider : IRoomProvider
    {
        private readonly IRepository<RoomBasic> _roomBasicRepository;
        private readonly ICsvReader _csvReader;
        public RoomProvider( ICsvReader csvReader)
        {
            //_roomBasicRepository = roomBasicRepository;
            _csvReader = csvReader;
        }
        public void ShowRoomsWithUpgrades()
        {
            var rooms = _csvReader.ReadCsv("Resource\\rooms_data.csv");

            var topRooms = rooms.Select(room => new
            {
                Room = room,
                TrueCount = Convert.ToInt32(room.Balcony) +
                            Convert.ToInt32(room.GymAccess) +
                            Convert.ToInt32(room.PoolAccess) +
                            Convert.ToInt32(room.Kettle) +
                            Convert.ToInt32(room.Tv) +
                            Convert.ToInt32(room.Tea_Coffe) +
                            Convert.ToInt32(room.GardenView) +
                            Convert.ToInt32(room.StreetView) +
                            Convert.ToInt32(room.Safe)
            })
            .OrderByDescending(x => x.TrueCount)
            .Take(3) 
            .ToList();

            foreach (var item in topRooms)
            {
                Console.WriteLine($"Room ID: {item.Room.Id}, Upgrades: {item.TrueCount}");
            }
        }
        public void ShowRoomsWithNiceView()
        {
            var rooms = _csvReader.ReadCsv("Resource\\rooms_data.csv");
            var roomsWithNiceView = rooms.Where(r => r.GardenView && r.Balcony)
                                          .Select(r => r.Id).ToList();
            if (roomsWithNiceView.Any())
            {
                Console.WriteLine($"Rooms with nice view and balcony: {string.Join(", ", roomsWithNiceView)}");
            }
            else
            {
                Console.WriteLine("There is no nice view in this hotel!.");
            }
        }

        public void ShowRooms()
        {
            var rooms = _csvReader.ReadCsv("Resource\\rooms_data.csv");

            Console.WriteLine("Rooms in use:");
            var roomsInUse = rooms.OrderBy(r => r.Id).ToList();
            foreach (var room in roomsInUse)
            {
                Console.WriteLine($"{room.ToString()}\n");
            }
        }
    }

}
