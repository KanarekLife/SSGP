using SSGP.Domain.NewsModule.ValueObjects;
using ApplicationException = SSGP.Application.Core.ApplicationException;

namespace SSGP.Application.NewsModule.Exceptions;

public class NewsWithGivenIdNotFoundException : ApplicationException
{
    public NewsWithGivenIdNotFoundException(NewsId id) : base("News with given id was not found.")
    {
        Id = id;
    }
    
    public NewsId Id { get; }
}