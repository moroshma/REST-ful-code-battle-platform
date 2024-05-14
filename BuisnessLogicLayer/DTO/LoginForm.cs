using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class LoginForm
    {
        [JsonPropertyName("username")]
        public string UserName { get; set; } = null!;
        [JsonPropertyName("password")]
        public string Password { get; set; } = null!;
        public LoginForm(string email, string password)
        {
            UserName = UserName;
            Password = password;
        }
        public LoginForm() { }
    }
}
