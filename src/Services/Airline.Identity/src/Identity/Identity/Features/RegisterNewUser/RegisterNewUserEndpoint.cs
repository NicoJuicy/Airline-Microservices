using System.Threading;
using System.Threading.Tasks;
using BuildingBlocks.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Identity.Identity.Features.RegisterNewUser;

[Route(BaseApiPath + "/login")]
public class LoginEndpoint: BaseController
{
    
    [HttpPost(nameof(RegisterNewUser))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [SwaggerOperation(Summary = "Register new user", Description = "Register new user")]
    public async Task<ActionResult> RegisterNewUser([FromBody] RegisterNewUserCommand command, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}