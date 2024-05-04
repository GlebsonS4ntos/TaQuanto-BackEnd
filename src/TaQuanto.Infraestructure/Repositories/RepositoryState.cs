using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryState : RepositoryBase<State>, IRepositoryState
    {
        public RepositoryState(TaQuantoContext context) : base(context)
        {
        }
    }
}
