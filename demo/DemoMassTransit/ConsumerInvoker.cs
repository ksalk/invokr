namespace DemoMassTransit;

using System.Threading.Tasks;
using Company.Consumers;
using Contracts;

public class ConsumerInvoker
{
    public async Task Invoke()
    {
        var consumer = new DemoMassTransitConsumer();
        var message = new DemoMassTransit { Value = "Hello World" };
        var context = new MockConsumeContext<DemoMassTransit>(message);
        await consumer.Consume(context);
    }
}
