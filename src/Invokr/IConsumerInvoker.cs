namespace Invokr;

/// <summary>
/// Invokes a consumer with a message.
/// </summary>
public interface IConsumerInvoker
{
    Task<ConsumerInvocationResult> InvokeAsync(
        IConsumerDescriptor consumer,
        object message,
        CancellationToken ct = default);

    Task<ConsumerInvocationResult> InvokeAsync(
        IConsumerDescriptor consumer,
        string jsonPayload,
        CancellationToken ct = default);
}
