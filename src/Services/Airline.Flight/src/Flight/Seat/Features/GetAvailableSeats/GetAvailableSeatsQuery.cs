using System.Collections.Generic;
using Flight.Seat.Dtos;
using MediatR;

namespace Flight.Seat.Features.GetAvailableSeats;

public record GetAvailableSeatsQuery(long FlightId) : IRequest<IEnumerable<SeatResponseDto>>;
