using Microsoft.EntityFrameworkCore;
using TaQuanto.Domain.Entities;
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

        public async Task<IEnumerable<Establishment>> GetAllEstablishmentByCityId(Guid id)
        {
            return await _context.Establishments.Where(e => (e.CityId == id) && (e.IsDraft == false)).ToListAsync();
        }
    }
}
