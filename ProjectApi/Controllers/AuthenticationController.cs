using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/token")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration; 
        }

        [HttpPost]
        public IActionResult GetTokens(AccountModel account)
        {
            if (IsValidAccount(account.Username, account.Password))
            {
                var token = CreateToken(account.Username, "admin");
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private bool IsValidAccount(string username, string password)
        {
            return (username == "username" && password == "password");
        }

        private string CreateToken(string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public class AccountModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
    }
}
