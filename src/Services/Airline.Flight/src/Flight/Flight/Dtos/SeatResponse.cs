using Flight.Flight.Models;

namespace Flight.Flight.Dtos;

public record SeatResponseDto
{
    public long Id { get; set; }
    public string SeatNumber { get; init; }
    public SeatType Type { get; init; }
    public SeatClass Class { get; init; }
    public long FlightId { get; init; }
}
