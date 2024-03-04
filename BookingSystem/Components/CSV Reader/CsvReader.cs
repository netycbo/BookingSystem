using BookingSystem.Components.CSV_Reader.Rooms;
using BookingSystem.Components.CSV_Reader.Rooms.Exstensions;

namespace BookingSystem.Components.CSV_Reader
{
    internal class CsvReader : ICsvReader
    {
        public List<Room> ReadCsv(string path)
        {
            if (!File.Exists(path))
            {
                return new List<Room>();
            }
            var rooms = File.ReadAllLines(path).Skip(1).Where(x => x.Length > 1).ToRoom();
            return rooms.ToList();
        }
    }
}
