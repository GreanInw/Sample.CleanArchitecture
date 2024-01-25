using Example.DbContexts.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Example.DbContexts;
public static class DbContextExtensions
{
    public static IServiceCollection AddExampleDbContext(this IServiceCollection services, string sectionName)
        => services.AddDbContextOptionsInternal(sectionName)
            .AddDbContextInternal()
            .AddUnitOfWork();

    internal static IServiceCollection AddDbContextInternal(this IServiceCollection services)
    {
        return services.AddScoped<IExampleDbContext>(provider =>
        {
            var options = provider.GetService<DbContextOptions<ExampleDbContext>>();
            return new ExampleDbContext(options);
        });
    }

    internal static IServiceCollection AddDbContextOptionsInternal(this IServiceCollection services, string sectionName)
    {
        services.AddSingleton(provider =>
        {
            var configuration = provider.GetConfiguration();
            string connectionString = configuration.GetValue<string>(sectionName);
            return new DbContextOptionsBuilder<ExampleDbContext>().UseSqlServer(connectionString, option =>
            {
                option.EnableRetryOnFailure(3);
            }).Options;
        });
        return services;
    }

    internal static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IExampleUnitOfWork>(provider =>
        {
            var dbContext = provider.GetService<IExampleDbContext>();
            return new ExampleUnitOfWork(dbContext);
        });
        return services;
    }

    internal static IConfiguration GetConfiguration(this IServiceProvider provider)
        => provider.GetService<IConfiguration>();
}
