using AutoMapper;
using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Service.Dtos.Cart;
using TaQuanto.Service.Dtos.CartProduct;
using TaQuanto.Service.Interfaces;
using TaQuanto.Service.Validations;

namespace TaQuanto.Service.Services
{
    public class ServiceCart : IServiceCart
    {
        private readonly IServiceCartProduct _serviceCartProduct;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public ServiceCart(IUnityOfWork unityOfWork, IMapper mapper, IServiceCartProduct serviceCartProduct)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _serviceCartProduct = serviceCartProduct;
        }

        public async Task<ReadCartDto> CreateCartAsync(CreateOrUpdateCartDto c)
        {
            await ValidateAsync(c);

            var cart = _mapper.Map<Cart>(c);
            cart.ValueCart = await CalculateTotalCartValueAsync(c.CartProducts);
            
            var cartCreated = await _unityOfWork.RepositoryCart.CreatAsync(cart);

            var cartDto = _mapper.Map<ReadCartDto>(cartCreated);

            await _unityOfWork.Commit();

            return cartDto;
        }

        public async Task DeleteCartByIdAsync(Guid id)
        {
            var cart = await _unityOfWork.RepositoryCart.GetByIdAsync(id);

            _unityOfWork.RepositoryCart.Delete(cart);
            await _unityOfWork.Commit();
        }

        public async Task<ReadCartDto> GetCartByIdAsync(Guid id)
        {
            var cart = await _unityOfWork.RepositoryCart.GetByIdAsync(id);

            return _mapper.Map<ReadCartDto>(cart);
        }

        public Task<ReadCartDto> GetCartByUserIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateCartAsync(CreateOrUpdateCartDto c, Guid id)
        {
            await ValidateAsync(c);

            if (id != c.Id)
            {
                //Lançar exception de Id do Cart diferente do id vindo do Header
            } 

            var cartCurrent = await _unityOfWork.RepositoryCart.GetByIdAsync(id);

            cartCurrent.ValueCart = await CalculateTotalCartValueAsync(c.CartProducts);
            cartCurrent.CartProducts = _mapper.Map<IEnumerable<CartProduct>>(c.CartProducts);

            _unityOfWork.RepositoryCart.Update(cartCurrent);
            
            foreach (var cartProduct in cartCurrent.CartProducts)
            {
                var existCartProduct = c.CartProducts.Where(cp => cp.Id == cartProduct.Id).Count() == 0;

                if (existCartProduct)
                {
                    await _serviceCartProduct.DeleteCartProductAsync(cartProduct.Id);
                }
            }
            await _unityOfWork.Commit();
        }

        private async Task<decimal?> CalculateTotalCartValueAsync(IEnumerable<CreateOrUpdateCartProductDto> itens)
        {
            decimal? total = 0m;

            foreach (var item in itens)
            {
                var product = await _unityOfWork.RepositoryProduct.GetByIdAsync(item.ProductId);
                total += item.Quantity * product.Price;
            }  

            return total;
        }

        private async Task ValidateAsync(CreateOrUpdateCartDto cart)
        {
            var validate = new CartValidation();
            var result = await validate.ValidateAsync(cart);
            if (!result.IsValid)
            {
                //Lançar exception caso n seja valido 
            }
        }
    }
}
