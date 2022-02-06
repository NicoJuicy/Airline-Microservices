using System.Reflection;
using BuildingBlocks.Utils;
using GreenPipes;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace BuildingBlocks.Cap;

public static class Extensions
{
    public static IServiceCollection AddCustomMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(configure =>
        {
            configure.AddConsumers(Assembly.GetEntryAssembly());
            configure.UsingRabbitMq(
                (context, configurator) =>
                {
                    var rabbitMqOptions = services.GetOptions<RabbitMqOptions>("RabbitMq");
                    configurator.Host(rabbitMqOptions.HostName, h =>
                    {
                        h.Username(rabbitMqOptions.UserName);
                        h.Password(rabbitMqOptions.Password);
                    });

                    configurator.ReceiveEndpoint(rabbitMqOptions.ExchangeName, ep =>
                    {
                        ep.ExchangeType = ExchangeType.Topic;
                        ep.UseMessageRetry(retryConfigurator => retryConfigurator.Interval(3, TimeSpan.FromSeconds(5.0)));
                        ep.ConfigureConsumers(context);
                    });
                });
        });
        services.AddMassTransitHostedService();
        return services;
    }
}