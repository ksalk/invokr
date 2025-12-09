using Microsoft.Extensions.DependencyInjection;

namespace Invokr;

/// <summary>
/// Configuration options for Invokr.
/// </summary>
public class InvokrOptions
{
    /// <summary>
    /// Gets or sets the path prefix for the Invokr UI endpoints.
    /// Default is "/invokr".
    /// </summary>
    public string PathPrefix { get; set; } = "/invokr";

    /// <summary>
    /// Gets the list of actions to configure discovery provider registrations.
    /// These actions are invoked during service registration to add provider-specific services.
    /// </summary>
    internal List<Action<IServiceCollection>> DiscoveryProviderRegistrations { get; } = [];

    /// <summary>
    /// Adds a consumer discovery provider registration.
    /// </summary>
    /// <typeparam name="TProvider">The type of the discovery provider.</typeparam>
    /// <returns>The options instance for chaining.</returns>
    public InvokrOptions AddDiscoveryProvider<TProvider>() where TProvider : class, IConsumerDiscoveryProvider
    {
        DiscoveryProviderRegistrations.Add(services =>
            services.AddSingleton<IConsumerDiscoveryProvider, TProvider>());
        return this;
    }

    /// <summary>
    /// Adds a consumer discovery provider registration with a factory.
    /// </summary>
    /// <typeparam name="TProvider">The type of the discovery provider.</typeparam>
    /// <param name="factory">The factory function to create the provider instance.</param>
    /// <returns>The options instance for chaining.</returns>
    public InvokrOptions AddDiscoveryProvider<TProvider>(Func<IServiceProvider, TProvider> factory) 
        where TProvider : class, IConsumerDiscoveryProvider
    {
        DiscoveryProviderRegistrations.Add(services =>
            services.AddSingleton<IConsumerDiscoveryProvider, TProvider>(factory));
        return this;
    }
}
