namespace BuildingBlocks.Domain;

public interface IEventMapper
{
    IEvent Map(IDomainEvent @event);
    IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events);
}