using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using System.Formats.Asn1;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace BookingSystem.RoomManagment
{
    public class RoomManager : IRoomManager
    {
        private readonly IRepository<RoomBasic> _roomBasicRepository;


        public RoomManager(IRepository<RoomBasic> room)
        {
            _roomBasicRepository = room;
        }

        public void AddRoomBasic(RoomBasic room)
        {
            _roomBasicRepository.Add(room);
            _roomBasicRepository.Save();
        }

        public void UpdateRoomBasic()
        {
            _roomBasicRepository.Update();
        }

        public void FindRoomToUpgrade(int roomId)
        {
            var roomToUpgrade = _roomBasicRepository.GetAll().FirstOrDefault(room => room.RoomId == roomId);
            if (roomToUpgrade != null)
            {
                Console.WriteLine($"Room with ID: {roomId} has the following details needing upgrade:");

                var propertiesToUpgrade = roomToUpgrade.GetType().GetProperties()
                    .Where(prop => prop.PropertyType == typeof(bool) && (bool)prop.GetValue(roomToUpgrade) == false)
                    .ToList();

                if (propertiesToUpgrade.Count > 0)
                {
                    int optionNumber = 1;
                    foreach (var property in propertiesToUpgrade)
                    {
                        Console.WriteLine($"{optionNumber}. {property.Name}");
                        optionNumber++;
                    }

                    string userChoice;
                    do
                    {
                        Console.WriteLine("Enter the number of the feature you want to upgrade or press E to exit:");
                        userChoice = Console.ReadLine();

                        if (userChoice.ToUpper() == "E")
                        {
                            break;
                        }

                        int choice;
                        if (int.TryParse(userChoice, out choice) && choice >= 1 && choice <= propertiesToUpgrade.Count)
                        {
                            var selectedProperty = propertiesToUpgrade[choice - 1];
                            selectedProperty.SetValue(roomToUpgrade, true);
                            Console.WriteLine($"{selectedProperty.Name} has been upgraded.");

                            propertiesToUpgrade = roomToUpgrade.GetType().GetProperties()
                                .Where(prop => prop.PropertyType == typeof(bool) && (bool)prop.GetValue(roomToUpgrade) == false)
                                .ToList();
                            optionNumber = 1;
                            foreach (var property in propertiesToUpgrade)
                            {
                                Console.WriteLine($"{optionNumber}. {property.Name}");
                                optionNumber++;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                        }
                    } while (userChoice.ToUpper() != "E");
                }
                else
                {
                    Console.WriteLine("No upgrades needed or applicable for this room.");
                }
            }
            else
            {
                Console.WriteLine($"Room with ID: {roomId} was not found.");
            }
        }
        public void DeleteRoom(int roomId)
        {
            Console.WriteLine("Room number to delete:");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int Id))
            {
                var roomToDelete = _roomBasicRepository.GetAll().FirstOrDefault(room => room.RoomId == Id);
                if (roomToDelete != null)
                {
                    _roomBasicRepository.Remove(roomToDelete);
                    _roomBasicRepository.Save();
                    Console.WriteLine($"Room with ID: {Id} has been deleted.");
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
            Console.WriteLine($"room number {room.RoomId} has bean added");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-RoomAdded-[{room.RoomId} and was: ");
            }
        }

        public void NewBookingRoomRemoved(object? sender, RoomBasic room)
        {
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"room number {room.RoomId} has bean removed");
            using (var writer = File.AppendText("logs.txt"))
            {
                writer.WriteLine($"[{dateTime}]-RoomRemoved-[{room.RoomId} and was: ");
            }
        }
    }
}
