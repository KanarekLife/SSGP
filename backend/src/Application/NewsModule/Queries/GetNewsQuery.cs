using FluentValidation;
using MediatR;
using SSGP.Application.NewsModule.Models;
using SSGP.Application.NewsModule.Repositories;
using SSGP.Domain.NewsModule.ValueObjects;

namespace SSGP.Application.NewsModule.Queries;

public class GetNewsQuery : IRequest<NewsDto>
{
    public GetNewsQuery()
    {
    }

    public GetNewsQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class GetNewsQueryValidator : AbstractValidator<GetNewsQuery>
{
    public GetNewsQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull();
    }
}

public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, NewsDto>
{
    private readonly INewsRepository _repository;

    public GetNewsQueryHandler(INewsRepository repository)
    {
        _repository = repository;
    }

    public async Task<NewsDto> Handle(GetNewsQuery request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetById(NewsId.From(request.Id));
        return NewsDto.From(news);
    }
}