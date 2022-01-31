using BuildingBlocks.Domain;

namespace Flight.Flight.Features.CreateFlight;

public record FlightCreated(string FlightNumber) : IEvent;
