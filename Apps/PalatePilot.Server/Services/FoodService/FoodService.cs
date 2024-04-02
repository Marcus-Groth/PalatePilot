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
            var foodList = await _repository.GetAll();
            var food = foodList
                .FirstOrDefault(f => f.Name.Equals(
                    foodCreateDto.Name,
                    StringComparison.OrdinalIgnoreCase)
                ); 
            
            if(food != null)
            {
                throw new ConflictException("The food item you're trying to add already exists");
            }

            food = await _repository.CreatAsync(_mapper.Map<Food>(foodCreateDto));

            return _mapper.Map<FoodDto>(food);
        }

        public async Task<List<FoodDto>> GetAll()
        {
           var foodList = await _repository.GetAll();
           return _mapper.Map<List<FoodDto>>(foodList);
        }

        public async Task<FoodDto> GetById(int id)
        {
            var food = await _repository.GetById(id);
            if (food == null)
            {
                throw new NotFoundException("The specified food could not be found. Please check the ID and try again");
            }
            
            return _mapper.Map<FoodDto>(food);            
        }

        public async Task<FoodDto> DeleteAsync(int id)
        {
            var food = await _repository.GetById(id);
            if(food == null)
            {
                throw new NotFoundException("The specified food could not be found. Please check the ID and try again");
            }
            
            await _repository.DeleteAsync(food);
            
            return _mapper.Map<FoodDto>(food);
        }
    }
}