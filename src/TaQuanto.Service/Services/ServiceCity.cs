using AutoMapper;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Service.Dtos.City;
using TaQuanto.Service.Dtos.State;
using TaQuanto.Service.Interfaces;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Service.Services
{
    public class ServiceCity : IServiceCity
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public ServiceCity(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<PagedList<ReadCityDto>> GetAllCityAsync(CityParameters parameters)
        {
            var cities = await _unityOfWork.RepositoryCity.GetAllCityAsync(parameters);

            return _mapper.Map<PagedList<ReadCityDto>>(cities);
        }

        public async Task<ReadCityDto> GetCityByIdAsync(Guid id)
        {
            var city = await _unityOfWork.RepositoryCity.GetByIdAsync(id);

            return _mapper.Map<ReadCityDto>(city);
        }
    }
}
