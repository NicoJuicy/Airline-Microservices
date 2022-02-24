using Flight.Flight.Models;
using FluentValidation;

namespace Flight.Flight.Features.CreateFlight;

public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateFlightCommandValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");

        RuleFor(x => x.Status).Must(p => (p.GetType().IsEnum &&
                                         p == FlightStatus.Flying) ||
                                         p == FlightStatus.Canceled ||
                                         p == FlightStatus.Delay ||
                                         p == FlightStatus.Completed)
            .WithMessage("Status must be Flying, Delay, Canceled or Completed");

        RuleFor(x => x.Aircraft).NotEmpty().WithMessage("Aircraft must be not empty");
        RuleFor(x => x.DepartureAirport).NotEmpty().WithMessage("DepartureAirport must be not empty");
        RuleFor(x => x.DurationMinutes).GreaterThan(0).WithMessage("DurationMinutes must be greater than 0");
        RuleFor(x => x.FlightDate).NotEmpty().WithMessage("FlightDate must be not empty");
    }
}
