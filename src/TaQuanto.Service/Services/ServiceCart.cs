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
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public ServiceCart(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<ReadCartDto> CreateCartAsync(CreateOrUpdateCartDto c)
        {
            await ValidateAsync(c);

            var cart = _mapper.Map<Cart>(c);
            cart.ValueCart = await CalculateTotalCartValueAsync(c.CartProducts);
            
            var cartCreated = await _unityOfWork.RepositoryCart.CreatAsync(cart);
            await _unityOfWork.Commit();

            return _mapper.Map<ReadCartDto>(cartCreated);
        }

        public async Task DeleteCarttByIdAsync(Guid id)
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
            else if(await _unityOfWork.RepositoryCart.GetByIdAsync(id) != null)
            {
                var cart = _mapper.Map<Cart>(c);
                cart.ValueCart = await CalculateTotalCartValueAsync(c.CartProducts);

                _unityOfWork.RepositoryCart.Update(cart);
                await _unityOfWork.Commit();
            }
        }

        private async Task<decimal> CalculateTotalCartValueAsync(IEnumerable<CreateOrUpdateCartProductDto> itens)
        {
            var total = 0m;

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
