using Example.DbContexts.Interfaces;
using Example.Repositories.Interfaces;
using Example.TableEntities;
using Microsoft.EntityFrameworkCore;

namespace Example.Repositories;

internal class SalesOrderRepository : ISalesOrderRepository
{
    public SalesOrderRepository(IExampleDbContext dbContext)
    {
        DbContext = dbContext;
        DbSet = dbContext.Set<SalesOrder>();
    }

    protected IExampleDbContext DbContext { get; }
    protected DbSet<SalesOrder> DbSet { get; }

    public IQueryable<SalesOrder> All => DbSet.AsQueryable();

    public void Add(SalesOrder entity)
    {
        DbSet.Add(entity);
    }

    public void Edit(SalesOrder entity)
    {
        DbSet.Entry(entity).State = EntityState.Modified;
    }
}
