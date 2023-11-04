using AutoMapper;
using WebApi.Models;
using WebApi.Models.DTOs;

namespace WebApi.AutoMapperHelper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<ProductDto, Product>();
        CreateMap<CategoryDto, Category>();
    }
}