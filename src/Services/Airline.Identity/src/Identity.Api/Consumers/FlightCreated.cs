using BuildingBlocks.Domain;

namespace Contracts.Event;

public record FlightCreated(string FlightNumber) : IEvent;
