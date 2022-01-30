using System.Net;

namespace BuildingBlocks.Exception;

public class CustomException: System.Exception
{
    public CustomException(
        string message,
        List<string> errors = default,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
    {
        ErrorMessages = errors;
        StatusCode = statusCode;
    }

    public List<string> ErrorMessages { get; }

    public HttpStatusCode StatusCode { get; }
}
