using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ApplicationException = SSGP.Application.Core.ApplicationException;

namespace SSGP.Api.Core.ExceptionFilters;

public class ApplicationExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not ApplicationException applicationException)
        {
            return;
        }

        var problem = new ProblemDetails()
        {
            Title = nameof(applicationException),
            Detail = applicationException.Message,
            Type = nameof(ApplicationException)
        };
        foreach (var extension in applicationException.Extensions())
        {
            problem.Extensions.Add(extension);
        }

        var result = new ObjectResult(problem)
        {
            StatusCode = applicationException.StatusCode
        };

        context.Result = result;
        context.ExceptionHandled = true;
    }
}