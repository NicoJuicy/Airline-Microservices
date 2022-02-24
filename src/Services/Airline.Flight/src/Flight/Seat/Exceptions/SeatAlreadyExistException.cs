using BuildingBlocks.Exception;

namespace Flight.Seat.Exceptions;

public class SeatAlreadyExistException : ConflictException
{
    public SeatAlreadyExistException(string code = default) : base("Seat already exist!", code)
    {
    }
}
