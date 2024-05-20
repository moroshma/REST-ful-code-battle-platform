using codeBattleService.BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using Infrastructure;


namespace codeBattleService.BusinessLogicLayer.Services;


public class UsersService(IUserRepository userRepository) : IUsersService {
    
    public async Task<Guid> Add(string username, string email, string password)
    {
        PasswordHasher passwordHasher = new PasswordHasher();
        // Проверяем, существует ли уже пользователь с таким именем или электронной почтой
        //var existingUser = await userRepository.GetByUsernameOrEmail(username, email);
        //if (existingUser != null)
        //{
           // throw new Exception("User with this username or email already exists.");
        //}

        // Хешируем пароль
        var hashedPassword = password;//passwordHasher.Generate(password);

        // Создаем нового пользователя
        var user = new User
        {
            ID = Guid.NewGuid(),
            UserName = username,
            Email = email,
            Password = hashedPassword,
            Elo = 1200, // начальное значение Elo
        };

        // Добавляем нового пользователя в репозиторий
        userRepository.Create(user);

        // Возвращаем идентификатор нового пользователя
        return user.ID.Value;
    }

    public Task<User> Get(string username, string password)
    {
        PasswordHasher passwordHasher = new PasswordHasher();
        var hashedPassword = password;//passwordHasher.Generate(password);
        
        // Получаем пользователя по имени
        var user = userRepository.GetByUsernamePassword(username, hashedPassword);
        
        // Проверяем, существует ли пользователь с таким именем и паролем
        if (user == null)
        {
            throw new Exception("Invalid username or password.");
        }
        
        return Task.FromResult(user);
    }
}

