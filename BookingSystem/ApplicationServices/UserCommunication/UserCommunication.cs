using BookingSystem.ApplicationServices.DataProvider;
using BookingSystem.ApplicationServices.RoomManager;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;

namespace BookingSystem.ApplicationServices.UserCommunication
{
    public class UserCommunication : IUserCommunicacion
    {
        private readonly IRoomManager _roomManager;
        private readonly IRoomProvider _roomProvider;

        public UserCommunication(IRoomManager roomManager, IRoomProvider roomProvider)
        {
            _roomManager = roomManager;
            _roomProvider = roomProvider;
        }

        public void UserInterface()
        {
            var room = new RoomBasic();

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
                        room.NumberOfBeds = GetValueFromUser();
                        Console.WriteLine("Do you want to have a balcony? yes/no");
                        room.Balcony = GetUpgrades();
                        Console.WriteLine("Do you want to have Gym access? yes/no");
                        room.GymAccess = GetUpgrades();
                        Console.WriteLine("Do you want a pool access? yes/no");
                        room.PoolAccess = GetUpgrades();
                        Console.WriteLine("Do you want a safe in your room? yes/no");
                        room.Safe = GetUpgrades();
                        Console.WriteLine("Do you want to have a garden view? yes/no");
                        room.GardenView = GetUpgrades();


                        _roomManager.AddRoomBasic(room);
                        Console.WriteLine($"Current setup of your choice is: {room.ToString()}");
                        break;
                    case "2":
                        Console.WriteLine("Enter room ID: ");
                        int roomId = int.Parse(Console.ReadLine());
                        _roomManager.FindRoomToUpgrade(roomId);
                        _roomManager.UpdateRoomBasic();

                        break;
                    case "3":
                        _roomProvider.ShowRooms();
                        break;
                    case "4":
                        _roomManager.DeleteRoom(room.RoomId);
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

        public bool GetUpgrades()
        {
            while (true)
            {
                string input = Console.ReadLine().ToLower();
                if (input == "yes")
                {
                    return true;
                }
                else if (input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid input only yes or no:");
                }
            }
        }

        public int GetValueFromUser()
        {
            int value = 0;
            while (true)
            {
                Console.Write("You can choose maximum 6 beds per room. Enter number: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out value))
                {
                    if (value >= 1 && value <= 6)
                    {
                        return value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. The number must be between 1 and 6.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
        }
    }
}
