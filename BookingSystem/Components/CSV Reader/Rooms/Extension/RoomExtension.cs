using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Components.CSV_Reader.Rooms.Exstensions
{
    public static class RoomExtensions
    {
        public static IEnumerable<RoomInfo> ToRoom(this IEnumerable<string> source)
        {
            foreach (var item in source)
            {
                var columns = item.Split(',');

                yield return new RoomInfo
                {
                    RoomId = int.Parse(columns[0]),
                    GuestId = int.Parse(columns[1]),
                    NumberOfBeds = int.Parse(columns[2]),
                    PrivateBathroom = bool.Parse(columns[3]),
                    Balcony = bool.Parse(columns[4]),
                    GymAccess = bool.Parse(columns[5]),
                    PoolAccess = bool.Parse(columns[6]),
                    Kettle = bool.Parse(columns[7]),
                    Tv = bool.Parse(columns[8]),
                    Tea_Coffe = bool.Parse(columns[9]),
                    GardenView = bool.Parse(columns[10]),
                    StreetView = bool.Parse(columns[11]),
                    Safe = bool.Parse(columns[12])
                };
            }
        }
    }
}
