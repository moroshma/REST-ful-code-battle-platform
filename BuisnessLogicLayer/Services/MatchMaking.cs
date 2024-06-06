using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;

namespace codeBattleService.BusinessLogicLayer.Services;

public class MatchMaking
{
    private readonly CodeBattleDBContext _dbContext;
    private readonly int _eloDifferenceLimit;

    public MatchMaking(CodeBattleDBContext dbContext, int eloDifferenceLimit)
    {
        _dbContext = dbContext;
        _eloDifferenceLimit = eloDifferenceLimit;
    }

    public async Task<Tuple<Guid, Guid>> FindMatchAsync()
    {
        // Получаем всех пользователей, которые ищут противника
        var searchingUsers = await _dbContext.Users
            .Where(u => u.IsSearching)
            .OrderBy(u => u.Elo) // Сортируем по Elo для удобства поиска
            .ToListAsync();

        if (searchingUsers.Count < 2)
        {
            // Недостаточно пользователей для поиска матча
            return null;
        }

        // Берем первого в списке пользователя
        var firstUser = searchingUsers.First();

        // Ищем подходящего противника
        var opponent = searchingUsers.FirstOrDefault(u => u.Elo <= firstUser.Elo + _eloDifferenceLimit && u.ID != firstUser.ID);

        if (opponent != null)
        {
            // Противник найден, возвращаем их ID
            return new Tuple<Guid,Guid>(firstUser.ID.Value, opponent.ID.Value);
        }

        return null;
    }

    public async Task MakeMatchAsync(Guid firstUserId, Guid opponentId)
    {
        // Находим пользователей в базе данных
        var firstUser = await _dbContext.Users.FindAsync(firstUserId);
        var opponent = await _dbContext.Users.FindAsync(opponentId);

        if (firstUser != null && opponent != null)
        {
            // Делаем пользователей неактивными
            firstUser.IsSearching = false;
            opponent.IsSearching = false;

            // Сохраняем изменения в базе данных
            await _dbContext.SaveChangesAsync();
        }
    }

    public async Task RunMatchmakingLoopAsync(TimeSpan period)
    {
        while (true)
        {
            // Ищем матч
            var match = await FindMatchAsync();

            if (match != null)
            {
                // Делаем матч
                await MakeMatchAsync(match.Item1, match.Item2);
            }

            // Ждем заданный период времени
            await Task.Delay(period);
        }
    }
}

// Пример использования
//public async Task MainAsync()
//{
    // Создаем контекст базы данных
  //  var dbContext = new CodeBattleDBContext();

    // Создаем Matchmaker с ограничением по разнице Elo
    //var matchmaker = new MatchMaking(dbContext, 100);

    // Запускаем matchmaking loop с периодичностью 5 секунд
    //await matchmaker.RunMatchmakingLoopAsync(TimeSpan.FromSeconds(5));
//}