using BookingSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookingSystem.Data.Repositories
{
    
    public class SqlRepository<T> : IRepository<T> where T : class, IInventoryBasic, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;
        private readonly Action<T>? _roomAddedCallBack;

        public SqlRepository(DbContext dbContext, Action<T>? roomAddedCallback = null)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
            _roomAddedCallBack = roomAddedCallback;
        }
        public event EventHandler<T>? RoomAdded;

        public void Add(T item)
        {
            _dbSet.Add(item);
            _roomAddedCallBack?.Invoke(item);
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
