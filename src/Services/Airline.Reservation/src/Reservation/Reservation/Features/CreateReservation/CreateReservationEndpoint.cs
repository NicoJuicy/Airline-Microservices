using BuildingBlocks.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Reservation.Reservation.Features.CreateReservation;

[Route(BaseApiPath + "/reservation")]
public class CreateReservationEndpoint : BaseController
{
    [HttpPost]
    // [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerOperation(Summary = "Create new Reservation", Description = "Create new Reservation")]
    public async Task<ActionResult> CreateReservation([FromBody] CreateReservationCommand command,
        CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(command, cancellationToken);

        return Ok(result);
    }
}
