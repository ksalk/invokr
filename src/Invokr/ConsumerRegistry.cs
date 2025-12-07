namespace Invokr;

/// <summary>
/// Default implementation of <see cref="IConsumerRegistry"/>.
/// </summary>
public class ConsumerRegistry : IConsumerRegistry
{
    private readonly List<IConsumerDescriptor> _consumers = [];
    private readonly Dictionary<string, IConsumerDescriptor> _byName = new(StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<Type, IConsumerDescriptor> _byMessageType = [];

    public IReadOnlyList<IConsumerDescriptor> Consumers => _consumers;

    public IConsumerDescriptor? GetByName(string name)
    {
        ArgumentNullException.ThrowIfNull(name);
        return _byName.GetValueOrDefault(name);
    }

    public IConsumerDescriptor? GetByMessageType(Type messageType)
    {
        ArgumentNullException.ThrowIfNull(messageType);
        return _byMessageType.GetValueOrDefault(messageType);
    }

    public void Register(IConsumerDescriptor descriptor)
    {
        ArgumentNullException.ThrowIfNull(descriptor);

        if (_byName.ContainsKey(descriptor.Name))
        {
            throw new InvalidOperationException($"A consumer with name '{descriptor.Name}' is already registered.");
        }

        if (_byMessageType.ContainsKey(descriptor.MessageType))
        {
            throw new InvalidOperationException($"A consumer for message type '{descriptor.MessageType.FullName}' is already registered.");
        }

        _consumers.Add(descriptor);
        _byName[descriptor.Name] = descriptor;
        _byMessageType[descriptor.MessageType] = descriptor;
    }
}
