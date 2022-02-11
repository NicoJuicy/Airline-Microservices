using BuildingBlocks.Domain;

namespace Flight.Events;

public record FlightCreatedDomainEvent(string FlightNumber) : IDomainEvent;
