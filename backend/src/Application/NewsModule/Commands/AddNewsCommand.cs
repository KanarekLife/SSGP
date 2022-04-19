using FluentValidation;
using MediatR;
using SSGP.Application.NewsModule.Models;
using SSGP.Application.NewsModule.Repositories;
using SSGP.Domain.NewsModule.Entities;
using SSGP.Domain.NewsModule.ValueObjects;

namespace SSGP.Application.NewsModule.Commands;

public class AddNewsCommand : IRequest<NewsDto>
{
    public string Title { get; set; }
    public string Content { get; set; }
}

public class AddNewsCommandValidator : AbstractValidator<AddNewsCommand>
{
    public AddNewsCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty();
        RuleFor(x => x.Content)
            .NotEmpty();
    }
}

public class AddNewsCommandHandler : IRequestHandler<AddNewsCommand, NewsDto>
{
    private readonly INewsRepository _repository;

    public AddNewsCommandHandler(INewsRepository repository)
    {
        _repository = repository;
    }

    public async Task<NewsDto> Handle(AddNewsCommand request, CancellationToken cancellationToken)
    {
        var news = new News(NewsId.New(), NewsTitle.From(request.Title), NewsContent.From(request.Content));
        await _repository.Add(news);
        await _repository.SaveChanges();
        return NewsDto.From(news);
    }
}