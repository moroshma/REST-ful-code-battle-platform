using DataAccessLayer.Models;

namespace codeBattleService.BusinessLogicLayer.Interfaces;

public interface IJwtProvider
{
    string GenerateToken(User user);
}