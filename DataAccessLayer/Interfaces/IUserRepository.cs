using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.EF;

namespace DataAccessLayer.Interfaces
{
    
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> FindActiveNearEloAsync(int elo, int range);

        Task<User> GetByUsernamePasswordAsync(string username, string hashedPassword);
    }
    
}
