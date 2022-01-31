using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Domain
{
    public sealed class EventProcessor : IEventProcessor
    {
        private readonly IEventMapper _eventMapper;
        private readonly ILogger<IEventProcessor> _logger;
        private readonly IMediator _mediator;
        private readonly IMessageBroker _messageBroker;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public EventProcessor(IServiceScopeFactory serviceScopeFactory, IEventMapper eventMapper, IMessageBroker messageBroker,
            ILogger<IEventProcessor> logger, IMediator mediator)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _eventMapper = eventMapper;
            _messageBroker = messageBroker;
            _logger = logger;
            _mediator = mediator;
        }

        public async Task ProcessAsync(IEnumerable<IDomainEvent> events)
        {
            if (events is null) return;

            _logger.LogTrace("Processing domain events...");
            var integrationEvents = await HandleDomainEventsAsync(events);
            if (!integrationEvents.Any()) return;

            _logger.LogTrace("Processing integration events...");
            await _messageBroker.PublishAsync(integrationEvents);
        }

        private async Task<List<IEvent>> HandleDomainEventsAsync(IEnumerable<IDomainEvent> events)
        {
            var integrationEvents = new List<IEvent>();
            using var scope = _serviceScopeFactory.CreateScope();
            foreach (var @event in events)
            {
                var eventType = @event.GetType();
                _logger.LogTrace($"Handling domain event: {eventType.Name}");

                await _mediator.Publish(@event);

                var integrationEvent = _eventMapper.Map(@event);
                if (integrationEvent is null) continue;

                integrationEvents.Add(integrationEvent);
            }

            return integrationEvents;
        }
    }
}