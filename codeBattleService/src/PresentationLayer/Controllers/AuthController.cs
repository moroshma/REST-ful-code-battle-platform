using Microsoft.AspNetCore.Mvc;


namespace codeBattleService.Controllers;

[ApiController]
[Route("[controller]")]

public class AuthController : ControllerBase
{
    /*
    IAuthService AuthService { get; }
    IOptions<AuthOptions> AuthOptions { get; }

    public AuthController(IAuthService authService, IOptions<AuthOptions> authOptions)
    {
        AuthService = authService;
        AuthOptions = authOptions;
    }

    [HttpPost]
    [Route("Register")]
    public TokenDTO Register([FromBody]  registerForm)
    {
        return AuthService.RegisterUser(registerForm);
    }

    [HttpGet]
    [Route("Login")]
    public TokenDTO Login(LoginForm loginForm)
    {
        return AuthService.LoginUser(loginForm);
    }

    [HttpGet]
    [Route("AuthorizeBot")]
    public TokenDTO AuthorizeBot([FromBody] BotAuthDTO botAuthDTO)
    {
        return AuthService.AuthorizeBot(botAuthDTO.Secret);
    }

    [HttpGet]
    [Route("RefreshToken")]
    public ActionResult<TokenDTO> RefreshToken(string refreshToken)
    {
        JwtSecurityToken token = new JwtSecurityToken(refreshToken);
        if (!ValidateRefreshToken(token)) return Unauthorized();
        TokenDTO tokenDTO = new TokenDTO(
            id: token.Claims.First(c => c.Type == ClaimTypes.Name).Value,
            accessToken: "",
            refreshToken: refreshToken
        );
        return AuthService.RefreshToken(tokenDTO);
    }

    private bool ValidateRefreshToken(JwtSecurityToken jwtToken)
    {
        string tokenString = jwtToken.ToString().Replace("\\", "");
        int firstDot = tokenString.IndexOf('.');
        string header = Base64UrlEncoder.Encode(Encoding.UTF8.GetBytes(tokenString.Substring(0, firstDot)));
        string payload =
            Base64UrlEncoder.Encode(
                Encoding.UTF8.GetBytes(tokenString.Substring(firstDot + 1, tokenString.Length - firstDot - 1)));
        string signature = Base64UrlEncoder.Encode(HMACSHA256.HashData(Encoding.UTF8.GetBytes(AuthOptions.Value.Secret),
            Encoding.UTF8.GetBytes(header + "." + payload)));
        if (jwtToken.RawSignature == signature) return true;
        else return false;
    }
}
*/
}