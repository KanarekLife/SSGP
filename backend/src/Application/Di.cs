using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SSGP.Application.Core.Pipelines;

namespace SSGP.Application;

public static class Di
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<,>));
        return services;
    }
}