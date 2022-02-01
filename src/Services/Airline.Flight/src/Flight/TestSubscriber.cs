using System;
using DotNetCore.CAP;
using Flight.Flight.Features.CreateFlight;

namespace Flight;

public class TestSubscriber : ICapSubscribe
{
    [CapSubscribe("FlightCreated")]
    public void CheckReceivedMessage(FlightCreated flight)
    {
        Console.WriteLine($"{flight} Received!");
    }
}