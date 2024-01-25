using Microsoft.Extensions.DependencyInjection;

namespace Example.Handlers;
public static class HandlerExtensions
{
    public static IServiceCollection AddHandlers(this IServiceCollection services)
    {
        services.AddMediatR(f => f.RegisterServicesFromAssembly(typeof(HandlerExtensions).Assembly));
        return services;
    }
}
