namespace BuildingBlocks.Exception;

public class AppException : System.Exception
{
    public AppException(string message, string code = default!) : base(message)
    {
        Code = code;
    }

    public AppException() : base()
    {
    }

    public AppException(string message) : base(message)
    {
    }

    public AppException(string message, System.Exception innerException) : base(message, innerException)
    {
    }

    public string Code { get; }
}
