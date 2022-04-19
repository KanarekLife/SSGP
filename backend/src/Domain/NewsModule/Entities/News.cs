using SSGP.Domain.Core;
using SSGP.Domain.NewsModule.ValueObjects;

namespace SSGP.Domain.NewsModule.Entities;

public class News : Entity
{
    public News(NewsId id, NewsTitle title, NewsContent content)
    {
        Id = id;
        Title = title;
        Content = content;
    }

    public NewsId Id { get; }
    public NewsTitle Title { get; private set; }
    public NewsContent Content { get; private set; }

    public void ChangeContent(NewsContent newContent)
    {
        Content = newContent;
    }

    public void ChangeTitle(NewsTitle newTitle)
    {
        Title = newTitle;
    }
}