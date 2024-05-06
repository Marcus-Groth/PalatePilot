using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PalatePilot.Server.Data.Contexts;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly PalatePilotDbContext _context;

        public CartRepository(PalatePilotDbContext context)
        {
            _context = context;
        }

        public async Task CreateCartAsync(Cart cart)
        {
            await _context.Carts.AddAsync(cart);
        }

        public async Task SaveCartAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<Cart?> GetCartAsync(string userId)
        {
            return await _context.Carts
                .Include(cart => cart.CartItems)
                .ThenInclude(cartItem => cartItem.Food)
                .FirstOrDefaultAsync(cart => cart.UserId == userId); 
        }        
    }
}