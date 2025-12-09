using System.Reflection;
using MassTransit;

namespace Invokr.MassTransit;

/// <summary>
/// Discovery provider for MassTransit consumers.
/// </summary>
public class MassTransitConsumerDiscoveryProvider : IConsumerDiscoveryProvider
{
    private readonly Assembly[] _assemblies;

    /// <summary>
    /// Initializes a new instance of the <see cref="MassTransitConsumerDiscoveryProvider"/> class.
    /// </summary>
    /// <param name="assemblies">The assemblies to scan for consumers. If empty, the entry assembly will be used.</param>
    public MassTransitConsumerDiscoveryProvider(params Assembly[] assemblies)
    {
        _assemblies = assemblies.Length > 0
            ? assemblies
            : [Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly()];
    }

    /// <inheritdoc />
    public string ProviderName => "MassTransit";

    /// <inheritdoc />
    public IEnumerable<IConsumerDescriptor> DiscoverConsumers(IServiceProvider services)
    {
        var consumerTypes = _assemblies
            .SelectMany(a => a.GetTypes())
            .Where(IsConsumerType)
            .Distinct()
            .ToList();

        foreach (var consumerType in consumerTypes)
        {
            var messageTypes = GetMessageTypes(consumerType);

            foreach (var messageType in messageTypes)
            {
                yield return new MassTransitConsumerDescriptor(consumerType, messageType);
            }
        }
    }

    /// <summary>
    /// Determines whether the specified type is a MassTransit consumer.
    /// </summary>
    private static bool IsConsumerType(Type type)
    {
        if (type.IsInterface || type.IsAbstract)
            return false;

        return type.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConsumer<>));
    }

    /// <summary>
    /// Gets the message types handled by the specified consumer type.
    /// </summary>
    private static IEnumerable<Type> GetMessageTypes(Type consumerType)
    {
        return consumerType.GetInterfaces()
            .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IConsumer<>))
            .Select(i => i.GetGenericArguments()[0]);
    }
}
