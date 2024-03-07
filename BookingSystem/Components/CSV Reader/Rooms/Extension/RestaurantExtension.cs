using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Components.CSV_Reader.Rooms.Extension
{
    public static class RestaurantExtension
    {
        public static IEnumerable<RestaurantInfo> ToRestaurant(this IEnumerable<string> source)
        {
            foreach (var item in source)
            {
                var columns = item.Split(',');

                yield return new RestaurantInfo
                {
                   GuestId = int.Parse(columns[0]),
                   RoomNumber = int.Parse(columns[1]),
                   Price = int.Parse(columns[2]),
                   Breakfast = bool.Parse(columns[3]),
                   BreakfastDescription = columns[4],
                   Brunch = bool.Parse(columns[5]),
                   BrunchDescription = columns[6],
                   Dinner = bool.Parse(columns[7]),
                   DinnerDescription = columns[8],
                };
            }
        }
    }
}
