using BuildingBlocks.Exception;

namespace Flight.Flight.Exceptions;

public class FlightNotFountException : NotFoundException
{
    public FlightNotFountException() : base("Flight not found!")
    {
    }
}
