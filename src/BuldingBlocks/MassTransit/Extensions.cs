using System.Reflection;
using BuildingBlocks.Utils;
using GreenPipes;
using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.DependencyInjection;

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
                    configurator.ConfigureEndpoints(context,
                        new KebabCaseEndpointNameFormatter(rabbitMqOptions.ExchangeName, false));
                    configurator.UseMessageRetry(retryConfigurator =>
                        retryConfigurator.Interval(3, TimeSpan.FromSeconds(5.0)));
                });
        });
        services.AddMassTransitHostedService();
        return services;
    }
}