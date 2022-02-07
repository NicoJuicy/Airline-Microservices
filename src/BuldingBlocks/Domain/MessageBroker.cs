using MassTransit;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Domain;

public class MessageBroker : IMessageBroker
{
    private readonly IPublishEndpoint _publishEndpoint;
    private readonly ILogger<MessageBroker> _logger;

    public MessageBroker(ILogger<MessageBroker> logger, IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
        _logger = logger;
    }

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
            await _publishEndpoint.Publish((dynamic) @event);
            _logger.LogInformation($"Published event :{@event}");
        }
    }
}