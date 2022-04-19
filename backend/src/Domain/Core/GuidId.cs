namespace SSGP.Domain.Core;

public abstract class GuidId : ValueObject
{
    protected readonly Guid Value;

    protected GuidId(Guid value)
    {
        Value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}