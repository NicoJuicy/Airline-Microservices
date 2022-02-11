using Passenger.Models;

namespace Passenger.Passenger.Dtos;

public record CreatePassengerResponseDto(string Name, string PassportNumber,PassengerType PassengerType, int Age, string Email);
