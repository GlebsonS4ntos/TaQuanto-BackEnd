using Microsoft.EntityFrameworkCore;
using TaQuanto.Domain.Entities;
using TaQuanto.Domain.Exception;
using TaQuanto.Infraestructure.Data;
using TaQuanto.Infraestructure.Interface;

namespace TaQuanto.Infraestructure.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        private readonly TaQuantoContext _context;

        public RepositoryBase(TaQuantoContext context)
        {
            _context = context;
        }

        public async Task<T> CreatAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Delete(T entity)
        {
                _context.Set<T>().Remove(entity);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException("Não foi encontrado.");
            }
            return entity; 
        }

        public void Update(T entity)
        {
            _context.Update(entity);
        }
    }
}
