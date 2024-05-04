using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryEstablishment : RepositoryBase<Establishment>, IRepositoryEstablishment
    {
        public RepositoryEstablishment(TaQuantoContext context) : base(context)
        {
        }
    }
}
