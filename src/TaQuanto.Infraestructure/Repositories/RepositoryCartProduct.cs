using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryCartProduct : RepositoryBase<CartProduct>, IRepositoryCartProduct
    {
        public RepositoryCartProduct(TaQuantoContext context) : base(context)
        {
        }
    }
}
