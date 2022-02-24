using BuildingBlocks.Domain;
using BuildingBlocks.IdsGenerator;

namespace Flight.Aircraft.Models.ValueObjects;

public record Seat(string SeatNumber, SeatType Type, SeatClass Class, long AircraftId);
