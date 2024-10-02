using DevFreela.Payments.Application;
using DevFreela.Payments.Consumers;
using DevFreela.Payments.Infrastructure;

var builder = Host.CreateApplicationBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Services.AddHostedService<ProcessPaymentConsumer>();

var host = builder.Build();
host.Run();
