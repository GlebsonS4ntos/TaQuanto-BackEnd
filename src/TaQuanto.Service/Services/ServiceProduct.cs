using AutoMapper;
using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Service.Dtos.Product;
using TaQuanto.Service.Interfaces;
using TaQuanto.Service.Validations;

namespace TaQuanto.Service.Services
{
    public class ServiceProduct : IServiceProduct
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly IServicePhoto _photo;

        public ServiceProduct(IUnityOfWork unityOfWork, IMapper mapper, IServicePhoto photo)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _photo = photo;
        }

        public async Task<ReadProductDto> CreateProdutoAsync(CreateOrUpdateProductDto p)
        {
            await ValidateAsync(p);

            var product = _mapper.Map<Product>(p);
            var result = await _photo.AddPhoto(p.Image);
            product.ImagePublicId = result.PublicId;
            product.ImageUrl = result.SecureUrl.AbsoluteUri;

            var productAdd = await _unityOfWork.RepositoryProduct.CreatAsync(product);
            await _unityOfWork.Commit();

            return _mapper.Map<ReadProductDto>(productAdd);
        }

        public async Task DeleteProductByIdAsync(Guid id)
        {
            var product = await _unityOfWork.RepositoryProduct.GetByIdAsync(id);
            await _photo.DeletePhoto(product.ImagePublicId);
            _unityOfWork.RepositoryProduct.Delete(product);

            await _unityOfWork.Commit();
        }

        public async Task<IEnumerable<ReadProductDto>> GetAllProductsAsync()
        {
            var products = await _unityOfWork.RepositoryProduct.GetAllAsync();

            return _mapper.Map<IEnumerable<ReadProductDto>>(products);
        }

        public async Task<ReadProductDto> GetProductByIdAsync(Guid id) 
        {
            var product = await _unityOfWork.RepositoryProduct.GetByIdAsync(id);

            return _mapper.Map<ReadProductDto>(product);
        }

        public async Task UpdateProdutoAsync(CreateOrUpdateProductDto p, Guid id)
        {
            await ValidateAsync(p);

            if (p.Id != id)
            {
                //Lançar exception de Id do Product diferente do id vindo do Header
            }

            var productCurrent = await _unityOfWork.RepositoryProduct.GetByIdAsync(id);

            productCurrent.Description = p.Description;
            productCurrent.OriginalPrice = p.OriginalPrice;
            productCurrent.Price = p.Price;
            productCurrent.CategoryId = p.CategoryId;
            productCurrent.EstablishmentId = p.EstablishmentId;

            if (p.Image != null)
            {
                await _photo.DeletePhoto(productCurrent.ImagePublicId);
                var result = await _photo.AddPhoto(p.Image);

                productCurrent.ImageUrl = result.SecureUrl.AbsoluteUri;
                productCurrent.ImagePublicId = result.PublicId;
            }

            _unityOfWork.RepositoryProduct.Update(productCurrent);
            await _unityOfWork.Commit();
        }

        private async Task ValidateAsync(CreateOrUpdateProductDto dto)
        {
            var validator = new ProductValidation();
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                //Lançar exception caso n seja valido 
            }
        }
    }
}
