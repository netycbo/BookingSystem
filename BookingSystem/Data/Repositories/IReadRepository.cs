using BookingSystem.Data.Entities;

namespace BookingSystem.Data.Repositories
{
    public interface IReadRepository<out T> where T : class, IInventoryBasic
    {
        public IEnumerable<T> GetAll();
        T GetById(int id);

    }
}
