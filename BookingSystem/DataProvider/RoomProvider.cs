using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.Components;

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

        public void ShowRooms()
        {
            var rooms = _csvReader.ReadCsv("Resource\\rooms_data.csv");

            Console.WriteLine("Rooms in use:");
            foreach (var room in rooms)
            {
                Console.WriteLine($"{room.ToString()} \n");
            }
        }
    }

}
