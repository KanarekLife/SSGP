using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SSGP.Infrastructure.Data;

internal static class Di
{
    private const string MainDatabaseConnectionString = "MainDatabase";
    internal static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseSqlite(configuration.GetConnectionString(MainDatabaseConnectionString));
        });
        return services;
    }
}