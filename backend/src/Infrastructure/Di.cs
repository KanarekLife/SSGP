using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SSGP.Application.NewsModule.Repositories;
using SSGP.Infrastructure.Data;
using SSGP.Infrastructure.NewsModule;

namespace SSGP.Infrastructure;

public static class Di
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDatabase(configuration);
        services.AddTransient<INewsRepository, NewsRepository>();
        return services;
    }
}