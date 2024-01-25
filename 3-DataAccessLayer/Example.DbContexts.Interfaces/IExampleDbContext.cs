using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Example.DbContexts.Interfaces;

public interface IExampleDbContext
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    EntityEntry Entry(object entity);
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
}
