using TaQuanto.Infraestructure.Interface;
using TaQuanto.Infraestructure.Repositories;

namespace TaQuanto.Infraestructure.Data.UnitOfWork
{
    public class UnitOfWork : IUnityOfWork
    {
        public readonly TaQuantoContext _context;

        private IRepositoryState? _repositoryState;
        private IRepositoryProduct? _repositoryProduct;
        private IRepositoryCity? _repositoryCity;
        private IRepositoryEstablishment? _repositoryEstablishment;

        public UnitOfWork(TaQuantoContext context)
        {
            _context = context;
        }

        public IRepositoryState RepositoryState 
        { 
            get 
            { 
                return _repositoryState = _repositoryState ?? new RepositoryState(_context);
            } 
        }

        public IRepositoryCity RepositoryCity
        {
            get
            {
                return _repositoryCity = _repositoryCity ?? new RepositoryCity(_context);
            }
        }

        public IRepositoryProduct RepositoryProduct
        {
            get
            {
                return _repositoryProduct = _repositoryProduct ?? new RepositoryProduct(_context);
            }
        }

        public IRepositoryEstablishment RepositoryEstablishment
        {
            get
            {
                return _repositoryEstablishment = _repositoryEstablishment ?? new RepositoryEstablishment(_context);
            }
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
