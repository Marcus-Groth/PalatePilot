using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PalatePilot.Server.Models;

namespace PalatePilot.Server.Services.UserService
{
    public interface IUserService
    {
         Task Registration(RegistrationDto request);
    }
}