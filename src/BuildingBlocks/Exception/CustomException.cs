using System.Net;

namespace BuildingBlocks.Exception;

public class CustomException: System.Exception
{
    public CustomException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message)
    {
        StatusCode = statusCode;
    }
    
    public CustomException(
        string message,
        System.Exception innerException,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base(message, innerException)
    {
        StatusCode = statusCode;
    }
    
    public CustomException(
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError) : base()
    {
        StatusCode = statusCode;
    }
    
    public HttpStatusCode StatusCode { get; }
}
