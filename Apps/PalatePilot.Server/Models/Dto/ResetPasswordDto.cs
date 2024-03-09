using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Dto
{
    public class ResetPasswordDto
    {
        [Required]
        public string Token { get; set; } = string.Empty;
        
        [Required]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]  
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}