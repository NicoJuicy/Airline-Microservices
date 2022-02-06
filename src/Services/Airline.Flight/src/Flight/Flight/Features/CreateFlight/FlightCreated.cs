using BuildingBlocks.Domain;
using MassTransit.Topology;

namespace Contract.Event;
public record FlightCreated(string FlightNumber) : IEvent;