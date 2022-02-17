namespace Reservation.Reservation.Models.ValueObjects;

public record Journey(long FlightId, long DepartureAirportId, DateTime DepartureDate, long ArriveAirportId, DateTime ArriveDate, string Description);
