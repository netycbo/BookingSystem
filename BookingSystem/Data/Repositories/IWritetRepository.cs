using BookingSystem.Data.Entities;

namespace BookingSystem.Data.Repositories
{
    public interface IWritetRepository<in T> where T : class, new()
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}
