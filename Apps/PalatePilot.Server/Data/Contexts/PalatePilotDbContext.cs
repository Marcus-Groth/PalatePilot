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
            
            var userRoleId = "USER_ID";
            var adminRoleId = "ADMIN_ID";

           
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

            var userName = "admin";
            var email = "admin1234@example.com";

            // Admin user
            var admin = new User
            {
                UserName = userName,
                NormalizedUserName = userName.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                EmailConfirmed = true,
            };

            // Hash password and save it
            PasswordHasher<User> passwordHaser = new PasswordHasher<User>();
            admin.PasswordHash = passwordHaser.HashPassword(admin, "P@ssw0rd!");

            // Seed admin user
            builder.Entity<User>().HasData(admin);

            // Seed admin's role
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string> 
            { 
                UserId = admin.Id,
                RoleId = adminRoleId
            });

            // Seed Food Items
            builder.Entity<Food>().HasData(
                new { Id = 1, Name = "Vesuvio Pizza", Price = 11, Ingredients = "Dough, Tomato Sauce, Mozzarella, Ham" },
                new { Id = 2, Name = "Pepperoni Pizza", Price = 12, Ingredients = "Dough, Tomato Sauce, Mozzarella, Pepperoni" },
                new { Id = 3, Name = "BBQ Chicken Pizza", Price = 13, Ingredients = "Dough, BBQ Sauce, Mozzarella, Grilled Chicken, Red Onion, Cilantro" },
                new { Id = 4, Name = "Hawaiian Pizza", Price = 12, Ingredients = "Dough, Tomato Sauce, Mozzarella, Ham, Pineapple" },
                new { Id = 5, Name = "Veggie Pizza", Price = 13, Ingredients = "Dough, Tomato Sauce, Mozzarella, Bell Peppers, Onions, Mushrooms, Olives" }
            );

            // Unique constraint on Name
            builder.Entity<Food>()
                .HasIndex(f => f.Name)
                .IsUnique();
        }
    }
}