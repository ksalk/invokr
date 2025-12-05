namespace Invokr;

/// <summary>
/// Configuration options for Invokr.
/// </summary>
public class InvokrOptions
{
    /// <summary>
    /// Gets or sets the assemblies to scan for consumer discovery.
    /// If empty, the entry assembly will be scanned.
    /// </summary>
    public List<System.Reflection.Assembly> AssembliesToScan { get; set; } = [];

    /// <summary>
    /// Gets or sets whether to automatically discover consumers on startup.
    /// Default is true.
    /// </summary>
    public bool AutoDiscoverConsumers { get; set; } = true;

    /// <summary>
    /// Gets or sets the path prefix for the Invokr UI endpoints.
    /// Default is "/invokr".
    /// </summary>
    public string PathPrefix { get; set; } = "/invokr";
}
