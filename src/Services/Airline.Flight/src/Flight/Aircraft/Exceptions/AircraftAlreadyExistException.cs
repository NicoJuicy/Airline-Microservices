using System.Net;
using BuildingBlocks.Exception;

namespace Flight.Aircraft.Exceptions;

public class AircraftAlreadyExistException : AppException
{
    public AircraftAlreadyExistException() : base("Flight already exist!", HttpStatusCode.Conflict)
    {
    }
}
