namespace BuildingBlocks.Domain;

public interface IMessageBroker
{
    Task PublishAsync(IEnumerable<IIntegrationEvent> events, CancellationToken cancellationToken = default);
    Task PublishAsync(IIntegrationEvent @event, CancellationToken cancellationToken = default);
}