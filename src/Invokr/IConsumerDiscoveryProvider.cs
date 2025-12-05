namespace Invokr;

/// <summary>
/// Provider for discovering consumers from a specific messaging framework.
/// </summary>
public interface IConsumerDiscoveryProvider
{
    /// <summary>
    /// Gets the name of the provider (e.g., "MassTransit", "NServiceBus").
    /// </summary>
    string ProviderName { get; }

    /// <summary>
    /// Discovers consumers using the specified service provider.
    /// </summary>
    /// <param name="services">The service provider to use for discovery.</param>
    /// <returns>A collection of discovered consumer descriptors.</returns>
    IEnumerable<IConsumerDescriptor> DiscoverConsumers(IServiceProvider services);
}
