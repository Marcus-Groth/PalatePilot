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
        public List<Food> GetAll()
        {
           return _repository.GetAll();
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
    }
}