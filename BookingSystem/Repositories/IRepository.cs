﻿using BookingSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Repositories
{
    public interface IRepository<T> : IReadRepository<T>, IWritetRepository<T>
        where T : class, IInventoryBasic
    {
        void Add(T item);
        void Remove(T item);
        void Save();
        IEnumerable<T> GetAll();
        T GetById(int id);
      
    }
}
