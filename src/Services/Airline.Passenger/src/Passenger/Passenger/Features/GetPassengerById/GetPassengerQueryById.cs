using MediatR;
using Passenger.Passenger.Dtos;

namespace Passenger.Passenger.Features.GetPassengerById;

public record GetPassengerQueryById(long Id) : IRequest<PassengerResponseDto>;