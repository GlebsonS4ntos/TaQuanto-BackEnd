using Microsoft.EntityFrameworkCore;
using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Pagination;
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

        public async Task<PagedList<Product>> GetAllProductsAsync(ProductParameters parameters)
        {
            var items = await GetAllAsync();

            var productsOrderByName = items.OrderBy(p => p.Name).AsQueryable();

            if (parameters.CategoryId != null)
            {
                productsOrderByName = productsOrderByName.Where(p => p.CategoryId == parameters.CategoryId);
            }

            if (parameters.EstablishmentId != null)
            {
                productsOrderByName = productsOrderByName.Where(p => p.EstablishmentId == parameters.EstablishmentId);
            }

            if (parameters.OnSale == true)
            {
                productsOrderByName = productsOrderByName.Where(p => p.OriginalPrice != null);
            }

            if (parameters.Name != null)
            {
                productsOrderByName = productsOrderByName.Where(p => p.Name.ToLowerInvariant().Contains(parameters.Name.ToLowerInvariant()));
            }

            return PagedList<Product>.ToPagedList(productsOrderByName, parameters.PageSize, parameters.PageNumber);
        }
    }
}
