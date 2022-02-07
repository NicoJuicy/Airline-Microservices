using System.Reflection;
using BuildingBlocks.Domain;
using BuildingBlocks.Utils;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;

namespace BuildingBlocks.MassTransit;

public static class Extensions
{
    public static IServiceCollection AddCustomMassTransit(this IServiceCollection services)
    {
        services.AddMassTransit(configure =>
        {
            configure.AddConsumers(Assembly.GetEntryAssembly());

            configure.UsingRabbitMq((context, configurator) =>
            {
                var rabbitMqOptions = services.GetOptions<RabbitMqOptions>("RabbitMq");
                configurator.Host(rabbitMqOptions.HostName, h =>
                {
                    h.Username(rabbitMqOptions.UserName);
                    h.Password(rabbitMqOptions.Password);
                });

                var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                    .Where(x => x.IsAssignableTo(typeof(IEvent)) && x.IsInterface == false &&
                                x.IsAbstract == false &&
                                x.IsGenericType == false);

                foreach (var type in types)
                {
                    var consumers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                        .Where(x => x.IsAssignableTo(typeof(IConsumer<>).MakeGenericType(type))).ToList();

                    if (consumers.Any())
                        configurator.ReceiveEndpoint(rabbitMqOptions.ExchangeName, e =>
                        {
                            foreach (var consumer in consumers)
                            {
                                configurator.ConfigureEndpoints(context, x => x.Exclude(consumer));

                                var methodInfo = typeof(DependencyInjectionReceiveEndpointExtensions)
                                    .GetMethods()
                                    .Where(x => x.GetParameters()
                                        .Any(p => p.ParameterType == typeof(IServiceProvider)))
                                    .FirstOrDefault(x => x.Name == "Consumer" && x.IsGenericMethod);

                                var generic = methodInfo?.MakeGenericMethod(consumer);
                                generic?.Invoke(e, new object[] {e, context, null});
                            }

                            e.ExchangeType = ExchangeType.Topic;
                        });
                }
            });
        });

        services.AddMassTransitHostedService();

        return services;
    }
}