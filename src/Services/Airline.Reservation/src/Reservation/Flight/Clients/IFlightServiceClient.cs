using Refit;
using Reservation.Flight.Dtos;

namespace Reservation.Flight.Clients;

public interface IFlightServiceClient
{
    [Get("/api/v1/flights/{id}")]
    Task<FlightResponseDto> GetById(long id);
}