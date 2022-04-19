namespace SSGP.Application.Core;

public abstract class ApplicationException : Exception
{
    protected ApplicationException(string message) : base(message)
    {
        
    }

    public virtual IEnumerable<KeyValuePair<string, object?>> Extensions()
        => ArraySegment<KeyValuePair<string, object?>>.Empty;

    public virtual int StatusCode => 400;
}