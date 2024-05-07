using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Data.Contexts
{
    public class PalatePilotDbContext : DbContext
    {
       public PalatePilotDbContext(DbContextOptions<PalatePilotDbContext> options)
        : base(options)
        {
        }

        public DbSet<Food> Foods {get; set;}
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Unique constraint on Name
            modelBuilder.Entity<Food>()
                .HasIndex(f => f.Name)
                .IsUnique();
        }
    }
}