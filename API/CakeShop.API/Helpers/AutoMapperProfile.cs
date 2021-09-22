using AutoMapper;
using CakeShop.Application.DTOs;
using CakeShop.Domain.Models;

namespace CakeShop.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CakeDto, Cake>();
            CreateMap<Cake, CakeDto>();
        }
    }
}