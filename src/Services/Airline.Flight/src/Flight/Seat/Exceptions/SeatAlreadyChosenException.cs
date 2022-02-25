using BuildingBlocks.Exception;

namespace Flight.Seat.Exceptions;

public class SeatAlreadyChosenException : ConflictException
{
    public SeatAlreadyChosenException(string code = default) : base("Seat already chosen!", code)
    {
    }
}
