using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryCity : RepositoryBase<City>, IRepositoryCity
    {
        public RepositoryCity(TaQuantoContext context) : base(context)
        {
        }
    }
}
