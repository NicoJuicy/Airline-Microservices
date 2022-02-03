using System;
using BuildingBlocks.Utils;
using DotNetCore.CAP;
using Identity.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.Extensions;

public static class CapExtensions
{
    public static IServiceCollection AddCustomCap(this IServiceCollection services)
    {
        var rabbitMqOptions = services.GetOptions<RabbitMQOptions>("RabbitMq");

        var capServices = services.AddCap(x =>
        {
            // If you are using EF, you need to add the configuration：
            x.UseEntityFramework<IdentityContext>(); //Options, Notice: You don't need to config x.UseSqlServer(""") again! CAP can autodiscovery.

            // CAP support RabbitMQ,Kafka,AzureService as the MQ, choose to add configuration you needed：
            x.UseRabbitMQ(r =>
            {
                r.HostName = rabbitMqOptions.HostName;
                r.ExchangeName = rabbitMqOptions.ExchangeName;
                r.UserName = rabbitMqOptions.UserName;
                r.Password = rabbitMqOptions.Password;
            });

            x.FailedRetryCount = 5;
        }).Services;

        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(ICapSubscribe)))
                .AsImplementedInterfaces());

        return capServices;
    }
}