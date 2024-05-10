using AutoMapper;
using TaQuanto.Infraestructure.Interface;
using TaQuanto.Service.Dtos.State;
using TaQuanto.Service.Interfaces;

namespace TaQuanto.Service.Services
{
    public class ServiceState : IServiceState
    {
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;

        public ServiceState(IUnityOfWork unityOfWork, IMapper mapper)
        {
            _unityOfWork = unityOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReadStateDto>> GetAllStateAsync()
        {
            var states = await _unityOfWork.RepositoryState.GetAllAsync();

            return _mapper.Map<IEnumerable<ReadStateDto>>(states);
        }

        public async Task<ReadStateDto> GetStateByIdAsync(Guid id)
        {
            var state = await _unityOfWork.RepositoryState.GetByIdAsync(id);

            return _mapper.Map<ReadStateDto>(state);
        }
    }
}
