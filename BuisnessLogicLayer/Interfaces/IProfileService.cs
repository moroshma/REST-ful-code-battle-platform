using BuisnessLogicLayer.DTO;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Interfaces
{
    public interface IProfileService
    {
        public Task<UserDataDTO> User(Guid IdUser);
        public Task<ComplitedGamesDataDTO> ComplitedGames(Guid IdUser);
        public Task<User> Logout(Guid IdUser);
    }
}
