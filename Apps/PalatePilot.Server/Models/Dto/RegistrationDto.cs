using System;
using System.ComponentModel.DataAnnotations;

namespace PalatePilot.Server.Models
{
    public class RegistrationDto
    {
        /// <summary>
        /// Username
        /// </summary>
        /// <example>makenzie</example>
        [Required]
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Email
        /// </summary>
        /// <example>makenzie.schiller51@ethereal.email</example>
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        
        /// <summary>
        /// Password
        /// </summary>
        /// <example>Passw0rd!</example>
        [Required]
        public string Password { get; set; } = string.Empty;        
    }
}