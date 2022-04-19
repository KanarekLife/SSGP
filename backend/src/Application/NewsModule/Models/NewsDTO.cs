using SSGP.Domain.NewsModule.Entities;

namespace SSGP.Application.NewsModule.Models;

public class NewsDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public static NewsDto From(News news)
    {
        return new NewsDto
        {
            Id = news.Id.ToGuid(),
            Title = news.Title.ToString(),
            Content = news.Content.ToString()
        };
    }
}