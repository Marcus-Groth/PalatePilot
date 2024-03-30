using Microsoft.EntityFrameworkCore;
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
        
        public async Task<List<Food>> GetAll()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food?> GetById(int id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public void Create(Food food)
        {
            _context.Foods.Add(food);
            _context.SaveChanges();
        }        
    }
}