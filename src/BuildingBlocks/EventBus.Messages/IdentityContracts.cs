using BuildingBlocks.Domain;

namespace BuildingBlocks.EventBus.Messages;

public record UserCreated(long Id, string Name) : IIntegrationEvent;