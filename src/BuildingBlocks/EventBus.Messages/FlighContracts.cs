using BuildingBlocks.Domain;

namespace BuildingBlocks.EventBus.Messages;

public record FlightCreated(string FlightNumber) : IIntegrationEvent;