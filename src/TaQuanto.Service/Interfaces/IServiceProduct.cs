using TaQuanto.Service.Dtos.Product;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceProduct
    {
        Task<ReadProductDto> CreateProdutoAsync(CreateOrUpdateProductDto p);
        Task UpdateProdutoAsync(CreateOrUpdateProductDto p, Guid id);
        Task DeleteProductByIdAsync(Guid id);
        Task<ReadProductDto> GetProductByIdAsync(Guid id);
        //Task<IEnumerable<ReadProductDto>> GetAllProductsByEstablishmentIdAsync(Guid id);
        //Task<IEnumerable<ReadProductDto>> GetAllProductsInPromotionByCityId(Guid id);
    }
}
