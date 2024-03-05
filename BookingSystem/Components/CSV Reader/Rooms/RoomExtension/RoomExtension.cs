using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Components.CSV_Reader.Rooms.Exstensions
{
    public static class RoomExtensions
    {
        public static IEnumerable<Room> ToRoom(this IEnumerable<string> source)
        {
            foreach (var item in source)
            {
                var columns = item.Split(',');

                yield return new Room
                {
                    Id = int.Parse(columns[0]),
                    NumberOfBeds = int.Parse(columns[1]),
                    PrivateBathroom = bool.Parse(columns[2]),
                    Balcony = bool.Parse(columns[3]),
                    GymAccess = bool.Parse(columns[4]),
                    PoolAccess = bool.Parse(columns[5]),
                    Kettle = bool.Parse(columns[6]),
                    Tv = bool.Parse(columns[7]),
                    Tea_Coffe = bool.Parse(columns[8]),
                    GardenView = bool.Parse(columns[9]),
                    StreetView = bool.Parse(columns[10]),
                    Safe = bool.Parse(columns[11])
                };
            }
        }
    }
}
