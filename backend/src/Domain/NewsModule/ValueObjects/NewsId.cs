using SSGP.Domain.Core;

namespace SSGP.Domain.NewsModule.ValueObjects;

public class NewsId : GuidId
{
    private NewsId(Guid value) : base(value)
    {
    }

    public static NewsId New() => new(Guid.NewGuid());
    public static NewsId From(Guid guid) => new(guid);
    public Guid ToGuid() => Value;
}