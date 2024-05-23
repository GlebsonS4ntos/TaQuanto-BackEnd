using Microsoft.EntityFrameworkCore;
using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Pagination;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryEstablishment : RepositoryBase<Establishment>, IRepositoryEstablishment
    {
        private readonly TaQuantoContext _context;

        public RepositoryEstablishment(TaQuantoContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<Establishment>> GetAllEstablishmentAsync(EstablishmentParameters parameters)
        {
            var items = await GetAllAsync();

            var establishmentsOrderByName = items.OrderBy(e => e.Name).AsQueryable();

            if (parameters.IsDraft != null)
            {
                establishmentsOrderByName = establishmentsOrderByName.Where(e => e.IsDraft == parameters.IsDraft);
            }

            if (parameters.Name != null)
            {
                establishmentsOrderByName = establishmentsOrderByName.Where(e => e.Name.ToLowerInvariant().Contains(parameters.Name.ToLowerInvariant()));
            }

            if (parameters.CityId != null)
            {
                establishmentsOrderByName = establishmentsOrderByName.Where(e => e.CityId == parameters.CityId);
            }

            return PagedList<Establishment>.ToPagedList(establishmentsOrderByName, parameters.PageSize, parameters.PageNumber);
        }
    }
}
