using BookingSystem.Entities;

namespace BookingSystem.Repositories
{
    public interface IWritetRepository<in T> where T : class, IInventoryBasic
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}
