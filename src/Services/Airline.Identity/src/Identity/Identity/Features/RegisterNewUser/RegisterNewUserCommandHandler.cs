using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Identity.Core;
using Identity.Core.Models;
using Identity.Identity.Dtos;
using Identity.Identity.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Identity.Features.RegisterNewUser;

public class RegisterNewUserCommandHandler: IRequestHandler<RegisterNewUserCommand, RegisterNewUserResponseDto>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public RegisterNewUserCommandHandler(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RegisterNewUserResponseDto> Handle(RegisterNewUserCommand command, CancellationToken cancellationToken)
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

        return new RegisterNewUserResponseDto(applicationUser.Id, applicationUser.FirstName, applicationUser.LastName,
            applicationUser.UserName);
    }
}