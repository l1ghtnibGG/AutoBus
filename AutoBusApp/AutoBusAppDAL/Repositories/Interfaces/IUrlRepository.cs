using DataAccessLayer.Models;

namespace DataAccessLayer.Repositories.Interfaces;

public interface IUrlRepository
{
    public IQueryable<UrlModel> GetAll { get; }

    public UrlModel? GetById(Guid id);

    public UrlModel? AddUrl(UrlModel urlModel);

    public UrlModel? EditUrl(Guid id, UrlModel urlModel);

    public UrlModel? DeleteUrl(Guid id);
}