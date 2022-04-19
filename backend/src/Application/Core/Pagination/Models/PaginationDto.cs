namespace SSGP.Application.Core.Pagination.Models;

public class PaginationDto<T>
{
    public int PageNumber { get; set; }
    public int TotalNumberOfPages { get; set; }
    public IEnumerable<T> Content { get; set; }
    public bool HasNextPage { get; set; }
}