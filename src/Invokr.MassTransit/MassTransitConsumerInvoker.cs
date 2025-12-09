using System.Text.Json;
using Invokr;
using Microsoft.Extensions.DependencyInjection;

public class MassTransitConsumerInvoker(IServiceProvider serviceProvider) : IConsumerInvoker
{
    public Task<ConsumerInvocationResult> InvokeAsync(IConsumerDescriptor consumerDescriptor, object message, CancellationToken ct = default)
    {
        var consumer = serviceProvider.GetRequiredService(consumerDescriptor.ConsumerType);
        var consumeMethod = consumerDescriptor.ConsumerType.GetMethod("Consume");
        if (consumeMethod == null)
        {
            throw new InvalidOperationException($"Consumer type '{consumerDescriptor.ConsumerType.FullName}' does not have a 'Consume' method.");
        }

        var task = (Task)consumeMethod.Invoke(consumer, [message])!;
        return task.ContinueWith(t =>
        {
            if (t.IsFaulted)
            {
                return new ConsumerInvocationResult(false, TimeSpan.Zero, t.Exception, null);
            }
            return new ConsumerInvocationResult(true, TimeSpan.Zero, null, null);
        });
    }

    public Task<ConsumerInvocationResult> InvokeAsync(IConsumerDescriptor consumerDescriptor, string jsonPayload, CancellationToken ct = default)
    {
        var message = JsonSerializer.Deserialize(jsonPayload, consumerDescriptor.MessageType);
        if (message == null)
        {
            throw new InvalidOperationException($"Failed to deserialize message of type '{consumerDescriptor.MessageType.FullName}' from JSON payload.");
        }

        return InvokeAsync(consumerDescriptor, message, ct);
    }
}