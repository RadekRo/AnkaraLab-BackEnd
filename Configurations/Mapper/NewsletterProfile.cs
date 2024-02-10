using AnkaraLab_BackEnd.WebAPI.Domain;
using AnkaraLab_BackEnd.WebAPI.DTOs;
using AutoMapper;

namespace AnkaraLab_BackEnd.WebAPI.Configurations.Mapper
{
    public class NewsletterProfile : Profile
    {
        public NewsletterProfile()
        {
            CreateMap<Newsletter, NewsletterDto>();
            CreateMap<NewsletterForCreationDto, Newsletter>();
        }
    }
}
