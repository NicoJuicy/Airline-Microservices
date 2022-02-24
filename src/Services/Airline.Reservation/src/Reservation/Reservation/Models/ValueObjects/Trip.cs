namespace Reservation.Reservation.Models.ValueObjects;

public record Trip(long FlightId, long DepartureAirportId, DateTime Date, long ArriveAirportId, string Description);
