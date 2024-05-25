using TaQuanto.Domain.Entities;
using TaQuanto.Service.Dtos.Establishment;
using TaQuanto.Domain.Pagination;
using Microsoft.AspNetCore.JsonPatch;

namespace TaQuanto.Service.Interfaces
{
    public interface IServiceEstablishment
    {
        Task<ReadEstablishmentDto> CreateEstablishmentAsync(CreateOrUpdateEstablishmentDto e);
        Task UpdateEstablishmentAsync(CreateOrUpdateEstablishmentDto e, Guid id);
        Task DeleteEstablishmentAsync(Guid id);
        Task<ReadEstablishmentDto> GetEstablishmentByIdAsync(Guid id);
        Task<PagedList<ReadEstablishmentDto>> GetAllEstablishmentAsync(EstablishmentParameters parameters);
        Task UpdatePatchEstablishmentAsync(JsonPatchDocument<CreateOrUpdateEstablishmentDto> dto, Guid id);
    }
}
