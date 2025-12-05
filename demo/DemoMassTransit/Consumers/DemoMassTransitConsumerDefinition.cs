namespace Company.Consumers
{
    using MassTransit;

    public class DemoMassTransitConsumerDefinition :
        ConsumerDefinition<DemoMassTransitConsumer>
    {
        protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<DemoMassTransitConsumer> consumerConfigurator, IRegistrationContext context)
        {
            endpointConfigurator.UseMessageRetry(r => r.Intervals(500, 1000));

            endpointConfigurator.UseInMemoryOutbox(context);
        }
    }
}