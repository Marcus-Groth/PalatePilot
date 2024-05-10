using System;
using AutoMapper;
using PalatePilot.Server.Models;
using PalatePilot.Server.Models.Domains;
using PalatePilot.Server.Models.Dto;
using PalatePilot.Server.Models.Dto.Order;


namespace PalatePilot.Server
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<Food, FoodCreateDto>().ReverseMap();
            CreateMap<Food, FoodUpdateDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>().ReverseMap();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
        }
    }
}