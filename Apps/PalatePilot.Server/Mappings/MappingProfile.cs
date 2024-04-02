using System;
using AutoMapper;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;


namespace PalatePilot.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<Food, FoodCreateDto>().ReverseMap();
            CreateMap<Food, FoodUpdateDto>().ReverseMap();
        }
    }
}