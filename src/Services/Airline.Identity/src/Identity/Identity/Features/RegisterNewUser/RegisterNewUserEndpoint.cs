using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Identity.Identity.Features.RegisterNewUser;

public class LoginEndpoint: IdentityBaseEndpoint
{
    /// <summary>
    /// Register New User
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <response code="200">Success login</response>
    /// <response code="400">Some error</response>
    /// <returns>RegisterNewUserDto</returns>
    [HttpPost(nameof(RegisterNewUser))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Gets the ordered list of matching products tariffs for the given consumption rate")]
    public async Task<ActionResult> RegisterNewUser([FromBody] RegisterNewUserCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}