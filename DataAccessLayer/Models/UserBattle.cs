using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    class UserBattle
    {
        public Guid? UserID { get; set; }
        public Guid? BattleID { get; set; }
    }
}
