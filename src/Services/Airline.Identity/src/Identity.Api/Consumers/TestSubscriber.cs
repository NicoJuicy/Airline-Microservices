using DotNetCore.CAP;

namespace Identity.Api.Consumers;

public class TestSubscriber : ICapSubscribe
{
    [CapSubscribe(nameof(FlightCreated))]
    public void CheckReceivedMessage(FlightCreated flight)
    {
        Console.WriteLine($"{flight} Received!");
    }
}