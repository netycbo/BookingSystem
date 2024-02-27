using BookingSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookingSystem.Data.Repositories
{
    
    public class SqlRepository<T> : IRepository<T> where T : class, IInventoryBasic, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        public event EventHandler<T> RoomAdded;
        public event EventHandler<T> RoomRemoved;

        public SqlRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            
        }
      
        public void Add(T item)
        {
            _dbSet.Add(item);
            RoomAdded?.Invoke(this, item);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.OrderBy(item => item.Id).ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Remove(T item)
        {
            _dbSet.Remove(item);
            RoomRemoved?.Invoke(this, item);
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            _dbSet.Update(item);
        }
    }


}
