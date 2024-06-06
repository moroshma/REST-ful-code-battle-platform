using BuisnessLogicLayer.Interfaces;
using BuisnessLogicLayer.Services;
using BusinessLogicLayer.DTO;
using codeBattleService.BusinessLogicLayer.Interfaces;
using codeBattleService.BusinessLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using BuisnessLogicLayer.DTO;

namespace codeBattleService.Controllers
{
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public ProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpPost]
        [Route("User")]
        [Authorize]//Авторизация 
        public async Task<IActionResult> GetUserDataDTO()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string myCookie = Request.Cookies["net-Token"];
                if (myCookie != null)
                {
                    if (Guid.TryParse(myCookie, out Guid guidValue))
                    {
                        UserDataDTO userDataDTO = await _profileService.User(guidValue);
                        if(userDataDTO != null) 
                        {
                            return Ok(new
                            {
                                userDataDTO = userDataDTO
                            });
                        }
                        else
                            return NotFound(ModelState);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("Completed_games")]
        [Authorize]//Авторизация 
        public async Task<IActionResult> GetCompletedGames()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string myCookie = Request.Cookies["net-Token"];
                if (myCookie != null)
                {
                    if (Guid.TryParse(myCookie, out Guid guidValue))
                    {
                        ComplitedGamesDataDTO ComplitedGamesDataDTO = await _profileService.ComplitedGames(guidValue);
                        if(ComplitedGamesDataDTO != null)
                        {
                            return Ok(new
                            {
                                ComplitedGamesDataDTO = ComplitedGamesDataDTO
                            });
                        }
                        else  
                            return NotFound(ModelState); 
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                string myCookie = Request.Cookies["net-Token"];
                if (myCookie != null)
                {
                    if (Guid.TryParse(myCookie, out Guid guidValue))
                    {
                        User User = await _profileService.Logout(guidValue);
                        if(User != null) 
                        {
                            User.IsSearching = false;
                            Response.Cookies.Delete("net-Token");
                            return Ok();
                        }
                        else
                        {
                            return NotFound(ModelState);
                        }
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return Unauthorized();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
