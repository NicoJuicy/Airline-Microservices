using Flight.Flight.Dtos;
using MediatR;

namespace Flight.Flight.Features.GetFlightById;
public record GetFlightByIdQuery(long Id) : IRequest<FlightResponseDto>;
