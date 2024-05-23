using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryCategory : RepositoryBase<Category>, IRepositoryCategory
    {
        private readonly TaQuantoContext _context;

        public RepositoryCategory(TaQuantoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Category>> GetAllCategoriesAsync(CategoryParameters parameters)
        {
            var categories = await GetAllAsync();

            var categoriesOrderByName = categories.OrderBy(c => c.Name).AsQueryable();

            if (parameters.CategoryId != null)
            {
                categoriesOrderByName = categoriesOrderByName.Where(c => c.ParentCategoriaId == parameters.CategoryId);
            }

            return new PagedList<Category>(categoriesOrderByName.ToList()); 
        }
    }
}
