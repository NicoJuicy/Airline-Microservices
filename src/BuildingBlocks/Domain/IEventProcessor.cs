namespace BuildingBlocks.Domain;

public interface IEventProcessor
{
    Task ProcessAsync(IEnumerable<IDomainEvent> events, CancellationToken cancellationToken = default);
}