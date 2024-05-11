using DataAccessLayer.EF;
using DataAccessLayer.Exceptions;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Ropositories
{

    public class UserRepository : IUserRepository
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

        public void Create(User item)
        {
            db.Users.Add(item);
        }

        public void Delete(string id)
        {
            var deletedUser = db.Users.Find(id);
            if (deletedUser == null) new EntryNotFoundException($"Entity {typeof(User).Name} not found!");
            else db.Users.Remove(deletedUser);
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
        
    }
}
   