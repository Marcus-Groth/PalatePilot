using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;

namespace PalatePilot.Server.Services.UserService
{
    public interface IUserService
    {
        Task Registration(RegistrationDto request);
        Task<UserDto> GetById(string id);
        Task<UserDto> GetCurrent(ClaimsPrincipal userPrincipal);
    }
}