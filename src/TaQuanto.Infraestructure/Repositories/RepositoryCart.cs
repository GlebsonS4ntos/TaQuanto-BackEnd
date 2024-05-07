using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryCart : RepositoryBase<Cart>, IRepositoryCart
    {
        public RepositoryCart(TaQuantoContext context) : base(context)
        {
        }
    }
}
