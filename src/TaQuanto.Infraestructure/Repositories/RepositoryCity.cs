using Microsoft.EntityFrameworkCore;
using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryCity : RepositoryBase<City>, IRepositoryCity
    {
        private readonly TaQuantoContext _context;

        public RepositoryCity(TaQuantoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllCityByStateIdAsync(Guid id)
        {
            return await _context.Citys.Where(c => c.StateId == id).ToListAsync();
        }
    }
}
