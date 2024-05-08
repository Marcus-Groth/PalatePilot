using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models
{
    public class LoginDto
    {
        /// <summary>
        /// Username
        /// </summary>
        /// <example>makenzie</example>
        [Required]
        public string UserName { get; set; } = string.Empty;
        
        /// <summary>
        /// Password
        /// </summary>
        /// <example>Passw0rd!</example>
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}