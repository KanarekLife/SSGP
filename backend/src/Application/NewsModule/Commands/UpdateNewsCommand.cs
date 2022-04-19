using FluentValidation;
using MediatR;
using SSGP.Application.NewsModule.Models;
using SSGP.Application.NewsModule.Repositories;
using SSGP.Domain.NewsModule.ValueObjects;

namespace SSGP.Application.NewsModule.Commands;

public class UpdateNewsCommand : IRequest<NewsDto>
{
    public UpdateNewsCommand()
    {
        
    }
    
    public UpdateNewsCommand(Guid id, string? newTitle, string? newContent)
    {
        NewsId = id;
        NewTitle = newTitle;
        NewContent = newContent;
    }

    public Guid NewsId { get; set; }
    public string? NewTitle { get; set; }
    public string? NewContent { get; set; }
}

public class UpdateNewsCommandValidator : AbstractValidator<UpdateNewsCommand>
{
    public UpdateNewsCommandValidator()
    {
        RuleFor(x => x.NewsId)
            .NotNull();
    }
}

public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, NewsDto>
{
    private readonly INewsRepository _repository;

    public UpdateNewsCommandHandler(INewsRepository repository)
    {
        _repository = repository;
    }

    public async Task<NewsDto> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetById(NewsId.From(request.NewsId));
        if (request.NewTitle is not null)
        {
            news.ChangeTitle(NewsTitle.From(request.NewTitle));
        }
        if (request.NewContent is not null)
        {
            news.ChangeContent(NewsContent.From(request.NewContent));
        }
        await _repository.SaveChanges();
        return NewsDto.From(news);
    }
}