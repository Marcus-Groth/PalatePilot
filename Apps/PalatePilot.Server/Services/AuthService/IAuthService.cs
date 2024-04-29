using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.Data;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Dto; // Add missing import statements for LoginDto and RegistrationDto

namespace PalatePilot.Server.Services
{
    public interface IAuthService
    {
        Task<string> Login(LoginDto request);
        Task EmailConfirmation(string token, string email);
        Task ForgotPassword(ForgotPasswordDto forgotPasswordDto);
        Task ResetPassword(ResetPasswordDto resetPasswordDto);
    }
}