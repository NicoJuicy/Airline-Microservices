using Reservation.Flight.Models;

namespace Reservation.Flight.Dtos;

public record SeatResponseDto
{
    public long Id { get; init; }
    public string SeatNumber { get; init; }
    public SeatType Type { get; init; }
    public SeatClass Class { get; init; }
    public long FlightId { get; init; }
}
