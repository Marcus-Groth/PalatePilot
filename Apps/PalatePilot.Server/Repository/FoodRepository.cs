using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Data.Contexts;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly PalatePilotDbContext _context;

        public FoodRepository(PalatePilotDbContext context)
        {
            _context = context;
        }
        
        public List<Food> GetAll()
        {
            return _context.Foods.ToList();
        }
    }
}