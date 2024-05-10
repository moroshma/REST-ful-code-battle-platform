using codeBattleService.BusinessLogicLayer.Interfaces;

namespace codeBattleService.BusinessLogicLayer.Services;

public class UsersService
{   private readonly IPasswordHasher _passwordHasher;
    public UsersService(IPasswordHasher passwordHasher)
    {
        _passwordHasher = passwordHasher;
    }
    public async Task Register(string username, string email, string password)
    {
        string hashedPassword = _passwordHasher.Generate(password);
        //var user = new User(username, email, hashedPassword);
    }
}