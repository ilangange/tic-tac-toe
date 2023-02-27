using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using VantageTag.TicTacToe.Core.Interfaces;

namespace VantageTag.TicTacToe.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtSecurityTokenHandler _tokenHandler;
        private readonly IConfiguration _config;

        public AuthService(JwtSecurityTokenHandler tokenHandler, IConfiguration config)
        {
            _tokenHandler = tokenHandler;
            _config = config;
        }

        public async Task<string> LoginAsync(string username, string password)
        {
            if (username == "tictactoe" && password == "user@123")
            {
                var tokenKey = Encoding.ASCII.GetBytes(_config.GetSection("Config").GetSection("JwtKey").Value);
                var tokenExpiry = DateTime.UtcNow.AddMinutes(int.Parse(_config.GetSection("Config").GetSection("TokenExpiry").Value));

                SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = tokenExpiry,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = _tokenHandler.CreateToken(securityTokenDescriptor);
                var accessToken = _tokenHandler.WriteToken(token);

                return accessToken;
            }
            else
            {
                return null;
            }
        }
    }
}
