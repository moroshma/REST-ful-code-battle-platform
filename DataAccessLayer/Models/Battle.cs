using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Battle
    {
        public Guid? BattleId { get; set; }
        public string? Language { get; set; } = "Go";
        public DateTime? BattleDate { get; set; }
        public User? FirstUser { get; set; }
        public User? SecondUser { get; set; }
        public User? Winner { get; set; }
        public Task? Task { get; set; }
        public ICollection<UserBattle>? UserBattle { get; set; }
    }
}
