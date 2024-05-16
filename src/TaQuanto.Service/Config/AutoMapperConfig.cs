using AutoMapper;
using TaQuanto.Domain.Entities;
using TaQuanto.Service.Dtos.Cart;
using TaQuanto.Service.Dtos.CartProduct;
using TaQuanto.Service.Dtos.Category;
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
                .ForMember(dto => dto.Price, opt => opt.MapFrom(p => p.Price))
                .ForMember(dto => dto.Description, opt => opt.MapFrom(p => p.Description))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(p => p.Name))
                .ForMember(dto => dto.ImageUrl, opt => opt.MapFrom(p => p.ImageUrl))
                .ForMember(dto => dto.EstablishmentId, opt => opt.MapFrom(p => p.EstablishmentId))
                .ForMember(dto => dto.CategoryId, opt => opt.MapFrom(p => p.CategoryId));

            CreateMap<CreateOrUpdateProductDto, Product>()
                .ForMember(p => p.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(p => p.OriginalPrice, opt => opt.MapFrom(dto => dto.OriginalPrice))
                .ForMember(p => p.Price, opt => opt.MapFrom(dto => dto.Price))
                .ForMember(p => p.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(p => p.EstablishmentId, opt => opt.MapFrom(dto => dto.EstablishmentId))
                .ForMember(p => p.Description, opt => opt.MapFrom(dto => dto.Description))
                .ForMember(p => p.CategoryId, opt => opt.MapFrom(dto => dto.CategoryId));

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
                .ForMember(dto => dto.CityId, opt => opt.MapFrom(e => e.CityId))
                .ForMember(dto => dto.Adress, opt => opt.MapFrom(e => e.Address))
                .ForMember(dto => dto.IsDraft, opt => opt.MapFrom(e => e.IsDraft));

            CreateMap<CreateOrUpdateEstablishmentDto, Establishment>()
                .ForMember(e => e.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(e => e.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(e => e.CityId, opt => opt.MapFrom(dto => dto.CityId))
                .ForMember(e => e.IsDraft, opt => opt.MapFrom(dto => dto.IsDraft))
                .ForMember(e => e.Address, opt => opt.MapFrom(dto => dto.Adress));

            CreateMap<CreateOrUpdateCategoryDto, Category>()
                .ForMember(c => c.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(c => c.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(c => c.ParentCategoriaId, opt => opt.MapFrom(dto => dto.ParentCategoriaId));

            CreateMap<Category, ReadCategoryDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(c => c.Name))
                .ForMember(dto => dto.ParentCategoriaId, opt => opt.MapFrom(c => c.ParentCategoriaId));

            CreateMap<CreateOrUpdateCartDto, Cart>()
                .ForMember(c => c.Id, opt => opt.MapFrom(dto => dto.Id));

            CreateMap<Cart, ReadCartDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(c => c.Id))
                .ForMember(dto => dto.ValueCart, opt => opt.MapFrom(c => c.ValueCart))
                .ForMember(dto => dto.CartProducts, opt => opt.MapFrom(c => c.CartProducts));

            CreateMap<CreateOrUpdateCartProductDto, CartProduct>()
                .ForMember(cp => cp.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(cp => cp.CartId, opt => opt.MapFrom(dto => dto.CartId))
                .ForMember(cp => cp.ProductId, opt => opt.MapFrom(dto => dto.ProductId))
                .ForMember(cp => cp.Quantity, opt => opt.MapFrom(dto => dto.Quantity));

            CreateMap<CartProduct, ReadCartProductDto>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(cp => cp.Id))
                .ForMember(dto => dto.ProductId, opt => opt.MapFrom(cp => cp.ProductId))
                .ForMember(dto => dto.Product, opt => opt.MapFrom(cp => cp.Product))
                .ForMember(dto => dto.CartId, opt => opt.MapFrom(cp => cp.CartId))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(cp => cp.Quantity));
        }
    }
}
