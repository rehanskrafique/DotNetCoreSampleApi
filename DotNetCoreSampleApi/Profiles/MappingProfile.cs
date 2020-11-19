using AutoMapper;
using DotNetCoreSampleApi.Contracts;
using DotNetCoreSampleApi.Domains;

namespace DotNetCoreSampleApi.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, RegisterDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.LastModifiedBy)).ReverseMap();

            CreateMap<User, UserDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.UserId)).ReverseMap();

            CreateMap<Category, CategoryDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CategoryId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.LastModifiedBy)).ReverseMap();

            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.CreatedBy))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.LastModifiedBy)).ReverseMap();
        }
    }
}