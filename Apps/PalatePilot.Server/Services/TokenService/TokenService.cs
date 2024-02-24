using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using PalatePilot.Server.Models;

namespace PalatePilot.Server.Services
{
    public class TokenService: ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(LoginRequestDto request, List<string> roles)
        {
            // Generate claims
            var claims = new List<Claim>();
            
            claims.Add(new Claim(ClaimTypes.Name, request.UserName));
            
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            };

            // Generate a Secret key that is convert to a byte array
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:SecretKey"]));

            // Generate a Signature 
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            // Generate a Token
            var token = new JwtSecurityToken(
                _config["JwtConfig:Issuer"],
                _config["JwtConfig:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            // Return the token as a string
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString; 
        }
    }
}