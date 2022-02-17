using BuildingBlocks.Domain;

namespace Passenger.Passenger.Events.Domain;

public record PassengerCreatedDomainEvent(string FlightNumber) : IDomainEvent;
