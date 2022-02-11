namespace Reservation.Reservation.Dtos;

public record ReservationResponseDto
{
    public long Id { get; init; }
    public long PassengerId { get; init; }
    public string Name { get; init; }
    public long FlightId { get; init; }
    public long DepartureAirportId { get; init; }
    public DateTime DepartureDate { get; init; }
    public long ArriveAirportId { get; init; }
    public DateTime ArriveDate { get; init; }
    public string Description { get; init; }
}