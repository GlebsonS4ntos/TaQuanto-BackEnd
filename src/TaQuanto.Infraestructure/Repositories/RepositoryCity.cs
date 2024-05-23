using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Pagination;
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

        public async Task<PagedList<City>> GetAllCityAsync(CityParameters parameters)
        {
            var items = await GetAllAsync();

            var citiesOrderByName = items.OrderBy(c => c.Name).AsQueryable();

            if (parameters.StateId != null)
            {
                citiesOrderByName = citiesOrderByName.Where(c => c.StateId == parameters.StateId);
            }

            return new PagedList<City>(citiesOrderByName.ToList()); 
        }
    }
}
