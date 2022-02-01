
using DotNetCore.CAP;

namespace BuildingBlocks.Domain;

public class MessageBroker : IMessageBroker
{
    private readonly ICapPublisher _capPublisher;
    public MessageBroker(ICapPublisher capPublisher)
    {
        _capPublisher = capPublisher;
    }

    public Task PublishAsync(params IEvent[] events) => PublishAsync(events?.AsEnumerable());

    public async Task PublishAsync(IEnumerable<IEvent> events)
    {
        if (events is null)
        {
            return;
        }

        foreach (var @event in events)
        {
            if (@event is null)
            {
                continue;
            }
            
            await _capPublisher.PublishAsync(@event.GetType().Name, @event);
        }
    }
}
