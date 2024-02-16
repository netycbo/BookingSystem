using BookingSystem.Entities;

namespace BookingSystem.Repositories
{
    public interface IReadRepository<out T> where T : class, IInventoryBasic
    {
        public IEnumerable<T> GetAll();
        T GetById(int id);

    }
}
