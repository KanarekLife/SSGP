namespace SSGP.Application.Core.Pagination.Exceptions;

public class CurrentPageCannotBeLowerThanZeroException : ApplicationException
{
    public CurrentPageCannotBeLowerThanZeroException() : base("Current page cannot be lower than 0.")
    {
    }
}