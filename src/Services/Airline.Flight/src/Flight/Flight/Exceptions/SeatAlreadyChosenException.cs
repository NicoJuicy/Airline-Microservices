using BuildingBlocks.Exception;

namespace Flight.Flight.Exceptions;

public class SeatAlreadyChosenException : ConflictException
{
    public SeatAlreadyChosenException(string code = default) : base("Seat already chosen!", code)
    {
    }
}
