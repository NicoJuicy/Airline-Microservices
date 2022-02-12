using BuildingBlocks.Domain;

namespace BuildingBlocks.MessageContracts;

public record UserCreated(long Id, string Name) : IEvent;