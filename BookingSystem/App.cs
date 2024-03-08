using BookingSystem.DataProvider;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.Components.CSV_Reader;
using BookingSystem.Data;

using BookingSystem.RoomManagment;

namespace BookingSystem
{
    public class App : IApp
    {
       
        private readonly BookingSystemContext _bookingSystemcontext;
        private readonly ICsvReader _csvReader;
        private readonly IRepository<RoomBasic> _roomRepository;

        public App(BookingSystemContext bookingSystemcontext, IRepository<RoomBasic> roomBasicRepository)
        {
            
            _roomRepository = roomBasicRepository;
            _bookingSystemcontext = bookingSystemcontext;
            _bookingSystemcontext.Database.EnsureCreated();
        }

        public void Run()
        {
            var room = new RoomBasic();
            var roomManager = new RoomManager(_roomRepository);
            var userCommunication = new UserCommunication();
            var roomProvider = new RoomProvider(_roomRepository);


            bool closeApp = false;
            while (!closeApp)
            {
                Console.WriteLine("1 - Add new room\n" +
                                  "2 - Add upgrades to existing room\n" +
                                  "3 - Rooms overview\n" +
                                  "4 - Delete room\n" +
                                  "X - Close app\n");

                Console.Write("What do you want to do? Press key 1, 2, 3, 4, or X: ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Here you can customize your room.");
                    
                        Console.WriteLine("How many beds do you need?:");
                        room.NumberOfBeds = userCommunication.GetValueFromUser();
                        Console.WriteLine("Do you want to have a balcony? yes/no");
                        room.Balcony = userCommunication.GetUpgrades();
                        Console.WriteLine("Do you want to have Gym access? yes/no");
                        room.GymAccess = userCommunication.GetUpgrades();
                        Console.WriteLine("Do you want a pool access? yes/no");
                        room.PoolAccess = userCommunication.GetUpgrades();
                        Console.WriteLine("Do you want a safe in your room? yes/no");
                        room.Safe = userCommunication.GetUpgrades();
                        Console.WriteLine("Do you want to have a garden view? yes/no");
                        room.GardenView = userCommunication.GetUpgrades();
                        Console.WriteLine($"Current setup of your choice is: {room.ToString()}");

                        roomManager.AddRoomBasic(room);
                        break;
                    case "2":
                        Console.WriteLine("Enter room ID: ");
                        int roomId = int.Parse(Console.ReadLine());
                        roomManager.FindRoomToUpgrade(roomId);
                        roomManager.UpdateRoomBasic();
                        
                        break;
                    case "3":
                        roomProvider.ShowRooms();
                        break;
                    case "4":
                        roomManager.DeleteRoom(room.RoomId);
                        break;
                    case "X":
                        closeApp = true;
                        break;
                    default:
                        Console.WriteLine("Invalid operation.\n");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu.");
                Console.ReadKey();
                Console.Clear();
            }
        }

            private void insertData()
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

                    });
                }

                _bookingSystemcontext.SaveChanges();
            }
        
    }
}
    

