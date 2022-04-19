namespace SSGP.Application.Core.Pagination.Exceptions;

public class TotalPagesCountCannotBeLowerThanOneException : ApplicationException
{
    public TotalPagesCountCannotBeLowerThanOneException() 
        : base("Total pages count cannot be lower than 1.")
    {
    }
}