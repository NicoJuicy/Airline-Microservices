namespace BuildingBlocks.Domain;

public interface IMessageBroker
{
    Task PublishAsync(IEnumerable<IEvent> events);
}