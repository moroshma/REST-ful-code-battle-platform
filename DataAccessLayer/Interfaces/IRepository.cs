using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(string id);
        Task<IEnumerable<User>> FindAsync(Func<T, bool> predicate);
        Task CreateAsync(T item);
        void Update(T item);
        void DeleteAsync(string id);
    }
}
