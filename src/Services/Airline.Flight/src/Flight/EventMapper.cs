using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain;
using BuildingBlocks.MessageContracts;
using Flight.Events;

namespace Flight;

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