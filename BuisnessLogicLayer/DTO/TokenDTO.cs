using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DTO
{
    public class TokenDTO
    {
        public TokenDTO(string id, string accessToken, string refreshToken)
        {
            Id=id;
            AccessToken=accessToken;
            RefreshToken=refreshToken;
        }

        public string Id { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
