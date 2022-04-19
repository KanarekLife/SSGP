using SSGP.Domain.Core;

namespace SSGP.Domain.News.ValueObjects;

public class NewsSlug : ValueObject
{
    private readonly string _slug;

    private NewsSlug(string slug)
    {
        _slug = slug;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return _slug;
    }

    public override string ToString()
    {
        return _slug;
    }

    public static NewsSlug From(string slug) => new(slug);
}