﻿using BookingSystem.DataProvider;
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
            var newBooking = new RepositoryInFile<RoomBasic>();
            var roomManager = new RoomManager(newBooking);
            var userCommunication = new UserCommunication();
            var roomProvider = new RoomProvider(_csvReader);



            bool closeApp = false;
            while (!closeApp)
            {
                Console.WriteLine("1 - Add Basic room and choose upgrades\n" +
                                  "2 - Add Premium room\n" +
                                  "3 - Room overview\n" +
                                  "4 - Delete room\n" +
                                  "X - Close app\n");

                Console.Write("What do you want to do? Press key 1, 2, 3, 4, or X: ");
                var userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "1":
                        Console.WriteLine("Here you can customize your room.");
                        RoomBasic newRoom = new RoomBasic();
                        Console.WriteLine("How many beds do you need?:");
                        newRoom.NumberOfBeds = userCommunication.GetValueFromUser();
                        Console.WriteLine("Do you want to have a balcony? yes/no");
                        newRoom.Balcony = userCommunication.GetUpgrades();
                        Console.WriteLine("Do you want to have Gym access? yes/no");
                        newRoom.GymAccess = userCommunication.GetUpgrades();
                        Console.WriteLine("Do you want a pool access? yes/no");
                        newRoom.PoolAccess = userCommunication.GetUpgrades();
                        Console.WriteLine("Do you want a safe in your room? yes/no");
                        newRoom.Safe = userCommunication.GetUpgrades();
                        Console.WriteLine("Do you want to have a garden view? yes/no");
                        newRoom.GardenView = userCommunication.GetUpgrades();
                        Console.WriteLine($"Current setup of your choice is: {newRoom.ToString()}");

                        roomManager.AddRoomBasic(newBooking, newRoom);
                        break;
                    case "2":
                        RoomPremium newRoomPremium = new RoomPremium();
                        Console.WriteLine("How many beds do you need?:");
                        newRoomPremium.NumberOfBeds = userCommunication.GetValueFromUser();
                        roomManager.AddRoomPremium(newBooking, newRoomPremium);
                        break;
                    case "3":
                        roomProvider.ShowRooms(); 
                        break;
                    case "4":
                        roomManager.DeleteRoom(newBooking);
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
