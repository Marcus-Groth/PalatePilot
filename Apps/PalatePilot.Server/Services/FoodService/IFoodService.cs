using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;

namespace PalatePilot.Server.Services.FoodService
{
    public interface IFoodService
    {
        Task<FoodDto> CreateAsync(FoodCreateDto foodCreateDto);
        Task<List<FoodDto>> GetAllAsync();
        Task<FoodDto> GetByIdAsync(int id);
        Task UpdateAsync(int id, FoodUpdateDto foodUpdateDto);
        Task DeleteAsync(int id);
    }
}