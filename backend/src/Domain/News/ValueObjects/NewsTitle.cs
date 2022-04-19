using SSGP.Domain.Core;

namespace SSGP.Domain.News.ValueObjects;

public class NewsTitle : ValueObject
{
    private readonly string _content;

    private NewsTitle(string content)
    {
        _content = content;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return _content;
    }

    public override string ToString()
    {
        return _content;
    }

    public static NewsTitle From(string title) => new(title);
}