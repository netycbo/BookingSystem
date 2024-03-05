using BookingSystem.DataProvider;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using BookingSystem.Components.CSV_Reader;

namespace BookingSystem
{
    public class App : IApp
    {
        private readonly IRepository<RoomBasic> _roomBasicRepository;
        private readonly ICsvReader _csvReader;
        
        public App(IRepository<RoomBasic> roomBasicRepository, ICsvReader csvReader)
        {
            _roomBasicRepository = roomBasicRepository;
            _csvReader = csvReader;
        }

        public void Run()
        {
            var newBooking = new CsvReader();
            var roomManager = new RoomManager(newBooking);
            var userCommunication = new UserCommunication();
            var roomProvider = new RoomProvider(_csvReader);



            bool closeApp = false;
            while (!closeApp)
            {
                Console.WriteLine("1 - Rooms with most uppgrades\n" +
                                  "2 - Find rooms with nice view\n" +
                                  "3 - Rooms overview\n" +
                                  "4 - Export everything to Xml\n" +
                                  "X - Close app\n");

                Console.Write("What do you want to do? Press key 1, 2, 3, 4, or X: ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        roomProvider.ShowRoomsWithUpgrades();
                        break;
                    case "2":
                       roomProvider.ShowRoomsWithNiceView();
                        break;
                    case "3":
                        roomProvider.ShowRooms(); 
                        break;
                    case "4":
                        roomManager.ExportToXml() ;
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
    }
    
}
