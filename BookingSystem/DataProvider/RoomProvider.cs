using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem.DataProvider
{
    public class RoomProvider : IRoomProvider
    {
        private readonly IRepository<RoomBasic> _roomBasicRepository;
        public RoomProvider(IRepository<RoomBasic> roomBasicRepository)
        {
            _roomBasicRepository = roomBasicRepository;
        }

        public void ShowRooms()
        {
            var rooms = _roomBasicRepository.GetAll().OrderBy(x => x.Id).ToList();

            Console.WriteLine("Rooms in use:");
            foreach (var room in rooms)
            {
                Console.WriteLine($"{room.ToString()} \n");
            }
        }
    }

}
