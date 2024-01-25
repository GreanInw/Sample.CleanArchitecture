using Example.DbContexts.Interfaces;
using Example.Repositories.Interfaces;
using Example.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Example.Services;
public static class ServiceExtensions
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISalesOrderService>(provider =>
        {
            var respository = provider.GetService<ISalesOrderRepository>();
            var unitOfWork = provider.GetService<IExampleUnitOfWork>();

            return new SalesOrderService(unitOfWork, respository);
        });
        return services;
    }
}
