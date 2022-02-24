using Flight.Aircraft.Models;

namespace Flight.Flight.Models.ValueObjects;

public record Seat(string SeatNumber, SeatType Type, SeatClass SeatClass);
