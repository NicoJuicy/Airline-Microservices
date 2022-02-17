using FluentValidation;
using Passenger.Passenger.Models;

namespace Passenger.Passenger.Features.CreatePassenger;

public class CreatePassengerCommandValidator : AbstractValidator<CreatePassengerCommand>
{
    public CreatePassengerCommandValidator()
    {
        CascadeMode = CascadeMode.Stop;

        RuleFor(x => x.Email).EmailAddress().WithMessage("The Email format is incorrect!");
        RuleFor(x => x.PassportNumber).NotNull().WithMessage("The PassportNumber is required!");
        RuleFor(x => x.Age).GreaterThan(0).WithMessage("The Age must be greater than 0!");
        RuleFor(x => x.Name).NotNull().WithMessage("The Name is required!");
        RuleFor(x => x.PassengerType).Must(p => p.GetType().IsEnum &&
                                                p == PassengerType.Baby ||
                                                p == PassengerType.Female ||
                                                p == PassengerType.Male ||
                                                p == PassengerType.Unknown)
            .WithMessage("PassengerType must be Male, Female, Baby or Unknown");
    }
}