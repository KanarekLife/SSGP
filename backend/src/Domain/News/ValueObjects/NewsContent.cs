using SSGP.Domain.Core;

namespace SSGP.Domain.News.ValueObjects;

public class NewsContent : ValueObject
{
    private readonly string _content;

    private NewsContent(string content)
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

    public static NewsContent From(string content) => new(content);
}