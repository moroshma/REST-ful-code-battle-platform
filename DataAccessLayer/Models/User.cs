using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer.Models
{
    public class User
    {
        public Guid? ID { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Elo { get; set; }
        public bool IsSearching { get; set; }
        public string? ProfilePhotoScr { get; set; }

        public DateTime? RegisterDate { get; set; }
        public ICollection<UserBattle>? Battles { get; set; }

    }
}
