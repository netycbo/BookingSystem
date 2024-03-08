using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.Components;
using BookingSystem.Components.CSV_Reader.Rooms;
using Microsoft.EntityFrameworkCore;
using BookingSystem.Data;

namespace BookingSystem.DataProvider
{
    public  class RoomProvider : IRoomProvider
    {
       
        private readonly IRepository<RoomBasic> _roomRepository;
        private readonly ICsvReader _csvReader;

        public RoomProvider(IRepository<RoomBasic> roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public void ShowRooms()
        {
            var rooms = _roomRepository.GetAll();

            Console.WriteLine("Rooms in use:");
            var roomsInUse = rooms.OrderByDescending(r => r.Balcony).ToList();
            foreach (var room in roomsInUse)
            {
                Console.WriteLine($"{room.ToString()}\n");
            }
        }
    }

}
