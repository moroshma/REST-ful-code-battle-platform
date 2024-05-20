using System;
using System.Collections.Generic;
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
        
        public string RefreshToken { get; set; } = null!;
        
    }
}
