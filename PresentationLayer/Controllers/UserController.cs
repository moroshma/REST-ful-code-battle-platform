
using BusinessLogicLayer.DTO;
using Microsoft.AspNetCore.Mvc;

namespace codeBattleService.PresentationLayer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    [Route("Register")]
    public ActionResult Register([FromBody] RegisterForm registerForm)
    {
        
        //usersService.Register(registerForm.UserName, registerForm.Email, registerForm.Password);
        return Ok();
    }
}