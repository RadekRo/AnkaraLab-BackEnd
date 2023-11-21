﻿using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AutoMapper;

namespace AnkaraLab_BackEnd.WebAPI.Configurations.Mapper
{
    public class ProductsProfile : Profile
    {
        public ProductsProfile() 
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
        }
    }
}
