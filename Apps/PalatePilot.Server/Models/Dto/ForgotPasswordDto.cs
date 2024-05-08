using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PalatePilot.Server.Models.Dto
{
    public class ForgotPasswordDto
    {
        /// <summary>
        /// Email
        /// </summary>
        /// <example>makenzie.schiller51@ethereal.email</example>
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}