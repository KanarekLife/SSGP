using SSGP.Domain.Core;
using SSGP.Domain.News.ValueObjects;

namespace SSGP.Domain.News.Entities;

public class News : Entity
{
    public News(NewsId id, NewsTitle title, NewsContent content, NewsSlug? slug = null)
    {
        Id = id;
        Title = title;
        Content = content;
        Slug = slug;
    }

    public NewsId Id { get; }
    public NewsTitle Title { get; private set; }
    public NewsContent Content { get; private set; }
    public NewsSlug? Slug { get; private set; }

    public void ChangeContent(NewsContent newContent)
    {
        Content = newContent;
    }

    public void ChangeTitle(NewsTitle newTitle)
    {
        Title = newTitle;
    }
}