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
        var req = _userService.Add(registerForm.UserName, registerForm.Email, registerForm.Password);
        return Ok(new
        {
            UserId = req.Result,
        });
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] LoginForm registerForm)
    {
        try
        {
            var req = await _userService.Get(registerForm.UserName, registerForm.Password);

            return Ok(new
            {
                UserId = req.Id,
                Email = req.Email,
                UserName = req.UserName,
            });
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
   
    }
}