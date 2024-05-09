using TaQuanto.Domain.Entities;

namespace TaQuanto.Infraestructure.Interface
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<T> CreatAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}