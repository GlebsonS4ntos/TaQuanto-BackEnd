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

        public async Task<IEnumerable<Product>> GetAllProductsByEstablishmentIdAsync(Guid id)
        {
            return await _context.Products.Where(p => p.EstablishmentId == id).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsInPromotionByCityId(Guid id)
        {
            return await _context.Products.Where(p => (p.Establishment.CityId == id) && (p.Price < p.OriginalPrice)).ToListAsync();
        }
    }
}
