using System;
using Flight.Flight.Dtos;
using Flight.Flight.Models;
using MediatR;

namespace Flight.Flight.Features.CreateFlight;

public record CreateFlightCommand(string FlightNumber, Models.ValueObjects.Aircraft Aircraft, Models.ValueObjects.Airport DepartureAirport,
    DateTime DepartureDate, DateTime ArriveDate, Models.ValueObjects.Airport ArriveAirport,
    decimal DurationMinutes, DateTime FlightDate, FlightStatus Status, decimal Price) : IRequest<FlightResponseDto>;
