
using codeBattleService.BusinessLogicLayer.Interfaces;
using codeBattleService.BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Ropositories;
using Infrastructure;

namespace SecretStore.Extensions;

public static class IServiceCollectionExtensions
{

    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
       

        collection.AddTransient<IUsersService, UsersService>();
        collection.AddTransient<IJwtProvider, JwtProvider>();
        
        return collection;
    }

    
    public static IServiceCollection AddRepositories(this IServiceCollection collection)
    {
        collection.AddTransient<IUserRepository, UserRepository>();

        return collection;
    }

}