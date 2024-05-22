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
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Cart, CartDto>().ReverseMap();
            CreateMap<CartItem, CartItemDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Food.Name))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Food.Price))
                .ReverseMap();
            
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<ShippingAddress, ShippingAddressDto>().ReverseMap();
        }
    }
}