using DataAccessLayer.Models;

namespace codeBattleService.BusinessLogicLayer.Interfaces;

public interface IUsersService
{
      Task<Guid> Add(string username, string email, string password);
     Task<string> Get(string username, string password);
}