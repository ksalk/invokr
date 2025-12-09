namespace Invokr.MassTransit;

/// <summary>
/// Descriptor for a MassTransit consumer.
/// </summary>
public class MassTransitConsumerDescriptor : IConsumerDescriptor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MassTransitConsumerDescriptor"/> class.
    /// </summary>
    /// <param name="consumerType">The type of the consumer.</param>
    /// <param name="messageType">The type of the message the consumer handles.</param>
    /// <param name="description">An optional description of the consumer.</param>
    public MassTransitConsumerDescriptor(Type consumerType, Type messageType, string? description = null)
    {
        ArgumentNullException.ThrowIfNull(consumerType);
        ArgumentNullException.ThrowIfNull(messageType);

        ConsumerType = consumerType;
        MessageType = messageType;
        Name = consumerType.Name;
        Description = description;
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <inheritdoc />
    public Type ConsumerType { get; }

    /// <inheritdoc />
    public Type MessageType { get; }

    /// <inheritdoc />
    public string? Description { get; }
}
