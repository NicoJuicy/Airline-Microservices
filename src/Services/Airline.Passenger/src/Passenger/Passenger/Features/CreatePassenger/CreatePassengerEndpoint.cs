using BuildingBlocks.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Passenger.Passenger.Features.CreatePassenger;

[Route(BaseApiPath + "/passenger")]
public class CreatePassengerEndpoint : BaseController
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Create new reservation", Description = "Create new reservation")]
    public async Task<ActionResult> CreateReservation([FromBody] CreatePassengerCommand command,
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}