using System.Reflection;

namespace Invokr.MassTransit;

/// <summary>
/// Extension methods for configuring MassTransit consumer discovery with Invokr.
/// </summary>
public static class InvokrOptionsExtensions
{
    /// <summary>
    /// Adds MassTransit consumer discovery support to Invokr.
    /// Uses the assemblies configured in <see cref="InvokrOptions.AssembliesToScan"/>,
    /// or the entry assembly if none are configured.
    /// </summary>
    /// <param name="options">The Invokr options.</param>
    /// <returns>The options instance for chaining.</returns>
    public static InvokrOptions AddMassTransit(this InvokrOptions options)
    {
        var assemblies = new[] { Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly() };

        return options.AddMassTransit(assemblies);
    }

    /// <summary>
    /// Adds MassTransit consumer discovery support to Invokr with specific assemblies to scan.
    /// </summary>
    /// <param name="options">The Invokr options.</param>
    /// <param name="assemblies">The assemblies to scan for MassTransit consumers.</param>
    /// <returns>The options instance for chaining.</returns>
    public static InvokrOptions AddMassTransit(this InvokrOptions options, params Assembly[] assemblies)
    {
        return options.AddDiscoveryProvider(_ => new MassTransitConsumerDiscoveryProvider(assemblies));
    }
}
