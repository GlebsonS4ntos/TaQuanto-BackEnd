using TaQuanto.Service.Dtos.Category;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceCategory
    {
        Task<ReadCategoryDto> CreateCategoryAsync(CreateOrUpdateCategoryDto c);
        Task UpdateCategoryAsync(CreateOrUpdateCategoryDto c, Guid id);
        Task DeleteCategoryByIdAsync(Guid id);
        Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id);
        Task<IEnumerable<ReadCategoryDto>> GetAllCategoriesAsync(Guid id);
        Task<IEnumerable<ReadCategoryDto>> GetAllSubCategoriesByCategoryId(Guid id);
    }
}