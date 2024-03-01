using Microsoft.AspNetCore.Identity;
using PalatePilot.Server.Models;

namespace PalatePilot.Server.Services
{
    public interface ITokenService
    {
        string GenerateToken(IdentityUser fetchedUser, List<string> roles);
    }
}