using DataAccessLayer.EF;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Task = System.Threading.Tasks.Task;

namespace DataAccessLayer.Ropositories
{

    public class UserRepository :  IUserRepository
    {
        private CodeBattleDBContext db;

        public UserRepository(CodeBattleDBContext officeDbContext)
        {
            db = officeDbContext;
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            return db.Users.Where(predicate);
        }

        public async Task Create(User item)
        {
            db.Users.Add(item);
            await db.SaveChangesAsync();
        }

        public void Delete(string id)
        {
            var deletedUser = db.Users.Find(id);
            if (deletedUser == null) new EntryNotFoundException($"Entity {typeof(User).Name} not found!");
            else db.Users.Remove(deletedUser);
        }

        public IEnumerable<User> FindActiveNearElo(int elo, int range)
        {
            return db.Users.FromSqlRaw("SELECT * FROM Users WHERE Elo BETWEEN {0} AND {1}", elo - range, elo + range);
        }

        public User Get(string id)
        {
            var user = db.Users.Find(id);
            if (user == null) throw new EntryNotFoundException($"Entity {typeof(User).Name} not found!");
            return user;
        }

        public void Update(User item)
        {
            db.Entry(item).State = EntityState.Modified; 
        }
        
        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }
        
        public User GetByUsernamePassword(string username, string hashedPassword)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username && u.Password == hashedPassword);
        }
    }
}
   