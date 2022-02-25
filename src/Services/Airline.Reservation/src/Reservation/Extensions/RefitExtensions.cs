using BuildingBlocks.Utils;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Reservation.Configuration;
using Reservation.Flight.Clients;
using Reservation.Passenger.Clients;

namespace Reservation.Extensions;

public static class RefitExtensions
{
    public static IServiceCollection AddRefitServices(this IServiceCollection services)
    {
        var refitOptions = services.GetOptions<RefitOptions>("Refit");

        services
            .AddRefitClient<IFlightServiceClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitOptions.FlightAddress));

        services
            .AddRefitClient<IPassengerServiceClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitOptions.PassengerAddress));

        return services;
    }
}
