namespace Example.DbContexts.Interfaces;
public interface IExampleUnitOfWork
{
    int Commit(bool acceptAllChangesOnSuccess);
    Task<int> CommitAsync();
    Task<int> CommitAsync(bool acceptAllChangesOnSuccess);
}
