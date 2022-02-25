using FluentValidation;

namespace Flight.Seat.Features.GetAvailableSeats;

public class GetAvailableSeatsQueryValidator : AbstractValidator<GetAvailableSeatsQuery>
{
    public GetAvailableSeatsQueryValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.FlightId).NotNull().WithMessage("FlightId is required!");
    }
}
