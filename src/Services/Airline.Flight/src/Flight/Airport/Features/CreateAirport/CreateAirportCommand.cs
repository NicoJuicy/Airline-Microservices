using Flight.Airport.Dtos;
using MediatR;

namespace Flight.Airport.Features.CreateAirport;

public record CreateAirportCommand(string Name, string Address, string Code) : IRequest<AirportResponseDto>;
