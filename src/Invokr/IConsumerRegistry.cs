namespace Invokr;

/// <summary>
/// Registry of all discovered consumers.
/// </summary>
public interface IConsumerRegistry
{
    IReadOnlyList<IConsumerDescriptor> Consumers { get; }
    IConsumerDescriptor? GetByName(string name);
    IConsumerDescriptor? GetByMessageType(Type messageType);
}
