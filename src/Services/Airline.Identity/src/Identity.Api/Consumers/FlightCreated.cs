using BuildingBlocks.Domain;
using MassTransit.Topology;

namespace Contract.Event;

[EntityName("flight-created")]
public record FlightCreated(string FlightNumber) : IEvent;
