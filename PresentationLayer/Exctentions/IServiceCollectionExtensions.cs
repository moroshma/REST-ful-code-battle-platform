
using codeBattleService.BusinessLogicLayer.Interfaces;
using codeBattleService.BusinessLogicLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Ropositories;

namespace SecretStore.Extensions;

public static class IServiceCollectionExtensions
{

    public static IServiceCollection AddServices(this IServiceCollection collection)
    {
       
//        collection.AddTransient<IGroupService, GroupService>();
  //      collection.AddTransient<ISecretService, SecretService>();
    //    collection.AddTransient<ITokenService, TokenService>();
        collection.AddTransient<IUsersService, UsersService>();
        
        return collection;
    }

    
    public static IServiceCollection AddRepositories(this IServiceCollection collection)
    {
        collection.AddTransient<IUserRepository, UserRepository>();
      //  collection.AddTransient<ISecretRepository, SecretRepository>();
        //collection.AddTransient<ITokensRepository, TokensRepository>();
        //collection.AddTransient<IUserRepository, UserRepository>();
        return collection;
    }
}