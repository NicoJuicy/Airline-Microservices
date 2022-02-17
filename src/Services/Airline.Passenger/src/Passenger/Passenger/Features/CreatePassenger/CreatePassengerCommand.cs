using MediatR;
using Passenger.Passenger.Dtos;
using Passenger.Passenger.Models;

namespace Passenger.Passenger.Features.CreatePassenger;

public record CreatePassengerCommand(string Name, string PassportNumber,PassengerType PassengerType, int Age, string Email): IRequest<PassengerResponseDto>;
