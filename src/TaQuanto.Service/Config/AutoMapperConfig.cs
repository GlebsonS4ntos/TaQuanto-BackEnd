using AutoMapper;
using TaQuanto.Domain.Entities;
using TaQuanto.Service.Dtos.City;
using TaQuanto.Service.Dtos.Establishment;
using TaQuanto.Service.Dtos.Product;
using TaQuanto.Service.Dtos.State;

namespace TaQuanto.Service.Config
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Product, ReadProductDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(p => p.Id))
                .ForMember(dto => dto.OriginalPrice, opt => opt.MapFrom(p => p.OriginalPrice))
                .ForMember(dto => dto.NewPrice, opt => opt.MapFrom(p => p.NewPrice))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(p => p.Description))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(dto => dto.ImageUrl, opt => opt.MapFrom(p => p.ImageUrl));

            CreateMap<CreateOrUpdateProductDto, Product>()
                .ForMember(p => p.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(p => p.OriginalPrice, opt => opt.MapFrom(dto => dto.OriginalPrice))
                .ForMember(p => p.NewPrice, opt => opt.MapFrom(dto => dto.NewPrice))
                .ForMember(p => p.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(p => p.EstablishmentId, opt => opt.MapFrom(dto => dto.EstablishmentId))
                .ForMember(p => p.Description, opt => opt.MapFrom(dto => dto.Description));

            CreateMap<City, ReadCityDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(dto => dto.StateId, opt => opt.MapFrom(c => c.StateId));

            CreateMap<State, ReadStateDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(s => s.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(dto => dto.UF, opt => opt.MapFrom(s => s.UF))
                .ForMember(dto => dto.Cities, opt => opt.MapFrom(s => s.Cities));

            CreateMap<Establishment, ReadEstablishmentDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(e => e.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(e => e.Name))
                .ForMember(dto => dto.ImageUrl, opt => opt.MapFrom(e => e.ImageUrl))
                .ForMember(dto => dto.ImageBannerUrl, opt => opt.MapFrom(e => e.ImageBannerUrl))
                .ForMember(dto => dto.Biography, opt => opt.MapFrom(e => e.Biography))
                .ForMember(dto => dto.CityId, opt => opt.MapFrom(e => e.CityId))
                .ForMember(dto => dto.City, opt => opt.MapFrom(e => e.City));

            CreateMap<CreateOrUpdateEstablishmentDto, Establishment>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(e => e.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(e => e.Biography, opt => opt.MapFrom(dto => dto.Biography))
                .ForMember(e => e.CityId, opt => opt.MapFrom(dto => dto.CityId));
        }
    }
}
