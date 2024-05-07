using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryProduct : IRepositoryBase<Product>
    {
        Task<IEnumerable<Product>> GetAllProductsByEstablishmentIdAsync(Guid id);
        Task<IEnumerable<Product>> GetAllProductsInPromotionByCityId(Guid id);
    }
}
