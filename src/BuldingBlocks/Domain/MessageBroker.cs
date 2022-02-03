
using DotNetCore.CAP;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Domain;

public class MessageBroker : IMessageBroker
{
    private readonly ICapPublisher _capPublisher;
    private readonly ILogger<MessageBroker> _logger;

    public MessageBroker(ICapPublisher capPublisher, ILogger<MessageBroker> logger)
    {
        _capPublisher = capPublisher;
        _logger = logger;
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
            _logger.LogInformation($"Published event{@event.GetType().Name}");
        }
    }
}
