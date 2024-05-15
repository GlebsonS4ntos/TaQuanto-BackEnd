using TaQuanto.Service.Dtos.Cart;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceCart
    {
        Task<ReadCartDto> CreateCartAsync(CreateOrUpdateCartDto c);
        Task UpdateCartAsync(CreateOrUpdateCartDto c, Guid id);
        Task DeleteCartByIdAsync(Guid id);
        Task<ReadCartDto> GetCartByIdAsync(Guid id);
        Task<ReadCartDto> GetCartByUserIdAsync(Guid id);
    }
}