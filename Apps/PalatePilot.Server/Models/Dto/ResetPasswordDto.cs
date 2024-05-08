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
        

        /// <summary>
        /// Email
        /// </summary>
        /// <example>makenzie.schiller51@ethereal.email</example>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match.")]  
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}