using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Data
{
    public class AuthDbContext : IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            var userRoleId = "1";
            var adminRoleId = "2";

           
            var roles = new List<IdentityRole>
            {
                // User Role
                new IdentityRole 
                {
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId,
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                
                // Admin Role
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                }
            };
            
            // Seed Roles
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}