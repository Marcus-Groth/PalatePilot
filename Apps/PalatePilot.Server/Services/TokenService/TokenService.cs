using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Services
{
    public class TokenService: ITokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User fetchedUser, List<string> roles)
        {
            // Generate claims
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, fetchedUser.Id),
                new Claim(JwtRegisteredClaimNames.Email, fetchedUser.Email),
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            
            // Set the expiration time of the token
            var expires = DateTime.Now.AddMinutes(Double.Parse(_config["JwtConfig:Expires"]));

            // Generate a Secret key that is convert to a byte array
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtConfig:SecretKey"]));

            // Generate a Signature 
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);


            // Generate a Token
            var token = new JwtSecurityToken(
                issuer: _config["JwtConfig:Issuer"],
                audience: _config["JwtConfig:Audience"],
                claims: claims,
                null,
                expires: expires,
                signingCredentials: credentials
            );

            // Return the token as a string
            string tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString; 
        }
    }
}