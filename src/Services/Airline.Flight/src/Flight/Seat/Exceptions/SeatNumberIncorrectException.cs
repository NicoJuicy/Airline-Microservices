using BuildingBlocks.Exception;

namespace Flight.Seat.Exceptions;

public class SeatNumberIncorrectException : BadRequestException
{
    public SeatNumberIncorrectException() : base("Seat number is incorrect!")
    {
    }
}
