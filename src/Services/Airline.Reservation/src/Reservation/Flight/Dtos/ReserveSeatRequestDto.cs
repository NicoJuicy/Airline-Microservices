namespace Reservation.Flight.Dtos;

public record ReserveSeatRequestDto(long FlightId, string SeatNumber);
