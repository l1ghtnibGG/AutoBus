using AutoBusAppDAL.Repositories.Interfaces;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories.Implementations;
using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBusAppDAL.Repositories.Implementations
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly UrlDbContext _context;
        private EFUrlRepository _urlRepository;
        private bool _isDisposed;

        public EFUnitOfWork(UrlDbContext context) => 
            _context = context;

        public IUrlRepository UrlRepositories => 
            _urlRepository ??= new EFUrlRepository(_context);

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
                return;

            if (disposing)
                _context.Dispose();

            _isDisposed = true;
        }
    }
}
