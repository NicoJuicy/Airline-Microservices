namespace BuildingBlocks.Domain;

public interface IMessageBroker
{
    Task PublishAsync(IEnumerable<IEvent> events, CancellationToken cancellationToken = default);
    Task PublishAsync(IEvent @event, CancellationToken cancellationToken = default);
}