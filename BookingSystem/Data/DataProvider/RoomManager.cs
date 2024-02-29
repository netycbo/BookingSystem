using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem.Data.DataProvider
{
    public class RoomManager : IRoomManager
    {
        private readonly RepositoryInFile<RoomBasic> _room;
        private readonly IRepository<RoomBasic> _roomBasicRepository;
        
        public RoomManager(IRepository<RoomBasic> room)
        {
            _roomBasicRepository = room;
          //  _room.RoomAdded += NewBookingRoomAdded;
          //  _room.RoomRemoved += NewBookingRoomRemoved;
        }

        public void AddRoomBasic(IRepository<RoomBasic> repository, RoomBasic room)
        {
            repository.Add(room);
            repository.Save();
        }

        public void AddRoomPremium(IWritetRepository<RoomPremium> repository, RoomPremium room)
        {
            repository.Add(room);
            repository.Save();
        }

        public void DeleteRoom(IRepository<RoomBasic> repository)
        {
            Console.WriteLine("Room number to delete:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int roomId))
            {
                var roomToDelete = repository.GetAll().FirstOrDefault(room => room.Id == roomId);
                if (roomToDelete != null)
                {
                    repository.Remove(roomToDelete);
                    repository.Save();
                    Console.WriteLine($"Room with ID: {roomId} has been deleted.");
                }
                else
                {
                    Console.WriteLine($"Room with ID: {roomId} not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid room ID.");
            }
        }

        public void NewBookingRoomAdded(object? sender, RoomBasic room)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"room number {room.Id} has bean added");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-RoomAdded-[{room.Id} and was: {(room.IsBasic ? "Premium" : "Basic")}]");
            }
        }

        public void NewBookingRoomRemoved(object? sender, RoomBasic room)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"room number {room.Id} has bean removed");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-RoomAdded-[{room.Id} and was: {(room.IsBasic ? "Premium" : "Basic")}]");
            }
        }
    }
}
