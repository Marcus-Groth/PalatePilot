using Microsoft.AspNetCore.Identity;
using PalatePilot.Server.Models;

namespace PalatePilot.Server.Services
{
    public interface ITokenService
    {
        string GenerateToken(IdentityUser user, List<string> roles);
    }
}