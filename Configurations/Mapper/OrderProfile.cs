using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AutoMapper;

namespace AnkaraLab_BackEnd.WebAPI.Configurations.Mapper
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderForCreationDto, Order>();
        }
    }
}
