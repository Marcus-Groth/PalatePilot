using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Data.Contexts;

namespace PalatePilot.Server.Repository.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PalatePilotDbContext _context;

        public OrderRepository(PalatePilotDbContext context)
        {
            _context = context;
        }
    }
}