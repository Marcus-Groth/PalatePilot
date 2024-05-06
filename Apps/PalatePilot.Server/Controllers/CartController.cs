using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalatePilot.Server.Data.Contexts;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;

namespace PalatePilot.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly PalatePilotDbContext _context;
        private readonly IMapper _mapper;
        
        public CartController(PalatePilotDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    }
}