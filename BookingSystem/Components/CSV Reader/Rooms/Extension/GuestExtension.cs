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
                    
                    Name = columns[0],
                    Surname = columns[1],
                    Email = columns[2],
                    PhoneNumber = columns[3],
                    Address = columns[4]
                };
            }
        }
    }
}
