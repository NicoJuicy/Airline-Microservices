using BuildingBlocks.Exception;

namespace Flight.Flight.Exceptions;

public class AircraftAlreadyExistException : ConflictException
{
    public AircraftAlreadyExistException(string code = default) : base("Aircraft already exist!", code)
    {
    }
}
