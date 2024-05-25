using TaQuanto.Service.Dtos.Category;
using TaQuanto.Domain.Pagination;
using Microsoft.AspNetCore.JsonPatch;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceCategory
    {
        Task<ReadCategoryDto> CreateCategoryAsync(CreateOrUpdateCategoryDto c);
        Task UpdateCategoryAsync(CreateOrUpdateCategoryDto c, Guid id);
        Task DeleteCategoryByIdAsync(Guid id);
        Task<ReadCategoryDto> GetCategoryByIdAsync(Guid id);
        Task<PagedList<ReadCategoryDto>> GetAllCategoriesAsync(CategoryParameters parameters);
        Task UpdatePatchCategoryAsync(JsonPatchDocument<CreateOrUpdateCategoryDto> dto, Guid id);
    }
}