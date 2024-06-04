﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    class Battle
    {
        public Guid? ID { get; set; }
        public Guid? FirstId { get; set; }
        public Guid? SecondId { get; set; }
        public int? TaskId { get; set; }
        public Guid? BattleId { get; set; }

        public User? FirstUser { get; set; }
        public User? SecondUser { get; set; }
        public Task? Task { get; set; }
        public ICollection<UserBattle>? UserBattles { get; set; }
    }
}
