using FluentValidation;
using MediatR;
using SSGP.Application.NewsModule.Repositories;
using SSGP.Domain.NewsModule.ValueObjects;

namespace SSGP.Application.NewsModule.Commands;

public class DeleteNewsCommand : IRequest
{
    public DeleteNewsCommand()
    {
        
    }
    public DeleteNewsCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}

public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
{
    public DeleteNewsCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotNull();
    }
}

public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
{
    private readonly INewsRepository _repository;

    public DeleteNewsCommandHandler(INewsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var news = await _repository.GetById(NewsId.From(request.Id));
        await _repository.Remove(news);
        await _repository.SaveChanges();
        return Unit.Value;
    }
}