namespace DemoMassTransit;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;

public class MockConsumeContext<T> : ConsumeContext<T> where T : class
{
    public MockConsumeContext(T message)
    {
        Message = message;
    }

    public T Message { get; }

    public Guid? MessageId => Guid.NewGuid();
    public Guid? RequestId => null;
    public Guid? CorrelationId => null;
    public Guid? ConversationId => null;
    public Guid? InitiatorId => null;
    public DateTime? ExpirationTime => null;
    public Uri SourceAddress => null!;
    public Uri DestinationAddress => null!;
    public Uri ResponseAddress => null!;
    public Uri FaultAddress => null!;
    public DateTime? SentTime => DateTime.UtcNow;
    public Headers Headers => null!;
    public HostInfo Host => null!;
    public ReceiveContext ReceiveContext => null!;
    public Task ConsumeCompleted => Task.CompletedTask;
    public Guid? SchedulingTokenId => null;
    public IEnumerable<string> SupportedMessageTypes => Array.Empty<string>();
    public CancellationToken CancellationToken => CancellationToken.None;
    public SerializerContext SerializerContext => null!;

    public Task NotifyConsumed(TimeSpan duration, string consumerType) => Task.CompletedTask;
    public Task NotifyFaulted(TimeSpan duration, string consumerType, Exception exception) => Task.CompletedTask;
    public Task NotifyConsumed<TMessage>(ConsumeContext<TMessage> context, TimeSpan duration, string consumerType) where TMessage : class => Task.CompletedTask;
    public Task NotifyFaulted<TMessage>(ConsumeContext<TMessage> context, TimeSpan duration, string consumerType, Exception exception) where TMessage : class => Task.CompletedTask;
    public bool HasMessageType(Type messageType) => messageType == typeof(T);
    public bool TryGetMessage<TMessage>(out ConsumeContext<TMessage> consumeContext) where TMessage : class { consumeContext = null!; return false; }
    public void AddConsumeTask(Task task) { }

    public Task RespondAsync<TMessage>(TMessage message) where TMessage : class => Task.CompletedTask;
    public Task RespondAsync<TMessage>(TMessage message, IPipe<SendContext<TMessage>> sendPipe) where TMessage : class => Task.CompletedTask;
    public Task RespondAsync<TMessage>(TMessage message, IPipe<SendContext> sendPipe) where TMessage : class => Task.CompletedTask;
    public Task RespondAsync(object message) => Task.CompletedTask;
    public Task RespondAsync(object message, Type messageType) => Task.CompletedTask;
    public Task RespondAsync(object message, IPipe<SendContext> sendPipe) => Task.CompletedTask;
    public Task RespondAsync(object message, Type messageType, IPipe<SendContext> sendPipe) => Task.CompletedTask;
    public Task RespondAsync<TMessage>(object values) where TMessage : class => Task.CompletedTask;
    public Task RespondAsync<TMessage>(object values, IPipe<SendContext<TMessage>> sendPipe) where TMessage : class => Task.CompletedTask;
    public Task RespondAsync<TMessage>(object values, IPipe<SendContext> sendPipe) where TMessage : class => Task.CompletedTask;
    public void Respond<TMessage>(TMessage message) where TMessage : class { }

    public ConnectHandle ConnectPublishObserver(IPublishObserver observer) => null!;
    public Task<ISendEndpoint> GetSendEndpoint(Uri address) => Task.FromResult<ISendEndpoint>(null!);
    public ConnectHandle ConnectSendObserver(ISendObserver observer) => null!;

    public Task Publish<TMessage>(TMessage message, CancellationToken cancellationToken = default) where TMessage : class => Task.CompletedTask;
    public Task Publish<TMessage>(TMessage message, IPipe<PublishContext<TMessage>> publishPipe, CancellationToken cancellationToken = default) where TMessage : class => Task.CompletedTask;
    public Task Publish<TMessage>(TMessage message, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default) where TMessage : class => Task.CompletedTask;
    public Task Publish(object message, CancellationToken cancellationToken = default) => Task.CompletedTask;
    public Task Publish(object message, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default) => Task.CompletedTask;
    public Task Publish(object message, Type messageType, CancellationToken cancellationToken = default) => Task.CompletedTask;
    public Task Publish(object message, Type messageType, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default) => Task.CompletedTask;
    public Task Publish<TMessage>(object values, CancellationToken cancellationToken = default) where TMessage : class => Task.CompletedTask;
    public Task Publish<TMessage>(object values, IPipe<PublishContext<TMessage>> publishPipe, CancellationToken cancellationToken = default) where TMessage : class => Task.CompletedTask;
    public Task Publish<TMessage>(object values, IPipe<PublishContext> publishPipe, CancellationToken cancellationToken = default) where TMessage : class => Task.CompletedTask;

    public bool HasPayloadType(Type payloadType) => false;
    public bool TryGetPayload<TPayload>(out TPayload payload) where TPayload : class { payload = null!; return false; }
    public TPayload GetOrAddPayload<TPayload>(PayloadFactory<TPayload> payloadFactory) where TPayload : class => null!;
    public TPayload AddOrUpdatePayload<TPayload>(PayloadFactory<TPayload> addFactory, UpdatePayloadFactory<TPayload> updateFactory) where TPayload : class => null!;
}
