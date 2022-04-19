using SSGP.Application.Core.Pagination;
using SSGP.Domain.NewsModule.Entities;
using SSGP.Domain.NewsModule.ValueObjects;

namespace SSGP.Application.NewsModule.Repositories;

public interface INewsRepository
{
    Task<News> GetById(NewsId id);
    Task<PaginatedResult<News>> GetLatest(int page = 0, int numberOfItems = 50);
    Task Add(News news);
    Task Remove(News news);
    Task SaveChanges();
}