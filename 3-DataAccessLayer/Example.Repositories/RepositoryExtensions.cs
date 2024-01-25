using Example.DbContexts.Interfaces;
using Example.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Repositories;
public static class RepositoryExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISalesOrderRepository>(provider =>
        {
            var dbContext = provider.GetService<IExampleDbContext>();
            return new SalesOrderRepository(dbContext);
        });
        return services;
    }
}
