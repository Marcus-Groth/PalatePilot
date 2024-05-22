using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PalatePilot.Server.Models
{
    public class AddItemRequest
    {
        [Required]
        public int FoodId { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero.")]
        public int Quantity { get; set; } = 1;
    }
}