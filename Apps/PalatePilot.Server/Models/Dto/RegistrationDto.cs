using System;
using System.ComponentModel.DataAnnotations;

namespace PalatePilot.Server.Models
{
    public class RegistrateDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Password { get; set; } = string.Empty;        
    }
}