namespace BuildingBlocks.Domain;

public record IntegrationEventWrapper<TDomainEventType>(TDomainEventType DomainEvent) : IEvent
    where TDomainEventType : IDomainEvent;