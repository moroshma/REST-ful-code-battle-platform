

namespace SecretStore.Domain.Interfaces.Repositories;

public interface ITokensRepository
{
    Task<Guid> Add(Guid userId, string refreshToken);
    Task<Guid> Update(Guid userId, string refreshToken);
    Task<Guid?> Get(string refreshToken);
    Task<string?> Get(Guid userId);
}