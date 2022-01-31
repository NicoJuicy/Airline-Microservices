using BuildingBlocks.Domain;

namespace Flight.Core.Events;

public record FlightCreatedDomainEvent(string FlightNumber) : IDomainEvent;
