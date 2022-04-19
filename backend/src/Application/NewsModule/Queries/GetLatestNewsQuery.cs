using FluentValidation;
using MediatR;
using SSGP.Application.Core.Pagination.Models;
using SSGP.Application.NewsModule.Models;
using SSGP.Application.NewsModule.Repositories;

namespace SSGP.Application.NewsModule.Queries;

public class GetLatestNewsQuery : IRequest<PaginationDto<NewsDto>>
{
    public int PageNumber { get; set; } = 0;
    public int NumberOfItemsPerPage { get; set; } = 50;
}

public class GetLatestNewsQueryValidator : AbstractValidator<GetLatestNewsQuery>
{
    public GetLatestNewsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(0);
        RuleFor(x => x.NumberOfItemsPerPage)
            .GreaterThanOrEqualTo(25)
            .LessThanOrEqualTo(100);
    }
}

public class GetLatestNewsQueryHandler : IRequestHandler<GetLatestNewsQuery, PaginationDto<NewsDto>>
{
    private readonly INewsRepository _repository;

    public GetLatestNewsQueryHandler(INewsRepository repository)
    {
        _repository = repository;
    }

    public async Task<PaginationDto<NewsDto>> Handle(GetLatestNewsQuery request, CancellationToken cancellationToken)
    {
        var result = await _repository.GetLatest(request.PageNumber, request.NumberOfItemsPerPage);
        return new PaginationDto<NewsDto>
        {
            Content = result.Content.Select(NewsDto.From),
            HasNextPage = result.HasNextPage(),
            PageNumber = result.CurrentPage,
            TotalNumberOfPages = result.PagesCount
        };
    }
}
