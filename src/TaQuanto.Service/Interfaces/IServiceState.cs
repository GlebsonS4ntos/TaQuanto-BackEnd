using TaQuanto.Service.Dtos.State;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceState
    {
        Task<ReadStateDto> GetStateByIdAsync(Guid id);
        Task<IEnumerable<ReadStateDto>> GetAllStateAsync();
    }
}
