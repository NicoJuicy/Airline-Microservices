using System;
using System.Collections.Generic;
using Flight.Flight.Dtos;
using Flight.Flight.Models;
using MediatR;

namespace Flight.Flight.Features.CreateFlight;

public record CreateFlightCommand(string FlightNumber, long AircraftId, long DepartureAirportId,
    DateTime DepartureDate, DateTime ArriveDate, long ArriveAirportId,
    decimal DurationMinutes, DateTime FlightDate, FlightStatus Status, decimal Price) : IRequest<FlightResponseDto>;
