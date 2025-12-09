namespace Invokr;

/// <summary>
/// Invokes a consumer with a message.
/// </summary>
public interface IConsumerInvoker
{
    Task<ConsumerInvocationResult> InvokeAsync(
        IConsumerDescriptor consumerDescriptor,
        object message,
        CancellationToken ct = default);

    Task<ConsumerInvocationResult> InvokeAsync(
        IConsumerDescriptor consumerDescriptor,
        string jsonPayload,
        CancellationToken ct = default);
}
