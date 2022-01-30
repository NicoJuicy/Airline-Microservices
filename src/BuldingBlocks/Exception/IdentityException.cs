using System.Net;

namespace BuildingBlocks.Exception;

public class IdentityException: CustomException
{
    public IdentityException(string message, List<string> errors = default, HttpStatusCode statusCode = default)
        : base(message, errors, statusCode)
    {
    }
}