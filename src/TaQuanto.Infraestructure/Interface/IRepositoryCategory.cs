using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryCategory : IRepositoryBase<Category>
    {
        Task<IEnumerable<Category>> GetAllSubCategoriesByCategoryIdAsync(Guid id);
    }
}
