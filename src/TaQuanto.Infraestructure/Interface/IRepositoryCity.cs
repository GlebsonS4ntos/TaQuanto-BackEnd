using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryCity : IRepositoryBase<City>
    {
        Task<PagedList<City>> GetAllCityAsync(CityParameters parameters);
    }
}
