using BuildingBlocks.Domain;

namespace BuildingBlocks.MessageContracts;

public record FlightCreated(string FlightNumber) : IEvent;