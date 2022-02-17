using BuildingBlocks.Domain;

namespace Flight.Flight.Events;

public record FlightCreatedDomainEvent(string FlightNumber) : IDomainEvent;
