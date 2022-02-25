using BuildingBlocks.Exception;

namespace Flight.Flight.Exceptions;

public class FlightAlreadyExistException : ConflictException
{
    public FlightAlreadyExistException(string code = default) : base("Flight already exist!", code)
    {
    }
}
