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

        public async Task<Food> CreatAsync(Food food)
        {
            await _context.Foods.AddAsync(food);
            await _context.SaveChangesAsync();
            return food;
        } 
        
        public async Task<List<Food>> GetAllAsync()
        {
            return await _context.Foods.ToListAsync();
        }

        public async Task<Food?> GetByIdAsync(int id)
        {
            return await _context.Foods.FindAsync(id);
        }  

        public async Task<Food?> GetByNameAsync(string name)
        {
            return await _context.Foods.FirstOrDefaultAsync(f => f.Name == name);
        }

        public async Task UpdateAsync(Food food)
        {
           _context.Foods.Update(food);
           await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Food food)
        {
            _context.Foods.Remove(food);
            await _context.SaveChangesAsync();
        }  
    }
}