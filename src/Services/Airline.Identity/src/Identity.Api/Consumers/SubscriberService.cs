using Contract.Event;
using MassTransit;

namespace Identity.Api.Consumers;

public class FlightCreatedConsumer : IConsumer<FlightCreated>
{
    private readonly ILogger<FlightCreatedConsumer> _logger;

    public FlightCreatedConsumer(ILogger<FlightCreatedConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<FlightCreated> context)
    {
        _logger.LogInformation(context.Message.ToString());
        _logger.LogInformation("We recived a flight created event");
        return Task.CompletedTask;
    }
}