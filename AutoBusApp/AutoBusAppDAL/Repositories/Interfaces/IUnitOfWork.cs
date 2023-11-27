using DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBusAppDAL.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IUrlRepository UrlRepositories { get; }
    }
}
