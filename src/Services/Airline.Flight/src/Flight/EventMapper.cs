using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain;
using BuildingBlocks.EventBus.Messages;
using Flight.Flight.Events.Domain;

namespace Flight;

public sealed class EventMapper : IEventMapper
{
    public IEnumerable<IIntegrationEvent> MapAll(IEnumerable<IDomainEvent> events)
    {
        return events.Select(Map);
    }

    public IIntegrationEvent Map(IDomainEvent @event)
    {
        return @event switch
        {
            FlightCreatedDomainEvent e => new FlightCreated(e.FlightNumber),
            _ => null
        };
    }
}
