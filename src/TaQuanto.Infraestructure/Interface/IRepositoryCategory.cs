using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryCategory : IRepositoryBase<Category>
    {
        Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters parameters);
    }
}
