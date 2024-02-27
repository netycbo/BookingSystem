using BookingSystem.Data;
using BookingSystem.Data.Entities;
using BookingSystem.Data.Repositories;
using System;
using System.Linq.Expressions;

public class Program
{

    private static void Main(string[] args)
    {
        var newBooking = new RepositoryInFile<RoomBasic>();
        newBooking.RoomAdded += NewBookingRoomAdded;
        newBooking.RoomRemoved += NewBookingRoomRemoved;

        bool CloseApp = false;
        while (!CloseApp)
        {
            Console.WriteLine("1 - Add Basic room and choos uppgrades\n" +
                              "2 - Add Premium room\n" +
                              "3 - Room overview\n" +
                              "4 - Delete room\n" +
                              "X - Close app\n");

            Console.WriteLine("What do you want to do? Press key 1, 2, 3, 4 or X: ");
            var userInput = Console.ReadLine().ToUpper();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Here you can customize your room.");
                    RoomBasic newRoom = new RoomBasic();
                    Console.WriteLine("How many beds do you need?:");
                    newRoom.NumberOfBeds = GetValueFromUser();
                    Console.WriteLine("Do you want to have a balcony? yes/no");
                    newRoom.Balcony = GetUpgrades();
                    Console.WriteLine("Do you want to have Gym access? yes/no");
                    newRoom.GymAccess = GetUpgrades();
                    Console.WriteLine("Do you want a pool access? yes/no");
                    newRoom.PoolAccess = GetUpgrades();
                    Console.WriteLine("Do you want a safe in your room? yes/no");
                    newRoom.Safe = GetUpgrades();
                    Console.WriteLine("Do you want to have a garden view? yes/no");
                    newRoom.GardenView = GetUpgrades();
                    Console.WriteLine($"Current setup of your choice is: {newRoom.ToString()}");

                    AddRoomBasic(newBooking, newRoom);
                    break;
                case "2":
                    RoomPremium newRoomPremium = new RoomPremium();
                    Console.WriteLine("How many beds do you need?:");
                    newRoomPremium.NumberOfBeds = GetValueFromUser();
                    AddRoomPremium(newBooking, newRoomPremium);
                    break;
                case "3":
                    ShowInConsole(newBooking);
                    break;
                case "4":
                    DeleteRoom(newBooking);
                    break;
                case "X":
                    CloseApp = true;
                    break;

                default:
                    Console.WriteLine("Invalid operation.\n");
                    break;
            }
            Console.WriteLine("\n\nPress any key to leave to main menu.");
            Console.ReadKey();

            static int GetValueFromUser()
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int value))
                {
                    return value;
                }
                return 69;
            }

            static bool GetUpgrades()
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
            static void AddRoomPremium(IWritetRepository<RoomPremium> repository, RoomPremium room)
            {
                repository.Add(room);
                repository.Save();
            }
            static void AddRoomBasic(IRepository<RoomBasic> repository, RoomBasic room)
            {
                repository.Add(room);
                repository.Save();
            }
            static void ShowInConsole(IReadRepository<IInventoryBasic> bookings)
            {
                var items = bookings.GetAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item + "\n");
                }
            }
            static void DeleteRoom(IRepository<RoomBasic> repository)
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
        }
    }

    private static void NewBookingRoomRemoved(object? sender, RoomBasic room)
    {
        DateTime dateTime = DateTime.Now;
        Console.WriteLine($"room number {room.Id} has bean removed");
        using (var writer = File.AppendText("logs.txt"))
        {
            writer.WriteLine($"[{dateTime}]-RoomAdded-[{room.Id} and was: {(room.IsBasic ? "Premium" : "Basic")}]");
        }
    }

    private static void NewBookingRoomAdded(object? sender, RoomBasic room)
    {
        DateTime dateTime = DateTime.Now;
        Console.WriteLine($"room number {room.Id} has bean added");
        using (var writer = File.AppendText("logs.txt"))
        {
            writer.WriteLine($"[{dateTime}]-RoomAdded-[{room.Id} and its: {(room.IsBasic ? "Premium": "Basic")}]");
        }
        
    }
}