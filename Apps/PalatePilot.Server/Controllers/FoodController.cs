using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Services.FoodService;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _service;
        
        public FoodController(IFoodService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(FoodCreateDto foodCreateDto)
        {
            var foodDto = await _service.CreateAsync(foodCreateDto);
            
            var response = new SuccessResponse<object>
            (
                statusCode: 201,
                title: "Create",
                message: "Food item created successfully"
            );

            return CreatedAtAction(nameof(GetById), new { id = foodDto.Id }, response);
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var foodList = await _service.GetAllAsync();

            // Create new response
            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "OK",
                message: "List of food items retrieved successfully",
                data: foodList
            );

            return Ok(response);  
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetById(int id)
        {
            var food = await _service.GetByIdAsync(id);

            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "Ok",
                message: "Food item retrieved successfully",
                data: food
            );

            return Ok(response);
        }

        [HttpPut("Id")]
        public async Task<IActionResult> Update(int id, FoodUpdateDto foodUpdateDto)
        {
            await _service.UpdateAsync(id, foodUpdateDto);

            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "OK",
                message: "Food item updated successfully"
            );

            return Ok(response);
        }


        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);

            var response = new SuccessResponse<object>
            (
                statusCode: 200,
                title: "Ok",
                message: "Food item deleted successfully"
            );

            return Ok(response);
        }
    }
}