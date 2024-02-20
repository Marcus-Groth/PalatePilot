using PalatePilot.Server.Models;

namespace PalatePilot.Server.Services
{
    public interface ITokenService
    {
        string GenerateToken(LoginRequestDto request, List<string> roles);
    }
}