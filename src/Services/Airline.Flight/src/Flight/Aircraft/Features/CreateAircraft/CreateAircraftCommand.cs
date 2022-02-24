using Flight.Aircraft.Dtos;
using MediatR;

namespace Flight.Aircraft.Features.CreateAircraft;

public record CreateAircraftCommand(string Name, string Model, int ManufacturingYear) : IRequest<AircraftResponseDto>;
