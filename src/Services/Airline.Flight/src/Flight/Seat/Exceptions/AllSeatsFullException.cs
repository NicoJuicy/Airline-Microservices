using BuildingBlocks.Exception;

namespace Flight.Seat.Exceptions;

public class AllSeatsFullException : BadRequestException
{
    public AllSeatsFullException() : base("All seats are full!")
    {
    }
}
