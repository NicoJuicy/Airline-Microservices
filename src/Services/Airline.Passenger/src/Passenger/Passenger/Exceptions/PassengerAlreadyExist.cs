using BuildingBlocks.Exception;

namespace Passenger.Passenger.Exceptions;

public class PassengerAlreadyExist: ConflictException
{
    public PassengerAlreadyExist(string code = default) : base("Passenger already exist!", code)
    {
    }
}