﻿using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AutoMapper;

namespace AnkaraLab_BackEnd.WebAPI.Configurations.Mapper
{
    public class LoyaltyProgramProfile : Profile

    {
        public LoyaltyProgramProfile()
        {
            CreateMap<LoyaltyProgram, LoyaltyProgramDto>();
        }
    }
}
