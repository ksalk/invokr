using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Invokr;

// Registration extension
public static class InvokrServiceExtensions
{
    public static IServiceCollection AddInvokr(
        this IServiceCollection services,
        Action<InvokrOptions>? configure = null)
    {
        // Register core services
        // Register discovery providers
        // Register invoker providers

        return services;
    }
}

public static class InvokrApplicationExtensions
{
    public static IApplicationBuilder UseInvokr(
        this IApplicationBuilder app,
        string pathPrefix = "/invokr")
    {
        // Map API endpoints for UI
        // Serve embedded static files (React/Vue/Blazor UI)

        return app;
    }
}