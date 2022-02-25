using Flight.Seat.Dtos;
using MediatR;

namespace Flight.Seat.Features.ReserveSeat;

public record ReserveSeatCommand(long FlightId, string SeatNumber) : IRequest<SeatResponseDto>;
