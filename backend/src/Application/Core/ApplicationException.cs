namespace SSGP.Application.Core;

public abstract class ApplicationException : Exception
{
    protected ApplicationException( string message) : base(message)
    {
        
    }
}