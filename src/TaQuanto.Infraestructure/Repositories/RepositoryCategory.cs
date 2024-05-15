using Microsoft.EntityFrameworkCore;
using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryCategory : RepositoryBase<Category>, IRepositoryCategory
    {
        private readonly TaQuantoContext _context;

        public RepositoryCategory(TaQuantoContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
