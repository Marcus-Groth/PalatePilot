using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PalatePilot.Server.Exceptions;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Repository;

namespace PalatePilot.Server.Services.FoodService
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _repository;
        private readonly  IMapper _mapper;
        public FoodService(IFoodRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FoodDto> CreateAsync(FoodCreateDto foodCreateDto)
        {
            var existingFood = await _repository.GetByNameAsync(foodCreateDto.Name);
            if(existingFood != null)
            {
                throw new ConflictException("The food item you're trying to add already exists");
            }

            var newFood = await _repository.CreatAsync(_mapper.Map<Food>(foodCreateDto));

            return _mapper.Map<FoodDto>(newFood);
        }

        public async Task<List<FoodDto>> GetAllAsync()
        {
           var foodList = await _repository.GetAllAsync();
           return _mapper.Map<List<FoodDto>>(foodList);
        }

        public async Task<FoodDto> GetByIdAsync(int id)
        {
            var food = await _repository.GetByIdAsync(id);
            if (food == null)
            {
                throw new NotFoundException("The specified food could not be found. Please check the ID and try again");
            }
            
            return _mapper.Map<FoodDto>(food);            
        }

        public async Task UpdateAsync(int id, FoodUpdateDto foodUpdateDto)
        {
            var existingFood = await _repository.GetByIdAsync(id);
            if(existingFood == null)
            {
                throw new NotFoundException("The specified food could not be found. Please check the ID and try again");
            }

            existingFood.Name = foodUpdateDto.Name;
            existingFood.Price = foodUpdateDto.Price;

            await _repository.UpdateAsync(existingFood);
        }

        public async Task DeleteAsync(int id)
        {
            var existingFood = await _repository.GetByIdAsync(id);
            if(existingFood == null)
            {
                throw new NotFoundException("The specified food could not be found. Please check the ID and try again");
            }
            
            await _repository.DeleteAsync(existingFood);
        }
    }
}