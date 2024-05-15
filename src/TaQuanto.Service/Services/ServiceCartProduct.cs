using AutoMapper;
using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Service.Dtos.Cart;
using TaQuanto.Service.Dtos.CartProduct;
using TaQuanto.Service.Interfaces;
using TaQuanto.Service.Validations;

namespace TaQuanto.Service.Services
{
    public class ServiceCartProduct : IServiceCartProduct
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public ServiceCartProduct(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<ReadCartProductDto> AddCartProductAsync(CreateOrUpdateCartProductDto cp, ReadCartDto readCart)
        {
            await ValidateAsync(cp);

            var cartProduct = _mapper.Map<CartProduct>(cp);

            cartProduct.CartId = readCart.Id;
            var cartProductAdd = await _unityOfWork.RepositoryCartProduct.CreatAsync(cartProduct);
            await _unityOfWork.Commit();

            return _mapper.Map<ReadCartProductDto>(cartProductAdd);
        }

        public async Task UpdateCartProductAsync(CreateOrUpdateCartProductDto cp)
        {
            await ValidateAsync(cp);

            var cartProduct = _mapper.Map<CartProduct>(cp);

            _unityOfWork.RepositoryCartProduct.Update(cartProduct);
            await _unityOfWork.Commit();
        }

        public async Task DeleteCartProductAsync(ReadCartProductDto cp)
        {
            var cartProduct = _mapper.Map<CartProduct>(cp);
          
            _unityOfWork.RepositoryCartProduct.Delete(cartProduct);
            await _unityOfWork.Commit();
        }

        private async Task ValidateAsync(CreateOrUpdateCartProductDto cp)
        {
            var validator = new CartProductValidation();
            var resultado = await validator.ValidateAsync(cp);
            if (!resultado.IsValid)
            {
                //Lançar exception caso n seja valido 
            }
        }
    }
}
