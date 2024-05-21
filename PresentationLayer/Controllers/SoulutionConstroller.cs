using BusinessLogicLayer.DTO;
using codeBattleService.BusinessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace codeBattleService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoulutionConstroller : Controller
    {
        [HttpPost]
        [Route("Solution")]
        [Authorize]//Авторизация 
        public async Task<IActionResult> Register([FromBody] RegisterForm registerForm)
        {
            return Ok(new { });
        }
    }
}