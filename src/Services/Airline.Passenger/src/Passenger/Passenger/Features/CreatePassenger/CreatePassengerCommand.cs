using MediatR;
using Passenger.Models;
using Passenger.Passenger.Dtos;

namespace Passenger.Passenger.Features.CreatePassenger;

public record CreatePassengerCommand(string Name, string PassportNumber,PassengerType PassengerType, int Age, string Email): IRequest<PassengerResponseDto>;
