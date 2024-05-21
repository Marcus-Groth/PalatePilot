using Microsoft.AspNetCore.Identity;

namespace PalatePilot.Server.Models.Domains
{
    public class User : IdentityUser
    {
        public Cart Cart { get; set; } = null!;
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}