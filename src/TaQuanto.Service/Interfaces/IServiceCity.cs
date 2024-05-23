using TaQuanto.Service.Dtos.City;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceCity
    {
        Task<ReadCityDto> GetCityByIdAsync(Guid id);
        Task<PagedList<ReadCityDto>> GetAllCityAsync(CityParameters parameters);
    }
}
