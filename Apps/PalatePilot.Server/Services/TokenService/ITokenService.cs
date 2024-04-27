using Microsoft.AspNetCore.Identity;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Services
{
    public interface ITokenService
    {
        string GenerateToken(User fetchedUser, List<string> roles);
    }
}