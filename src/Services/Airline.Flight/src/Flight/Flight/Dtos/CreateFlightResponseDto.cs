using System;
using Flight.Core.Models;

namespace Flight.Flight.Dtos;

public record CreateFlightResponseDto(long Id, string FlightNumber, long AircraftId, long DepartureAirportId,
    DateTime DepartureDate, DateTime ArriveDate, long ArriveAirportId,
    decimal DurationMinutes, DateTime FlightDate, FlightStatus Status, decimal Price);
