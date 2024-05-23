using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Pagination;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryEstablishment : IRepositoryBase<Establishment>
    {
        Task<PagedList<Establishment>> GetAllEstablishmentAsync(EstablishmentParameters parameters);
    }
}
