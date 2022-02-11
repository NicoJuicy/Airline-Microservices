using System.Collections.Generic;
using System.Linq;
using BuildingBlocks.Domain;

namespace Identity;

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
            _ => null
        };
    }
}