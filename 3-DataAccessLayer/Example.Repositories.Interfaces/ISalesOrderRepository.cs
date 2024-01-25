using Example.TableEntities;

namespace Example.Repositories.Interfaces;

public interface ISalesOrderRepository
{
    IQueryable<SalesOrder> All { get; }
    void Add(SalesOrder entity);
    void Edit(SalesOrder entity);
}
