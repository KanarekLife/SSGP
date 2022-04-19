using MediatR;
using Microsoft.AspNetCore.Mvc;
using SSGP.Api.NewsModule.Models;
using SSGP.Application.Core.Pagination.Models;
using SSGP.Application.NewsModule.Commands;
using SSGP.Application.NewsModule.Models;
using SSGP.Application.NewsModule.Queries;

namespace SSGP.Api.NewsModule;

[ApiController]
[Route("/news/")]
public class NewsModuleController : ControllerBase
{
    private readonly IMediator _mediator;

    public NewsModuleController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:guid}")]
    public async Task<NewsDto> GetNewsById(Guid id)
        => await _mediator.Send(new GetNewsQuery(id));

    [HttpGet]
    public async Task<PaginationDto<NewsDto>> GetLatestNews(int pageNumber = 0, int numberOfItemsPerPage = 50)
        => await _mediator.Send(new GetLatestNewsQuery(pageNumber, numberOfItemsPerPage));

    [HttpPost]
    public async Task<NewsDto> AddNews([FromBody] AddNewsCommand req)
        => await _mediator.Send(req);

    [HttpPatch("{id:guid}")]
    public async Task<NewsDto> UpdateNews([FromRoute] Guid id, [FromBody] UpdateNewsModel body)
    {
        var req = new UpdateNewsCommand(id, body.NewTitle, body.NewContent);
        return await _mediator.Send(req);
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteNews(Guid id)
        => await _mediator.Send(new DeleteNewsCommand(id));
}