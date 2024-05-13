using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Data.Contexts
{
    public class PalatePilotDbContext : IdentityDbContext<User>
    {
       public PalatePilotDbContext(DbContextOptions<PalatePilotDbContext> options)
        : base(options)
        {
        }
        
        public DbSet<Food> Foods {get; set;}
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

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

            // Seed Food Items
            builder.Entity<Food>().HasData(
                new { Id = 1, Name = "Andriy", Price = 85 },
                new { Id = 2, Name = "Cheeseburger", Price = 95 },
                new { Id = 3, Name = "Margherita Pizza", Price = 110 },
                new { Id = 4, Name = "Caesar Salad", Price = 70 },
                new { Id = 5, Name = "Spaghetti Bolognese", Price = 90 }
            );

            // Unique constraint on Name
            builder.Entity<Food>()
                .HasIndex(f => f.Name)
                .IsUnique();
        }
    }
}