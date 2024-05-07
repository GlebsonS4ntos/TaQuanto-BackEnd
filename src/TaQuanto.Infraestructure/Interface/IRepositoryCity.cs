using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryCity : IRepositoryBase<City>
    {
        Task<List<City>> GetAllCityByStateIdAsync(Guid id);
    }
}
