using Microsoft.EntityFrameworkCore;
using SSGP.Application.Core.Pagination;
using SSGP.Application.Core.Pagination.Exceptions;
using SSGP.Application.NewsModule.Exceptions;
using SSGP.Application.NewsModule.Repositories;
using SSGP.Domain.NewsModule.Entities;
using SSGP.Domain.NewsModule.ValueObjects;
using SSGP.Infrastructure.Data;

namespace SSGP.Infrastructure.NewsModule;

public class NewsRepository : INewsRepository
{
    private readonly ApplicationDbContext _context;

    public NewsRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<News> GetById(NewsId id)
    {
        var guid = id.ToGuid();
        var results = await _context.News!.Where(x => x.Id == guid).ToArrayAsync();
        if (results.Length == 0)
        {
            throw new NewsWithGivenIdNotFoundException(id);
        }
        return ToNews(results[0]);
    }

    public async Task<PaginatedResult<News>> GetLatest(int page = 0, int numberOfItems = 50)
    {
        var results = await _context.News!
            .Skip(numberOfItems * page)
            .Take(numberOfItems)
            .ToArrayAsync();
        var totalNumberOfItems = await _context.News!
            .CountAsync();
        var totalNumberOfPages = Convert.ToInt32(Math.Ceiling((double)totalNumberOfItems / (double)numberOfItems));
        if (results.Length == 0)
        {
            throw new PageWithGivenNumberNotFoundException(page);
        }
        return PaginatedResult<News>.New(results.Select(ToNews), page, totalNumberOfPages);
    }

    public async Task Add(News news)
    {
        var databaseModel = new DatabaseModels.News()
        {
            Id = news.Id.ToGuid(),
            Title = news.Title.ToString(),
            Content = news.Content.ToString()
        };
        await _context.News!.AddAsync(databaseModel);
    }

    public Task Remove(News news)
    {
        _context.News!.Remove(ToDatabaseModel(news));
        return Task.CompletedTask;
    }

    public async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    private static News ToNews(DatabaseModels.News news)
    {
        var title = NewsTitle.From(news.Title);
        var content = NewsContent.From(news.Content);
        var id = NewsId.From(news.Id);
        return new News(id, title, content);
    }

    private static DatabaseModels.News ToDatabaseModel(News news)
    {
        return new DatabaseModels.News()
        {
            Id = news.Id.ToGuid(),
            Title = news.Title.ToString(),
            Content = news.Content.ToString()
        };
    }
}