using BuildingBlocks.Exception;

namespace Flight.Flight.Exceptions;

public class AllSeatsFullException : BadRequestException
{
    public AllSeatsFullException() : base("All seats are full!")
    {
    }
}
