using BuildingBlocks.Domain;

namespace Identity.Api.Consumers;

public record FlightCreated(string FlightNumber) : IEvent;
