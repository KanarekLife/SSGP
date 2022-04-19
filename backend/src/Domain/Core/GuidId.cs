namespace SSGP.Domain.Core;

public abstract class GuidId : ValueObject
{
    private readonly Guid _value;

    protected GuidId(Guid value)
    {
        _value = value;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return _value;
    }

    public override string ToString()
    {
        return _value.ToString();
    }
}