using BuildingBlocks.Domain;

namespace Flight.Flight.Events.Domain;

public record FlightCreatedDomainEvent(string FlightNumber) : IDomainEvent;
