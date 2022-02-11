using BuildingBlocks.Exception;

namespace Reservation.Reservation.Exceptions;

public class PassengerNotFoundException: NotFoundException
{
    public PassengerNotFoundException() : base("Flight doesn't exist! ")
    {
    }
}