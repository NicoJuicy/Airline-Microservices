using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain;
using Contract.Event;
using Flight.Core.Events;

namespace Flight.Infrastructure;

public sealed class EventMapper : IEventMapper
{
    public IEnumerable<IEvent> MapAll(IEnumerable<IDomainEvent> events)
    {
        return events.Select(Map);
    }

    public IEvent Map(IDomainEvent @event)
    {
        return @event switch
        {
            FlightCreatedDomainEvent e => new FlightCreated(e.FlightNumber),
            _ => null
        };
    }
}