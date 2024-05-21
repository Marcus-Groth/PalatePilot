using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}