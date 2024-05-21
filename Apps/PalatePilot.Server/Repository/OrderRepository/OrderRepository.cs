using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PalatePilot.Server.Data.Contexts;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PalatePilotDbContext _context;

        public OrderRepository(PalatePilotDbContext context)
        {
            _context = context;
        }

        public async Task<Order> CreatAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order?> GetByIdAsync(int orderId, string userId)
        {
            return await _context.Orders
                .Include(order => order.OrderItems)
                .FirstOrDefaultAsync(order => order.Id == orderId && order.UserId == userId);            
        }

        public async Task<List<Order>> GetAllAsync(string userId)
        {
            return await _context.Orders
                .Where(order => order.UserId == userId)
                .Include(order => order.OrderItems)
                .ToListAsync();
        }
    }
}