using System.Reflection;
using BuildingBlocks.Domain;
using BuildingBlocks.Utils;
using Humanizer;
using MassTransit;
using MassTransit.Topology;
using Microsoft.Extensions.DependencyInjection;

namespace BuildingBlocks.MassTransit;

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

                    var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                        .Where(x => x.IsAssignableTo(typeof(IEvent)) && x.IsInterface == false &&
                                    x.IsAbstract == false &&
                                    x.IsGenericType == false);


                    foreach (var type in types)
                    {
                        var consumers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                            .Where(x => x.IsAssignableTo(typeof(IConsumer<>).MakeGenericType(type))).ToList();

                        //////////
                        var messageMethodInfo = configurator.GetType().GetMethod("Message");
                        var messageMethodInfoGeneric = messageMethodInfo?.MakeGenericMethod(type);
                        var messageTopologyMethodType = typeof(Extensions).GetMethods()
                            .FirstOrDefault(x => x.Name == nameof(CreateMessageTopologyConfigurator))
                            ?.MakeGenericMethod(type);

                        var messageMethodDelegate = messageTopologyMethodType?.Invoke(null, null);

                        // prepare delegate instance
                        messageMethodInfoGeneric?.Invoke(configurator, new[]
                        {
                            messageMethodDelegate
                        });

                        configurator.ReceiveEndpoint(
                            string.IsNullOrEmpty(rabbitMqOptions.ExchangeName)
                                ? type.Name.Underscore()
                                : $"{rabbitMqOptions.ExchangeName}_{type.Name.Underscore()}", e =>
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
                            });
                    }
                });
        });

        services.AddMassTransitHostedService();

        return services;
    }

    public static Action<IMessageTopologyConfigurator<T>> CreateMessageTopologyConfigurator<T>() where T : class
    {
        return param => { param.SetEntityName(typeof(T).Namespace.Underscore() + "_" + typeof(T).Name.Underscore()); };
    }
}