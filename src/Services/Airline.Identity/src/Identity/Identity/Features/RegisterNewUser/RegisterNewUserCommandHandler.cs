using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Domain;
using BuildingBlocks.EventBus.Messages;
using Identity.Identity.Dtos;
using Identity.Identity.Exceptions;
using Identity.Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Identity.Features.RegisterNewUser;

public class RegisterNewUserCommandHandler : IRequestHandler<RegisterNewUserCommand, RegisterNewUserResponseDto>
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMessageBroker _messageBroker;

    public RegisterNewUserCommandHandler(UserManager<ApplicationUser> userManager, IMessageBroker messageBroker)
    {
        _userManager = userManager;
        _messageBroker = messageBroker;
    }

    public async Task<RegisterNewUserResponseDto> Handle(RegisterNewUserCommand command,
        CancellationToken cancellationToken)
    {
        var applicationUser = new ApplicationUser
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            UserName = command.Username,
            Email = command.Email
        };

        var identityResult = await _userManager.CreateAsync(applicationUser, command.Password);
        var roleResult = await _userManager.AddToRoleAsync(applicationUser, Constants.Role.User);

        if (identityResult.Succeeded == false)
            throw new RegisterIdentityUserException(string.Join(',', identityResult.Errors.Select(e => e.Description)));

        if (roleResult.Succeeded == false)
            throw new RegisterIdentityUserException(string.Join(',', roleResult.Errors.Select(e => e.Description)));

        await _messageBroker.PublishAsync(new UserCreated(applicationUser.Id, applicationUser.FirstName + " " + applicationUser.LastName), cancellationToken);
        
        return new RegisterNewUserResponseDto
        {
            Id = applicationUser.Id,
            FirstName = applicationUser.FirstName,
            LastName = applicationUser.LastName,
            Username = applicationUser.UserName
        };
    }
}