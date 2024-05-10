using Microsoft.EntityFrameworkCore;
using TaQuanto.Domain.Entities;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryProduct : RepositoryBase<Product>, IRepositoryProduct
    {
        private readonly TaQuantoContext _context;

        public RepositoryProduct(TaQuantoContext context) : base(context)
        {
            _context = context;
        }
    }
}
