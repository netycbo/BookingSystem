using BookingSystem.Components.CSV_Reader.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Components.CSV_Reader
{
    public interface ICsvReader
    {
        List<RoomInfo> ReadRoomData(string path);
        List<GuestInfo> ReadGuestInfo(string path);
        List<RestaurantInfo> ReadRestaurantInfo(string path);
    }
}
