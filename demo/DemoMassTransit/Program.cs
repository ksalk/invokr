using System.Reflection;
using DemoMassTransit;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.SetKebabCaseEndpointNameFormatter();

    // By default, sagas are in-memory, but should be changed to a durable
    // saga repository.
    x.SetInMemorySagaRepositoryProvider();

    var entryAssembly = Assembly.GetEntryAssembly();

    x.AddConsumers(entryAssembly);
    x.AddSagaStateMachines(entryAssembly);
    x.AddSagas(entryAssembly);
    x.AddActivities(entryAssembly);

    x.UsingInMemory((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddScoped<ConsumerInvoker>();

var app = builder.Build();

ConsumerDiscoverer.DiscoverConsumers(app.Services);

app.MapGet("/invoke", async (ConsumerInvoker invoker) =>
{
    await invoker.Invoke();
    return Results.Ok("Consumer invoked successfully");
});

app.Run();
