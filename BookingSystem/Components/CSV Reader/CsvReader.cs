using BookingSystem.Components.CSV_Reader.Rooms;
using BookingSystem.Components.CSV_Reader.Rooms.Exstensions;
using BookingSystem.Components.CSV_Reader.Rooms.Extension;

namespace BookingSystem.Components.CSV_Reader
{
    internal class CsvReader : ICsvReader
    {
        public List<GuestInfo> ReadGuestInfo(string path)
        {
            if (!File.Exists(path))
            {
                return new List<GuestInfo>();
            }
            var guests = File.ReadAllLines(path).Skip(1).Where(x => x.Length > 1).ToGuest();
            return guests.ToList();
        }

        public List<RestaurantInfo> ReadRestaurantInfo(string path)
        {
            if (!File.Exists(path))
            {
                return new List<RestaurantInfo>();
            }
            var restaurants = File.ReadAllLines(path).Skip(1).Where(x => x.Length > 1).ToRestaurant();
            return restaurants.ToList();
        }

        public List<RoomInfo> ReadRoomData(string path)
        {
            if (!File.Exists(path))
            {
                return new List<RoomInfo>();
            }
            var rooms = File.ReadAllLines(path).Skip(1).Where(x => x.Length > 1).ToRoom();
            return rooms.ToList();
        }
    }
}
