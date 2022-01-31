using BuildingBlocks.Validation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Flight.Extensions;

public static class MediatRExtensions
{
    public static IServiceCollection AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(typeof(FlightRoot).Assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}