using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AutoMapper;

namespace AnkaraLab_BackEnd.WebAPI.Configurations.Mapper
{
    public class BasketProfile : Profile
    {
        public BasketProfile()
        {
            CreateMap<Basket, BasketDto>();
            CreateMap<BasketForCreationDto, Basket>();
        }
    }
}
