using SSGP.Application.Core.Pagination.Exceptions;
using SSGP.Domain.Core;

namespace SSGP.Application.Core.Pagination;

public class PaginatedResult<T>
{
    private PaginatedResult(int currentPage, int pagesCount, IEnumerable<T> content)
    {
        Validate(currentPage, pagesCount);
        CurrentPage = currentPage;
        PagesCount = pagesCount;
        Content = content;
    }

    public int CurrentPage { get; }
    public int PagesCount { get; }
    public IEnumerable<T> Content { get; }
    public bool HasNextPage() => CurrentPage < PagesCount - 1;

    public static PaginatedResult<T> New(IEnumerable<T> content, int currentPage, int pagesCount)
        => new(currentPage, pagesCount, content);

    private void Validate(int currentPage, int pagesCount)
    {
        if (currentPage > pagesCount)
        {
            throw new CurrentPageCannotBeHigherThanPagesCountException();
        }

        if (currentPage < 0)
        {
            throw new CurrentPageCannotBeLowerThanZeroException();
        }

        if (pagesCount < 1)
        {
            throw new TotalPagesCountCannotBeLowerThanOneException();
        }
    }
}