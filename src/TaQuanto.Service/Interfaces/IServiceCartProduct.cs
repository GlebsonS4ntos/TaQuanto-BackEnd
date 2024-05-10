using TaQuanto.Service.Dtos.Cart;
using TaQuanto.Service.Dtos.CartProduct;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceCartProduct
    {
        Task<ReadCartProductDto> AddCartProductAsync(CreateOrUpdateCartProductDto cp, ReadCartDto readCart);
        Task UpdateCartProductAsync(CreateOrUpdateCartProductDto cp);
        Task DeleteCartProductAsync(ReadCartProductDto cp);
    }
}
