using Flight.Core.Models;
using FluentValidation;

namespace Flight.Flight.Features.CreateFlight;

public class CreateFlightCommandValidator : AbstractValidator<CreateFlightCommand>
{
    public CreateFlightCommandValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Price must be greater than 0");
        
        RuleFor(x => x).Must(p => p.GetType().IsEnum &&
                                  p.Status == FlightStatus.Flying ||
                                  p.Status == FlightStatus.Delay ||
                                  p.Status == FlightStatus.Canceled ||
                                  p.Status == FlightStatus.Completed).WithMessage("Status must be Flying, Delay, Canceled or Completed");
        
        
        RuleFor(x => x.AircraftId).NotEmpty().WithMessage("AircraftId must be not empty");
        RuleFor(x => x.DepartureAirportId).NotEmpty().WithMessage("DepartureAirportId must be not empty");
        RuleFor(x => x.DurationMinutes).GreaterThan(0).WithMessage("DurationMinutes must be greater than 0");
        RuleFor(x => x.FlightDate).NotEmpty().WithMessage("FlightDate must be not empty");
    }
}