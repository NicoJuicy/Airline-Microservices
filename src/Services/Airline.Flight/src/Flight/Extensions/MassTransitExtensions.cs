using BuildingBlocks.Utils;
using Flight.Configuration;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Flight.Extensions;

public static class Extensions
{
    public static IServiceCollection AddCustomMassTransit(this IServiceCollection services,
        IConfiguration configuration)
    {
        var rabbitMqOptions = configuration.GetOptions<RabbitMqOptions>("RabbitMq");

        return services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((ctx, cfg) =>
            {
                cfg.UseHealthCheck(ctx);
                cfg.Host(rabbitMqOptions.Host, h =>
                {
                    h.Username(rabbitMqOptions.Username);
                    h.Password(rabbitMqOptions.Password);
                });
                cfg.ConfigureEndpoints(ctx);
            });
            
        }).AddMassTransitHostedService();
    }
}