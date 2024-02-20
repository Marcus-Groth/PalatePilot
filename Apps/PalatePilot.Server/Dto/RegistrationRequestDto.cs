using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models
{
    public class RegistrationRequestDto
    {
        public string UserName { get; set; } = string.Empty;        
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;        
    }
}