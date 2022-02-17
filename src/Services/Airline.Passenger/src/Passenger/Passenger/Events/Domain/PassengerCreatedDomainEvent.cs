using BuildingBlocks.Domain;

namespace Passenger.Passenger.Events;

public record PassengerCreatedDomainEvent(string FlightNumber) : IDomainEvent;
