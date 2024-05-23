using TaQuanto.Service.Dtos.Category;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceCategory
    {
        Task<ReadCategoryDto> CreateCategoryAsync(CreateOrUpdateCategoryDto c);
        Task UpdateCategoryAsync(CreateOrUpdateCategoryDto c, Guid id);
        Task DeleteCategoryByIdAsync(Guid id);
        Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id);
        Task<PagedList<ReadCategoryDto>> GetAllCategoriesAsync(CategoryParameters parameters);
    }
}