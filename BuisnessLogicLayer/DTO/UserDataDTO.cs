using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLogicLayer.DTO
{
    public class UserDataDTO(string? userName, string? email, DateTime? registerdata, int? elo)
    {
        public string? UserName { get; set; } = userName;
        public string? Email { get; set; } = email;
        public DateTime? RegisterDate { get; set; } = registerdata;
        public int? Elo { get; set; } = elo;
    }
}
