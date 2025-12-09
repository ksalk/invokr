using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Invokr;

public static class InvokrServiceExtensions
{
    public static IServiceCollection AddInvokr(
        this IServiceCollection services,
        Action<InvokrOptions>? configure = null)
    {
        var options = new InvokrOptions();
        configure?.Invoke(options);

        services.AddSingleton(options);
        services.AddSingleton<IConsumerRegistry, ConsumerRegistry>();

        foreach (var registration in options.DiscoveryProviderRegistrations)
        {
            registration(services);
        }

        return services;
    }
}

public static class InvokrApplicationExtensions
{
    public static IApplicationBuilder UseInvokr(
        this IApplicationBuilder app,
        string uiPathPrefix = "/invokr")
    {
        // Map API endpoints for UI
        // Serve embedded static files (React/Vue/Blazor UI)

        // TODO: for now just adding simple endpoint
        return app;
    }
}