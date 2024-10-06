using AutoMapper;
using Logic.Models.DTOs;
using Logic.Models.Entities;

namespace Logic.Mappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price / 100));

        CreateMap<ProductUpdateDto, Product>()
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price * 100));
    }    
}
