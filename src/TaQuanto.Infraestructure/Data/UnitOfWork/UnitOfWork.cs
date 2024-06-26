﻿using TaQuanto.Infraestructure.Interface;
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
        private IRepositoryCart? _repositoryCart;
        private IRepositoryCategory? _repositoryCategory;
        private IRepositoryCartProduct? _repositoryCartProduct;

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

        public IRepositoryCategory RepositoryCategory
        {
            get
            {
                return _repositoryCategory = _repositoryCategory ?? new RepositoryCategory(_context);
            }
        }

        public IRepositoryCart RepositoryCart
        {
            get
            {
                return _repositoryCart = _repositoryCart ?? new RepositoryCart(_context);
            }
        }

        public IRepositoryCartProduct RepositoryCartProduct
        {
            get
            {
                return _repositoryCartProduct = _repositoryCartProduct ?? new RepositoryCartProduct(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
