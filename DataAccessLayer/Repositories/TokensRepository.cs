using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;

using SecretStore.DataAccess.Models;
using SecretStore.Domain.Interfaces.Repositories;

namespace SecretStore.DataAccess.Repositories;

public class TokensRepository : ITokensRepository
{
    private readonly CodeBattleDBContext _context;

    public TokensRepository(CodeBattleDBContext context)
    {
        _context = context;
    }

    public async Task<Guid> Add(Guid userId, string refreshToken)
    {
        var token = await _context.Tokens.AddAsync(new TokensDb
        {
            RefreshToken = refreshToken,
            UserId = userId
        });

        await _context.SaveChangesAsync();

        return token.Entity.Id;
    }

    public async Task<Guid> Update(Guid userId, string refreshToken)
    {
        var token = await _context.Tokens.FirstOrDefaultAsync(x => x.UserId == userId);

        token.RefreshToken = refreshToken;

        await _context.SaveChangesAsync();
        return token.Id;
    }

    public async Task<Guid?> Get(string refreshToken)
    {
        return (await _context.Tokens.FirstOrDefaultAsync(x => x.RefreshToken == refreshToken))?.UserId;
    }

    public async Task<string?> Get(Guid userId)
    {
        return (await _context.Tokens.FirstOrDefaultAsync(x => x.UserId == userId))?.RefreshToken;
    }
}