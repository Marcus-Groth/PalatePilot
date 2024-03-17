using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Repository;

namespace PalatePilot.Server.Services.FoodService
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _repository;
        public FoodService(IFoodRepository repository)
        {
            _repository = repository;
        }
        public List<Food> GetAll()
        {
           return _repository.GetAll();
        }
    }
}