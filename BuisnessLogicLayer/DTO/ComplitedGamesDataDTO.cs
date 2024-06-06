using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.DTO
{
    public class ComplitedGamesDataDTO(ICollection<UserBattle>? userBattle, int complitedGames)
    {
        public ICollection<UserBattle>? UserBattle = userBattle;
        public int CpmplitedGames = complitedGames;
    }
}
