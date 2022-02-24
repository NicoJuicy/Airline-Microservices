using Flight.Aircraft.Models;
using Flight.Aircraft.Models.ValueObjects;

namespace Flight.Seat.Dtos;

public record SeatResponseDto
{
    public long Id { get; init; }
    public string SeatNumber { get; init; }
    public SeatType Type { get; init; }
    public SeatClass Class { get; init; }
}
