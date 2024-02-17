using BookingSystem.Data.Entities;

namespace BookingSystem.Data.Repositories
{
    public interface IWritetRepository<in T> where T : class, IInventoryBasic
    {
        void Add(T item);
        void Remove(T item);
        void Save();
    }
}
