using DataAccessLayer.EF;
using Microsoft.EntityFrameworkCore;

namespace codeBattleService.BusinessLogicLayer.Services;

public class TaskFinder
{
    private readonly CodeBattleDBContext _dbContext;

    public TaskFinder(CodeBattleDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid?> FindTaskAsync(Guid firstUserId, Guid secondUserId)
    {
        // Получаем Elo обоих игроков
        var firstUserElo = await _dbContext.Users.Where(u => u.ID == firstUserId).Select(u => u.Elo).FirstOrDefaultAsync();
        var secondUserElo = await _dbContext.Users.Where(u => u.ID == secondUserId).Select(u => u.Elo).FirstOrDefaultAsync();

        // Вычисляем среднее Elo
        var averageElo = (firstUserElo + secondUserElo) / 2;
        
        // Находим задачу, уровень которой соответствует среднему Elo
        var task = await _dbContext.Task
            .Where(t => t.Level.Value == "Hard")
            .FirstOrDefaultAsync();

        // Возвращаем TaskId, если задача найдена
        return task?.TaskId;
    }
}

// Пример использования
//public async Task MainAsync()
//{
    // Создаем контекст базы данных
    //var dbContext = new CodeBattleDBContext();

    // Создаем TaskFinder
    //var taskFinder = new TaskFinder(dbContext);

    // Получаем ID двух пользователей
    //var firstUserId = Guid.NewGuid();
    //var secondUserId = Guid.NewGuid();

    // Ищем задачу
    //var taskId = await taskFinder.FindTaskAsync(firstUserId, secondUserId);

    // Проверяем, найдена ли задача
   // if (taskId != null)
  //  {
   //     Console.WriteLine($"Найдена задача с ID: {taskId}");
   // }
 //   else
  //  {
   //     Console.WriteLine("Задача не найдена");
  //  }
//}