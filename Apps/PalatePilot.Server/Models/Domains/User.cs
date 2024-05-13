using Microsoft.AspNetCore.Identity;

namespace PalatePilot.Server.Models.Domains
{
    public class User : IdentityUser
    {
        public Cart Cart { get; set; } = null!;
        public List<Order> Orders = new();
    }
}