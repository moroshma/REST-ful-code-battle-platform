﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(Guid id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
