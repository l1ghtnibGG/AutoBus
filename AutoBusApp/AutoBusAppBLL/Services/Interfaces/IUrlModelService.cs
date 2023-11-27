using AutoBusAppBLL.DTOModels;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoBusAppBLL.Services.Interfaces
{
    public interface IUrlModelService
    {
        public IQueryable GetAll { get; }
        public UrlModel GetById(Guid id);

        public UrlModel AddUrl(UrlAddDto urlModel);

        public UrlModel EditUrl(Guid id, UrlEditDto urlModel);

        public UrlModel DeleteUrl(Guid id);

        public string CreateShortUrl(string longUrl);

        public UrlModel IncreaseVisitedCount(Guid id);
    }
}
