using BookingSystem.Data.Entities;
using System.Security.Principal;
using System.Text.Json;

namespace BookingSystem.Data.Repositories
{
    public class RepositoryInFile<T> : IRepository<T> where T : class, IInventoryBasic
    {
        private List<T> rooms = new List<T>();

        public event EventHandler<T>? RoomAdded;
        public event EventHandler<T>? RoomRemoved;

        public void Add(T item)
        {
            rooms.Add(item);
            RoomAdded?.Invoke(this, item);
        }

        public IEnumerable<T> GetAll()
        {
            if (File.Exists("items.json"))
            {
                using (var reader = File.OpenText("items.json"))
                {
                    var line = reader.ReadLine();
                    rooms = JsonSerializer.Deserialize<List<T>>(line);
                }
            }
            return rooms;
        }

        public T GetById(int id)
        {
            return rooms[id];
        }

        public void Remove(T item)
        {
            rooms.RemoveAll(r=>r.Id == item.Id);
            RoomRemoved?.Invoke(this, item);
        }

        public void Save()
        {
            using (StreamWriter writer = new StreamWriter($"rooms.json", false))
            {
                var json = JsonSerializer.Serialize(rooms);
                writer.WriteLine(json);
            }
        }
    }
}
