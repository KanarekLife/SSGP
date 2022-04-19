namespace SSGP.Application.Core.Pagination.Exceptions;

public class PageWithGivenNumberNotFoundException : ApplicationException
{
    public PageWithGivenNumberNotFoundException(int pageNumber) : base("Page with given number was not found.")
    {
        PageNumber = pageNumber;
    }
    
    public int PageNumber { get; }
}