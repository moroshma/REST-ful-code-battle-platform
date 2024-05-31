using DataAccessLayer.EF;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace DataAccessLayer.Ropositories
{

    public class UserRepository :  IUserRepository
    {
        private CodeBattleDBContext db;

        public UserRepository(CodeBattleDBContext officeDbContext)
        {
            db = officeDbContext;
        }


        public async Task<IEnumerable<User>> FindAsync(Func<User, bool> predicate)
        {
            return await Task.Run(() => db.Users.Where(predicate).ToList());
        }

        public async Task CreateAsync(User item)
        {
            db.Users.Add(item);
            await db.SaveChangesAsync();
        }

        public async void DeleteAsync(string id)
        {
            var deletedUser = db.Users.Find(id);
            if (deletedUser == null) _ = new EntryNotFoundException($"Entity {typeof(User).Name} not found!"); 
            else
            {
                db.Users.Remove(deletedUser);
                await db.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<User>> FindActiveNearEloAsync(int elo, int range)
        {
            return await Task.Run(() =>
            {
                return db.Users.FromSqlRaw("SELECT * FROM Users WHERE Elo BETWEEN {0} AND {1}", elo - range, elo + range);
            });
        }


        public async Task<User> GetAsync(string id)
        {
            var user = await db.Users.FindAsync(id);
            return user ?? throw new EntryNotFoundException($"Entity {typeof(User).Name} not found!");
        }


        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified; 
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await Task.Run(() => db.Users);
        }


        public Task<User> GetByUsernamePasswordAsync(string username, string hashedPassword)
        {
            return db.Users.FirstOrDefaultAsync(u => u.UserName == username && u.Password == hashedPassword);
        }
    }
}
   