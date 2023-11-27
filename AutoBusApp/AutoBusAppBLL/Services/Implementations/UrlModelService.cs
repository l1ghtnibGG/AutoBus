using AutoBusAppBLL.DTOModels;
using AutoBusAppBLL.Exceptions;
using AutoBusAppBLL.Services.Interfaces;
using AutoBusAppDAL.Repositories.Interfaces;
using AutoMapper;
using DataAccessLayer.Models;

namespace AutoBusAppBLL.Services.Implementations
{
    public class UrlModelService : IUrlModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UrlModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public IQueryable GetAll => _unitOfWork.UrlRepositories.GetAll;

        public UrlModel AddUrl(UrlAddDto urlAddDto)
        {
            var url = _mapper.Map<UrlModel>(urlAddDto);

            url.ShortUrl = CreateShortUrl(url.LongUrl);

            url = _unitOfWork.UrlRepositories.AddUrl(url);

            return url ?? throw new ValidateException($"Wrong input");
        }

        public string CreateShortUrl(string longUrl)
        {
            var shortUrl = "https://" + longUrl.GetHashCode().ToString();

            if (_unitOfWork.UrlRepositories.GetAll.FirstOrDefault(x => x.ShortUrl == shortUrl && x.LongUrl != longUrl) != null)
                CreateShortUrl(longUrl);

            return shortUrl;
        }

        public UrlModel DeleteUrl(Guid id)
        {
            var url = _unitOfWork.UrlRepositories.DeleteUrl(id);

            return url ?? throw new ValidateException($"Url with certaitn id:{id} didn't found");
        }

        public UrlModel EditUrl(Guid id, UrlEditDto urlEditDto)
        {
            var url = _mapper.Map<UrlModel>(urlEditDto);

            url = _unitOfWork.UrlRepositories.EditUrl(id, url);

            return url ?? throw new ValidateException($"Wrong input");
        }

        public UrlModel GetById(Guid id)
        {
            var url =  _unitOfWork.UrlRepositories.GetById(id);

            return url ?? throw new ValidateException($"Url with certaitn id:{id} didn't found");
        }

        public UrlModel IncreaseVisitedCount(Guid id)
        {
            var url = GetById(id);

            url.ClickCount++;

            url = _unitOfWork.UrlRepositories.EditUrl(id, url);

            return url ?? throw new ValidateException($"Wrong input");
        }
    }
}
