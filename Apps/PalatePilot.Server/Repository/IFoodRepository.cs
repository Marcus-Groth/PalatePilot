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
        Task<List<Food>> GetAll();
        Task<Food?> GetById(int id);
    }
}