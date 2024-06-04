using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class UserBattle
    {
        public Guid? UserID { get; set; }
        public Guid? BattleID { get; set; }
        public User? User { get; set; }
        public Battle? Battle { get; set; }
    }
}
