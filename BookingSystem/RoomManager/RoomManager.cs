using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using System.Formats.Asn1;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace BookingSystem
{
    public class RoomManager : IRoomManager
    {
        private readonly IRepository<RoomBasic> _roomBasicRepository;
        private readonly ICsvReader _csvReader;

        public RoomManager( ICsvReader csvReader)
        {
            _csvReader = csvReader;
            //_roomBasicRepository = room;
            //if (room != null)
            //{
            //    room.RoomAdded += NewBookingRoomAdded;
            //    room.RoomRemoved += NewBookingRoomRemoved;
            // }
        }
        public void ExportToXml()
        {
            var records = _csvReader.ReadRoomData("Resource\\rooms_data.csv");

            var document = new XDocument();
            var rooms = new XElement("Rooms", records.Select(
                x => new XElement("Room",
                    new XAttribute("Id", x.Id),
                    new XAttribute("NumberOfBeds", x.NumberOfBeds),
                    new XAttribute("PrivateBathroom", x.PrivateBathroom),
                    new XAttribute("Balcony", x.Balcony),
                    new XAttribute("GymAccess", x.GymAccess),
                    new XAttribute("PoolAccess", x.PoolAccess),
                    new XAttribute("Kettle", x.Kettle),
                    new XAttribute("Tv", x.Tv),
                    new XAttribute("TeaCoffe", x.Tea_Coffe),
                    new XAttribute("GardenView", x.GardenView),
                    new XAttribute("StreetView", x.StreetView),
                    new XAttribute("Safe", x.Safe))));
            document.Add(rooms);
            document.Save("Rooms.xml");
            Console.WriteLine("Rooms.xml created successfully.");
        }

        public void AddRoomBasic(IRepository<RoomBasic> repository, RoomBasic room)
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
                writer.WriteLine($"[{dateTime}]-RoomAdded-[{room.Id} and was: ");
            }
        }

        public void NewBookingRoomRemoved(object? sender, RoomBasic room)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"room number {room.Id} has bean removed");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-RoomRemoved-[{room.Id} and was: ");
            }
        }
    }
}
