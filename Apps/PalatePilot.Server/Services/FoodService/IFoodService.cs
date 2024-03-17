using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models.Domains;

namespace PalatePilot.Server.Services.FoodService
{
    public interface IFoodService
    {
        List<Food> GetAll();
    }
}