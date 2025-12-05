namespace Company.Consumers
{
    using System.Threading.Tasks;
    using MassTransit;
    using Contracts;

    public class DemoMassTransitConsumer :
        IConsumer<DemoMassTransit>
    {
        public Task Consume(ConsumeContext<DemoMassTransit> context)
        {
            var messageValue = context.Message.Value;
            Console.WriteLine($"Consumed message with Value: {messageValue}");
            return Task.CompletedTask;
        }
    }
}