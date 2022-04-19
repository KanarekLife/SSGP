namespace SSGP.Domain.Core;

public abstract class DomainException : Exception
{
    protected DomainException(string message) : base(message)
    {
        
    }
}