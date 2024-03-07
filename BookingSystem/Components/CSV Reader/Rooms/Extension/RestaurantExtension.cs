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
                    
                   RoomNumber = int.Parse(columns[0]),
                   Price = int.Parse(columns[1]),
                   Breakfast = bool.Parse(columns[2]),
                   BreakfastDescription = columns[3],
                   Brunch = bool.Parse(columns[4]),
                   BrunchDescription = columns[5],
                   Dinner = bool.Parse(columns[6]),
                   DinnerDescription = columns[7],
                };
            }
        }
    }
}
