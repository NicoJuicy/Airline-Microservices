using BuildingBlocks.Exception;

namespace Flight.Airport.Exceptions;

public class AirportAlreadyExistException : ConflictException
{
    public AirportAlreadyExistException(string code = default) : base("Airport already exist!", code)
    {
    }
}
