using BusinessLogicLayer.DTO;
using codeBattleService.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace codeBattleService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : Controller
{
    private readonly IUsersService _userService;


    public AuthController(IUsersService userService)
    {
        _userService = userService;
    }
    
    
    
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] RegisterForm registerForm)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            
            
            var req = await _userService.Add(registerForm.UserName, registerForm.Email, registerForm.Password);
            return Ok(new
            {
                UserId = req
            });
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
            
        }
        
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginForm registerForm)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        try
        {
            var req = await _userService.Get(registerForm.UserName, registerForm.Password);

            // Создаем куки с токеном
            Response.Cookies.Append("net-Token", req, new CookieOptions
            {
                HttpOnly = true, // делаем куки доступными только на сервере
                Secure = false, // передаем куки только через HTTPS
                SameSite = SameSiteMode.Strict, // предотвращаем отправку куки на другие сайты
                MaxAge = TimeSpan.FromHours(12) // устанавливаем время жизни куки
            });

            return Ok(new
            {
                Token = req
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}