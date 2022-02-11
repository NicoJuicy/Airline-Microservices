using BuildingBlocks.Domain;

namespace Passenger.Events;

public record PassengerCreatedDomainEvent(string FlightNumber) : IDomainEvent;
