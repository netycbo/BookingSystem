using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Components.CSV_Reader.Rooms.Extension
{
    public static class GuestExtension
    {
        public static IEnumerable<GuestInfo> ToGuest(this IEnumerable<string> source)
        {
            foreach (var item in source)
            {
                var columns = item.Split(',');

                yield return new GuestInfo
                {
                    GuestId = int.Parse(columns[0]),
                    Name = columns[1],
                    Surname = columns[2],
                    Email = columns[3],
                    PhoneNumber = columns[4],
                    Address = columns[5]
                };
            }
        }
    }
}
