using Flight.Flight.Dtos;
using MediatR;

namespace Flight.Flight.Features.ReserveSeat;

public record ReserveSeatCommand(long FlightId, string SeatNumber) : IRequest<SeatResponseDto>;
