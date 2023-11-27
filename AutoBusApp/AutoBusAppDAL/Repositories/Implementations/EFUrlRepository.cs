using DataAccessLayer.Context;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Implementations;

public class EFUrlRepository : IUrlRepository
{
    private readonly UrlDbContext _context;

    public EFUrlRepository(UrlDbContext context) => _context = context;

    IQueryable<UrlModel> IUrlRepository.GetAll => _context.UrlModels;

    public UrlModel? GetById(Guid id) =>
         _context.UrlModels.FirstOrDefault(x => x.Id == id);

    public UrlModel? AddUrl(UrlModel? urlModel)
    {
        if (urlModel == null)
            return null;

        _context.UrlModels.Add(urlModel);
        _context.SaveChanges();

        return urlModel;
    }

    public UrlModel? EditUrl(Guid id, UrlModel urlModel)
    {
        var url = _context.UrlModels.FirstOrDefault(x => x.Id == id);

        if (url == null)
            return null;

        _context.UrlModels.Update(urlModel);
        _context.SaveChanges();

        return url;
    }

    public UrlModel? DeleteUrl(Guid id)
    {
        var url = _context.UrlModels.FirstOrDefault(x => x.Id == id);

        if (url == null)
            return null;

        _context.Remove(url);
        _context.SaveChanges();

        return url;
    }
}