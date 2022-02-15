using MassTransit;
using MediatR;

namespace BuildingBlocks.Domain;

//Marker
[ExcludeFromTopology]
public interface IEvent : INotification
{
}