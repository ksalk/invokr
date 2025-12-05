# Arch

Invokr/
├── src/
│   ├── Invokr.Core/                      # Core abstractions
│   │   ├── IConsumerDescriptor.cs
│   │   ├── IConsumerRegistry.cs
│   │   ├── IConsumerInvoker.cs
│   │   ├── IConsumerDiscoveryProvider.cs
│   │   └── Schema/
│   │       └── JsonSchemaGenerator.cs
│   │
│   ├── Invokr.MassTransit/               # MassTransit adapter
│   │   ├── MassTransitConsumerDescriptor.cs
│   │   ├── MassTransitDiscoveryProvider.cs
│   │   ├── MassTransitInvokerProvider.cs
│   │   ├── MockConsumeContext.cs
│   │   └── ServiceCollectionExtensions.cs
│   │
│   ├── Invokr.UI/                        # Embedded Web UI
│   │   ├── Api/
│   │   │   ├── ConsumersEndpoint.cs
│   │   │   └── InvokeEndpoint.cs
│   │   ├── wwwroot/                      # Embedded static files
│   │   └── InvokrMiddleware.cs
│   │
│   └── Invokr/                           # Meta-package
│       └── ServiceCollectionExtensions.cs
│
├── samples/
│   └── Invokr.Demo.MassTransit/
│
└── tests/


# Usage

ar builder = WebApplication.CreateBuilder(args);

// Add MassTransit
builder.Services.AddMassTransit(x => { ... });

// Add Invokr for local testing
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddInvokr(options =>
    {
        options.UseMassTransit();
        options.ScanAssemblies(typeof(Program).Assembly);
    });
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseInvokr("/invokr");  // UI available at /invokr
}

app.Run();