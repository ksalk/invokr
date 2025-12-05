namespace Invokr;

/// <summary>
/// Result of consumer invocation.
/// </summary>
/// <param name="Success">Indicates whether the invocation was successful.</param>
/// <param name="Duration">The duration of the invocation.</param>
/// <param name="Exception">The exception that occurred during invocation, if any.</param>
/// <param name="PublishedMessages">Captured outgoing messages.</param>
public record ConsumerInvocationResult(
    bool Success,
    TimeSpan Duration,
    Exception? Exception,
    IReadOnlyList<object>? PublishedMessages
);
