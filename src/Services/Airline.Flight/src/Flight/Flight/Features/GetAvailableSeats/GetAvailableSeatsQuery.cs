using System.Collections.Generic;
using Flight.Flight.Dtos;
using MediatR;

namespace Flight.Flight.Features.GetAvailableSeats;

public record GetAvailableSeatsQuery(long FlightId) : IRequest<IEnumerable<SeatResponseDto>>;
