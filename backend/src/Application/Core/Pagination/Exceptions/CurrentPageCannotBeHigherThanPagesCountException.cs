namespace SSGP.Application.Core.Pagination.Exceptions;

public class CurrentPageCannotBeHigherThanPagesCountException : ApplicationException
{
    public CurrentPageCannotBeHigherThanPagesCountException() 
        : base("Current page cannot be higher than number of pages.")
    {
    }
}