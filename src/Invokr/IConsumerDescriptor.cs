public interface IConsumerDescriptor
{
    string Name { get; }
    Type ConsumerType { get; }
    Type MessageType { get; }
    string? Description { get; }
    //JsonSchema MessageSchema { get; }  // For UI validation/generation
}