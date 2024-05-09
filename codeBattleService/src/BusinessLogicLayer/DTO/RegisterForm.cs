using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class RegisterForm
    {
        [JsonPropertyName("userName")]
        public string UserName { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("phoneNumber")]
        public string PhoneNumber { get; set; }
        public RegisterForm()
        {
            UserName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
            PhoneNumber = string.Empty; 
        }
        public RegisterForm(string userName, string email, string password, string phoneNumber)
        {
            UserName=userName;
            Email=email;
            Password=password;
            PhoneNumber=phoneNumber;
        }
    }
}
