using BuildingBlocks.Exception;

namespace Reservation.Flight.Exceptions;

public class FlightNotFoundException: NotFoundException
{
    public FlightNotFoundException() : base("Flight doesn't exist!")
    {
    }
}
