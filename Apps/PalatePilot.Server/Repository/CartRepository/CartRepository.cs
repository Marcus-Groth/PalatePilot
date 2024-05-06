using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Data.Contexts;

namespace PalatePilot.Server.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly PalatePilotDbContext _context;

        public CartRepository(PalatePilotDbContext context)
        {
            _context = context;
        }
        
        
    }
}