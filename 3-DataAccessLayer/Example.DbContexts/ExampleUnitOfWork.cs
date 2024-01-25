using Example.DbContexts.Interfaces;

namespace Example.DbContexts;
internal class ExampleUnitOfWork : IExampleUnitOfWork
{
    public ExampleUnitOfWork(IExampleDbContext dbContext) => DbContext = dbContext;

    protected IExampleDbContext DbContext { get; }

    public int Commit(bool acceptAllChangesOnSuccess)
        => DbContext.SaveChanges(acceptAllChangesOnSuccess);

    public async Task<int> CommitAsync(bool acceptAllChangesOnSuccess)
        => await DbContext.SaveChangesAsync(acceptAllChangesOnSuccess);

    public async Task<int> CommitAsync() 
        => await DbContext.SaveChangesAsync(true);
}