using Azure.Core;
using BuisnessLogicLayer.DTO;
using BuisnessLogicLayer.Interfaces;
using codeBattleService.BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtProvider _jwtProvider;
        public ProfileService(IUserRepository userRepository, IJwtProvider jwtProvider)
        {
            _userRepository = userRepository;
            _jwtProvider = jwtProvider;
        }

        public async Task<ComplitedGamesDataDTO> ComplitedGames(Guid IdUser)
        {
            var user = await _userRepository.Get(IdUser);
            if (user == null)
            {
                throw new Exception("Invalid Guid.");
            }
            ComplitedGamesDataDTO ComplitedGamesDataDTO = new(user.UserBattle, user.UserBattle == null ? 0 : user.UserBattle.Count);
            return ComplitedGamesDataDTO;
        }

        public async Task<UserDataDTO> User(Guid IdUser)
        {
            var user = await _userRepository.Get(IdUser);
            if (user == null)
            {
                throw new Exception("Invalid Guid.");
            }
            UserDataDTO userDataDTO = new(user.UserName, user.Email, user.RegisterDate, user.Elo);
            return userDataDTO;
        }
        public async Task<User> Logout(Guid IdUser)
        {
            var user = await _userRepository.Get(IdUser);
            if (user == null)
            {
                throw new Exception("Invalid Guid.");
            }
            return user;
        }
    }
}
