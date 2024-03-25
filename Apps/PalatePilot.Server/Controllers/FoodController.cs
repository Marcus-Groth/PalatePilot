using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.Models;
using PalatePilot.Server.Services.FoodService;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _service;
        
        public FoodController(IFoodService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var foodList = _service.GetAll();

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "OK",
                message: "The list of foods has been successfully retrieved.",
                data: foodList
            );

            return Ok(response);  
        }

        [HttpGet("Id")]
        public IActionResult GetById(int id)
        {
            var food = _service.GetById(id);

            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "Ok",
                message: "The food has been successfully retrieved",
                data: food
            );

            return Ok(response);
        }
    }
}