using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryEstablishment : IRepositoryBase<Establishment>
    {
        Task<IEnumerable<Establishment>> GetAllEstablishmentByCityId(Guid id);
    }
}
