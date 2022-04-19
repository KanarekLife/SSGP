using Microsoft.EntityFrameworkCore;
using News = SSGP.Infrastructure.NewsModule.DatabaseModels.News;

namespace SSGP.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<News>? News { get; set; }
}