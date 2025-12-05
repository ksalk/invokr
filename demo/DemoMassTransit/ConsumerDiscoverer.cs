using System.Reflection;
using MassTransit.Metadata;

public class ConsumerDiscoverer
{
    public static void DiscoverConsumers(IServiceProvider serviceProvider)
    {
        var assemblies = new[] { Assembly.GetEntryAssembly() };

        var consumers = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => RegistrationMetadata.IsConsumer(t) && !t.IsInterface && !t.IsAbstract)
            .ToList();
        Console.WriteLine($"Discovered {consumers.Count} consumers via IServiceProvider.");
    }
}