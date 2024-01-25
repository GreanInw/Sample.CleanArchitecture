using Example.DbContexts.Interfaces;
using Example.TableEntities;
using Microsoft.EntityFrameworkCore;

namespace Example.DbContexts;

internal class ExampleDbContext : DbContext, IExampleDbContext
{
    public ExampleDbContext(DbContextOptions<ExampleDbContext> dbContextOptions) : base(dbContextOptions)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SalesOrder>();
    }
}
