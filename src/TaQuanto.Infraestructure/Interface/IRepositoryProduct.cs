using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryProduct : IRepositoryBase<Product>
    {
        Task<PagedList<Product>> GetAllProductsAsync(ProductParameters parameters);
    }
}
