using FluentValidation;

namespace Flight.Flight.Features.GetFlightById;

public class GetFlightByIdQueryValidator : AbstractValidator<GetFlightByIdQuery>
{
    public GetFlightByIdQueryValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Id).NotNull().WithMessage("Id is required!");
    }
}
