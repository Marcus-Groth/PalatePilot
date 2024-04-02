using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;

namespace PalatePilot.Server.Repository
{
    public interface IFoodRepository
    {
        Task<Food> CreatAsync(Food food);
        Task<List<Food>> GetAll();
        Task<Food?> GetById(int id);
        Task<Food?> GetByName(string name);
        Task DeleteAsync(Food food);
    }
}