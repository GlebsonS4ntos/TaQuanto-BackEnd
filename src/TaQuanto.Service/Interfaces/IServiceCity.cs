using TaQuanto.Service.Dtos.City;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceCity
    {
        Task<ReadCityDto> GetCityByIdAsync(Guid id);
        Task<IEnumerable<ReadCityDto>> GetAllCityAsync();
    }
}
