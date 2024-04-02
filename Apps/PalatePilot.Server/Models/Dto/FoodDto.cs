using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Dto
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
    }

    public class FoodCreateDto
    {
        [Required]
        public string  Name { get; set; } = string.Empty;
        
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative number.")]
        public int Price { get; set; }
    }
}