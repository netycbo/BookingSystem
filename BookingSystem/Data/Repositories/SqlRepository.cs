using BookingSystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookingSystem.Data.Repositories
{
    public class SqlRepository<T> : IRepository<T> where T : class, new()
    {
        private readonly BookingSystemContext _dbContext;
       
        public event EventHandler<T> RoomAdded;
        public event EventHandler<T> RoomRemoved;

        public SqlRepository(BookingSystemContext dbContext)
        {
            _dbContext = dbContext;
        }
      
        public void Add(T entity)
        {
            _dbContext.Add(entity);
            RoomAdded?.Invoke(this, entity);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _dbContext.Set<T>().Find(id);
        }

        public void Remove(T item)
        {
            _dbContext.Remove(item);
            RoomRemoved?.Invoke(this, item);
        }

        public void Update()
        {
            _dbContext.SaveChanges();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void Update(T item)
        {
            _dbContext.Update(item);
        }
    }


}
